using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class BuiltInCommands {

    [TestClass]
    public class If {

      [TestMethod]
      public void RETURN_4_IF_TRUE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:TRUE:END-AND-RETURN:4;
            RETURN:5
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 4);
      }

      [TestMethod]
      public void END_AND_RETURN_4_IF_TRUE_ONE_LINE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:TRUE:END-AND-RETURN:4;RETURN:5
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 4);
      }

      [TestMethod]
      public void END_AND_RETURN_5_IF_FALSE_ONE_LINE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:FALSE:END-AND-RETURN:4;RETURN:5
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 5);
      }

      [TestMethod]
      public void RETURN_NOTHING_IF_TRUE_ONE_LINE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:TRUE:4;
          ");

        Ows.Variable number
          = program.ExecuteAs(_Static.DefaultCharacter);

        Assert.AreEqual(number, null);
      }

      [TestMethod]
      public void RETURN_NULL_IF_FALSE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET: TEST = FALSE
            RETURN:IF:TEST:4;RETURN:5
          ");


        Ows.Variable @return
          = program.ExecuteAs(_Static.DefaultCharacter);

        Assert.AreEqual(@return, null);
      }

      [TestMethod]
      public void RETURN_4_IF_ELSE_TRUE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            RETURN:IF:TRUE:4
            ...:ELSE:5
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 4);
      }

      [TestMethod]
      public void RETURN_5_IF_FALSE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:FALSE:END-AND-RETURN:4
            RETURN:5
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 5);
      }

      [TestMethod]
      public void RETURN_5_IF_ELSE_FALSE() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            RETURN:IF:FALSE:4:ELSE:5
          ");

        var @return
          = program.ExecuteAs(_Static.DefaultCharacter);

        Ows.Number number
          = @return as Ows.Number;

        Assert.AreEqual(number.IntValue, 5);
      }

      [TestMethod]
      public void Return_5_If_Inline_Set_False() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST = 4;
            IF:FALSE:SET:TEST=5
            
            RETURN:test
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 4);
      }

      [TestMethod]
      public void Return_5_If_Inline_Set_True() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST = 4;
            IF:TRUE:SET:TEST=5
            
            RETURN:test
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 5);
      }

      [TestMethod]
      public void Return_5_If_Go_to() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:TRUE:GOTO:true_label
            RETURN:false

            [true_label]: end-and-Return:True
          ");

        Ows.Boolean @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.AreEqual(@return.Value, true);
      }
    }
  }
}
