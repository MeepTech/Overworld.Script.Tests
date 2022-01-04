using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class Syntax {

    public partial class Operators {
      [TestClass]
      public class Plus {

        [TestMethod]
        public void Symbol_With_Literals() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:1+1
          ");

          Ows.Number @return
            = program.Debug() as Ows.Number;

          Assert.AreEqual(2, @return.IntValue);
        }

        [TestMethod]
        public void Symbol_With_Variables() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
              SET: x = 1;
              SET: Y = 2;
            
              Return:Y+X
          ");

          Ows.Number @return
            = program.Debug() as Ows.Number;

          Assert.AreEqual(3, @return.IntValue);
        }

        [TestMethod]
        public void Set_To_Symbol_With_Many_Variables() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
              SET:X=2;
              SET:bonus=1;
              SET:base=1;
              SET:count=10;
              SET:count = count + x PLUS bonus;
            
              Return:count;
          ");

          Ows.Number @return
            = program.Debug() as Ows.Number;

          Assert.AreEqual(13, @return.IntValue);
        }

        [TestMethod]
        public void Symbol_With_Literal_And_Variable() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET:X = 1;
            Return:X+1
          ");

          Ows.Number @return
            = program.Debug() as Ows.Number;

          Assert.AreEqual(2, @return.IntValue);
        }

        [TestMethod]
        public void Symbol_With_Literal_And_Variable_Reverse() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET :X = 1;
            Return:1+X
          ");

          Ows.Number @return
            = program.Debug() as Ows.Number;

          Assert.AreEqual(2, @return.IntValue);
        }

        [TestMethod]
        public void Symbol_With_Literal_And_Variable_Double() {
          Ows.Program program
            =  _Static.DefaultInterpreter.Build(@"
              SET :X = 1;
              Return:1+X+1
            ");

          Ows.Number @return
            = program.Debug() as Ows.Number;

          Assert.AreEqual(3, @return.IntValue);
        }

        [TestMethod]
        public void SET_to_Symbol_With_many_Literals() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET :X = 10+3+2+1;
            Return:X
          ");

          Ows.Number @return
          = program.Debug() as Ows.Number;

          Assert.AreEqual(16, @return.IntValue);
        }
      }
    }
  }
}
