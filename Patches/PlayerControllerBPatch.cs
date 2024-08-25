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

        static void killButton(PlayerControllerB __instance) 
        {
            if (lcInputStuff.DeathKey.triggered) 
            {
                __instance.KillPlayer(Vector3.zero);
            }
        }

    }
}
