using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace FirstMod.Patches
{

    [HarmonyPatch(typeof(PlayerControllerB))]
    internal class PlayerControllerBPatch
    {
        static LcInputStuff lcInputStuff = LcInputStuff.Instance;
        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        // Remove the bind while on the terminal.
        static void killButton(PlayerControllerB __instance, bool __inTerminalMenu) 
        {
            if (lcInputStuff.DeathKey.triggered || !__inTerminalMenu)
            {
                __instance.KillPlayer(Vector3.zero);
            }
        }

    }
}
