using System;

namespace Overworld.Script.Tests {

  /// <summary>
  /// Returns the number 4 for testing
  /// </summary>
  public class TEST_RETURN_4 : Ows.Command.Type {

    /// <summary>
    /// X Bam init
    /// </summary>
    TEST_RETURN_4() 
      : base(new Identity("TEST-RETURN-4"), 
          new System.Type[0]
        ) {}

    public override Func<Ows.Command.Context, Ows.Variable> Execute {
      get;
    } = context 
      => new Ows.Number(context.Command.Program, 4);
  }
}
