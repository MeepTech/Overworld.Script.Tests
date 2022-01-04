using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class Syntax {

    [TestClass]
    public class With {

      [TestMethod]
      public void DO_WITH() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            DO:test_label WITH [x AS 100];

            [test_label]: end-and-Return:x
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }

      [TestMethod]
      public void DO_WITH_SHADOWING_GLOBAL_CHAR_SPECIFIC() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:x = 5;
            RETURN:DO:test_label WITH [x AS 100];

            [test_label]: Return:x
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }

      [TestMethod]
      public void FOR_DO_WITH_LOOP() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:X=0;
            SET:bonus=1;
            SET:base=1;
            SET:count=0;

            COUNT-UP-WITH:X:100:
            ... DO:
            ...   test_label WITH [
            ...     Base as 4
            ...     AND Bonus is 2
            ...   ]

            RETURN:count

            [test_label]:
              SET:count = count + x PLUS bonus;
              GO-BACK
          ");

        Ows.Number number
          = program.Debug() as Ows.Number;

        Assert.AreEqual(5150, number.IntValue);
      }
    }
  }
}