using System;

namespace Overworld.Script.Tests {
  public static class _EX {
    public static Ows.Variable Debug(this Ows.Program program)
      => program.DebugAs(_Static.DefaultCharacter, new Ows.Command.Context.DebugData {
        BeforeLine = (context, lineNumber) => {
          Console.WriteLine($"{lineNumber}: START: {context.Command?.Archetype.Id.Name}");
        }
            ,
        AfterLine = (context, lineNumber) => {
          Console.WriteLine($"{lineNumber}: COMPLETE: {context.Command?.Archetype.Id.Name}");
        }
            ,
        BeforeCommandExecution = context => {
          Console.WriteLine($"\t >: EXECUTE: {context.Command}");
        },
      });
  }
}