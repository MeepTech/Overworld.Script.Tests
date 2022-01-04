using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Overworld.Script.Tests {
  public partial class Syntax {

    public partial class Comparitors {
      [TestClass]
      public class Identity {

        [TestMethod]
        public void true_is_true() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:True
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsTrue(@return.Value);
        }

        [TestMethod]
        public void false_is_false() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            Return:false
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsFalse(@return.Value);
        }

        [TestMethod]
        public void vairable_false_is_false() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET: X = false;
            Return:x = false
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsTrue(@return.Value);
        }

        [TestMethod]
        public void vairable_true_is_true() {
          Ows.Program program
          =  _Static.DefaultInterpreter.Build(@"
            SET: X = true;
            Return:x = true
          ");

          Ows.Boolean @return
            = program.ExecuteAs(_Static.DefaultCharacter) as Ows.Boolean;

          Assert.IsTrue(@return.Value);
        }
      }
    }
  }
}
