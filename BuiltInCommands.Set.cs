using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class BuiltInCommands {
    [TestClass]
    public class Set {
      [TestMethod]
      public void Set_Bool_To_True() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST TO TRUE
            RETURN:TEST
          ");

        Ows.Boolean @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.IsTrue(@return.Value);
      }

      [TestMethod]
      public void Set_Bool_To_False() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST TO False
            RETURN:TEST
          ");

        Ows.Boolean @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.IsFalse(@return.Value);
      }

      [TestMethod]
      public void Set_Bool_equals_true() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST equals true
            RETURN:TEST
          ");

        Ows.Boolean @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.IsTrue(@return.Value);
      }

      [TestMethod]
      public void Set_Bool_as_true() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST As true
            RETURN:TEST
          ");

        Ows.Boolean @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.IsTrue(@return.Value);
      }

      [TestMethod]
      public void Set_number_is_1() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST Is 1
            RETURN:TEST
          ");

        Ows.Number @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(@return.IntValue , 1);
      }

      [TestMethod]
      public void Set_number_is_0() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST Is 0
            RETURN:TEST
          ");

        Ows.Number @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(@return.IntValue, 0);
      }

      [TestMethod]
      public void Set_number_as_string_okay() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST as ""Ok""
            RETURN:TEST
          ");

        Ows.String @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.String;

        Assert.AreEqual("Ok", @return.Value);
      }

      [TestMethod]
      public void Set_string_again_to_okay() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST as ""Not-Ok""
            SET:TEST TO ""Ok""
            RETURN:TEST
          ");

        Ows.String @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.String;

        Assert.AreEqual(@return.Value, "Ok");
      }

      /*[TestMethod]
      public void Set_string_to_int_failure() {
        Ows.Program program
          = _Static.DefaultInterpreter.Build(@"
            SET:TEST as ""Not-Ok""
            SET:TEST TO 3
            RETURN:TEST
          ");

        Assert.ThrowsException<System.ArgumentException>(() => {
          program.ExecuteAs(_Static.DefaultCharacter);
        });
      }*/

      [TestMethod]
      public void Set_number_from_command_return() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST as test-return-4
            RETURN:TEST
          ");

        Ows.Number @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(@return.IntValue, 4);
      }

      [TestMethod]
      public void Set_number_from_opperation() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST as 4-4
            RETURN:TEST
          ");

        Ows.Number @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(@return.IntValue, 0);
      }

      [TestMethod]
      public void Set_bool_from_condition() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:TEST as (true=false)
            RETURN:TEST
          ");

        Ows.Boolean @return
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

        Assert.IsFalse(@return.Value);
      }
    }
  }
}
