using BepInEx;
using BepInEx.Logging;
using FirstMod.Patches;
using HarmonyLib;

namespace FirstMod
{
    [BepInPlugin(modGUID, modName, modVersion)]
    public class ClassTest : BaseUnityPlugin
    {
        private const string modGUID = "Nono.FirstNonoMod";
        private const string modName = "First Mod";
        private const string modVersion = "1.0.0.1";

        private readonly Harmony harmony = new Harmony(modGUID);

        private static ClassTest Instance;

        internal ManualLogSource mls; 
        void Awake()
        {
            if (Instance == null)
            {
                Instance = this; 
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUID);

            mls.LogInfo("Do not press K hehehe ;)");

            harmony.PatchAll(typeof(ClassTest));
            harmony.PatchAll(typeof(LcInputStuff));
            harmony.PatchAll(typeof(PlayerControllerBPatch));
        }
    }
}
