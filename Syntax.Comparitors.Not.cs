using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class Syntax {

    public partial class Comparitors {

      [TestClass]
      public class Not {

        [TestMethod]
        public void Return_Not_True_IS_False() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:Not-True
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsFalse(@return.Value);
        }

        [TestMethod]
        public void Return_Not_false_IS_true() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:Not-FALSE
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsTrue(@return.Value);
        }

        [TestMethod]
        public void Return_Not_variable_IS_true() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET: X = false
            Return:Not-X
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsTrue(@return.Value);
        }

        [TestMethod]
        public void Return_Not_variable_IS_false() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET: X = true
            Return:Not-X
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsFalse(@return.Value);
        }

        [TestMethod]
        public void Return_FALSE_EQUALS_Not_True() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:FALSE = Not-True
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsTrue(@return.Value);
        }
      }
    }
  }
}
