using BepInEx;
using GameNetcodeStuff;
using HarmonyLib;
using UnityEngine;

namespace FirstMod.Patches
{

    [HarmonyPatch(typeof(PlayerControllerB))]
    
    internal class PlayerControllerBPatch 
    {
        static LcInputStuff lcInputStuff = LcInputStuff.Instance;
        static System.Random randomDeath = new System.Random();

        [HarmonyPatch("Update")]
        [HarmonyPostfix]

        static void killButton(PlayerControllerB __instance, bool ___isTypingChat, bool ___inTerminalMenu)
        {
            int[] randomDeathChoice = { 0, 1, 2 };
            int randomDeathIndex = randomDeath.Next(randomDeathChoice.Length);
            if (___isTypingChat || ___inTerminalMenu) 
            {   
                lcInputStuff.DeathKey.Disable();
                return;
            }
            else
            {
                lcInputStuff.DeathKey.Enable();
                if ((__instance = GameNetworkManager.Instance.localPlayerController) && lcInputStuff.DeathKey.triggered) 
                {
                    __instance.KillPlayer(Vector3.zero, true, CauseOfDeath.Strangulation, deathAnimation: randomDeathChoice[randomDeathIndex]);
                    
                }
            }
        }

    }
}
