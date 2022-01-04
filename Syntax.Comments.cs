using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class Syntax {
    [TestClass]
    public partial class Comments {
      [TestMethod]
      public void Whole_Line() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            #Return:10
            Return:100
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }
      [TestMethod]
      public void Whole_Line_spaced() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            # Return:10
            Return:100
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }

      [TestMethod]
      public void Partial_Line() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return: #Return:10# 100
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }

      [TestMethod]
      public void Partial_Line_not_spaced() {
        Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:#Return:10#100
          ");

        Ows.Number number
          = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Number;

        Assert.AreEqual(number.IntValue, 100);
      }
    }
  }
}
