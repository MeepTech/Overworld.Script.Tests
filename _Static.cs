using Meep.Tech.Data;
using Meep.Tech.Data.Configuration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Overworld.Data;

namespace Overworld.Script.Tests {

  [TestClass]
  public class _Static {

    /// <summary>
    /// Default Universe
    /// </summary>
    public static Universe Universe {
      get;
      private set;
    }

    /// <summary>
    /// Default character for testing
    /// </summary>
    public static Character DefaultCharacter {
      get;
      private set;
    }

    /// <summary>
    /// Default interpreter for testing
    /// </summary>
    public static Ows.Interpreter DefaultInterpreter {
      get;
      private set;
    }

    [AssemblyInitialize]
    public static void AssemblyInitialize(TestContext testContext) {
      Loader.Settings settings = new() {
        FatalOnCannotInitializeType = true,
        PreLoadAssemblies = new() {
          typeof(Entity.Animation).Assembly,
          typeof(TEST_RETURN_4).Assembly
        }
      };

      // Add the converter for tags to both settings:
      settings.ModelSerializerOptions = new Model.Serializer.Settings {

        ConfigureJsonSerializerSettings = (defaultResolver, converters) => {
          var defaultSettings = settings.ModelSerializerOptions
            .ConfigureJsonSerializerSettings(defaultResolver, converters);
          defaultSettings.Converters.Add(new Tag.JsonConverter());

          return defaultSettings;
        }

      };

      Loader loader = new(settings);
      loader.Initialize(
        Universe = new Universe(loader, "Overworld-Test")
      );


      DefaultCharacter
        = Entity.Types.Get<Character.Type>()
          .Make<Character>((nameof(Character.UniqueName), "Test"));

      DefaultInterpreter
        = new(new Ows.Program.ContextData(
            new System.Collections.Generic.Dictionary<string, Ows.Command.Type> {
              { Archetypes<TEST_RETURN_4>._.Id.Name, Archetypes<TEST_RETURN_4>._},
            }, new System.Collections.Generic.Dictionary<string, Entity>() {
              { DefaultCharacter.Id, DefaultCharacter }
            }, new System.Collections.Generic.Dictionary<string, Character>() {
              { DefaultCharacter.Id, DefaultCharacter }
            }
          ));
    }
  }
}
