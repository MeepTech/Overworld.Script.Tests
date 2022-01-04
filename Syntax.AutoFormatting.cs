using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class Syntax {
    [TestClass]
    public class AutoFormatting {

      [TestMethod]
      public void AUTO_FORMAT_1() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:x = 5;
            RETURN:DO:test_label WITH [x AS 100];

            [test_label]: Return:x
          ");

        string raw = program.ToString();
        Ows.Program recompiled
          = _Static.DefaultInterpreter.Build(raw);

        Ows.Number number
          = recompiled.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }

      [TestMethod]
      public void AUTO_FORMAT_2_FALL_THROUGH() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:x = 5;
            DO:test_label WITH [x AS 100];

            #No Return So This Falls though
            [test_label]: Return:x
          ");

        string raw = program.ToString();
        Ows.Program recompiled
          = _Static.DefaultInterpreter.Build(raw);

        Ows.Number number
          = recompiled.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 5);
      }
    }
  }
}