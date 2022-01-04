using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {

  [TestClass]
  public partial class BuiltInCommands {

    [TestClass]
    public class Return {

      [TestMethod]
      public void Bool_True_Success() {
        Ows.Command program 
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:TRUE");

        Ows.Boolean @bool 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Boolean;

        Assert.IsTrue(@bool.Value);
      }

      [TestMethod]
      public void Bool_False_Success() {
        Ows.Command program
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:FALSE");

        Ows.Boolean @bool 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Boolean;

        Assert.IsFalse(@bool.Value);
      }

      [TestMethod]
      public void Number_4_Success() {
        Ows.Command program
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:4");

        Ows.Number number 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Number;

        Assert.AreEqual(number.IntValue, 4);
      }

      [TestMethod]
      public void String_Ok_Success() {
        Ows.Command program 
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:\"Ok\"");

        Ows.String @string 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.String;

        Assert.AreEqual(@string.Value, "Ok");
      }

      [TestMethod]
      public void String_Ok_MultiLLine_Success() {
        Ows.Program program 
          =  _Static.DefaultInterpreter.Build(@"
            RETURN:""Ok""
          ");

        Ows.String @string 
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.String;

        Assert.AreEqual(@string.Value, "Ok");
      }

      [TestMethod]
      public void ConditionResult_True_Success() {
        Ows.Command program 
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:TRUE=TRUE");

        Ows.Boolean @return 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Boolean;

        Assert.IsTrue(@return?.Value ?? false);
      }

      [TestMethod]
      public void ConditionResult_False_Success() {
        Ows.Command program 
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:TRUE EQuals FALSE");

        Ows.Boolean @bool 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Boolean;

        Assert.IsFalse(@bool.Value);
      }

      [TestMethod]
      public void OperatorResult_8_Success() {
        Ows.Command program 
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:4+4");

        Ows.Number number 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Number;

        Assert.AreEqual(number.IntValue, 8);
      }

      [TestMethod]
      public void CommandResult_4_Success() {
        Ows.Command program 
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:Test-Return-4");

        Ows.Number @bool 
          = program.ExecuteFor(_Static.DefaultCharacter).Value as Ows.Number;

        Assert.AreEqual(@bool.IntValue, 4);
      }

      [TestMethod]
      public void ExecuteAs_Null_Success() {
        Ows.Command program
          =  _Static.DefaultInterpreter.BuildLine($"RETURN:TRUE");

        Ows.Boolean @bool 
          = program.ExecuteFor(null).Value as Ows.Boolean;

        Assert.IsTrue(@bool.Value);
      }

      [TestMethod]
      public void Return_second_layer_fails() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            IF:TRUE:GOTO:true_label
            RETURN:false

            [true_label]: Return:True
          ");

        Ows.Boolean @bool
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.AreEqual(false, @bool.Value);
      }
    }
  }
}
