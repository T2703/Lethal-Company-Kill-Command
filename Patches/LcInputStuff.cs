using LethalCompanyInputUtils.Api;
using LethalCompanyInputUtils.BindingPathEnums;
using UnityEngine.InputSystem;

namespace FirstMod.Patches
{
    internal class LcInputStuff : LcInputActions
    {
        [InputAction(KeyboardControl.K, Name = "Death")]
        public InputAction DeathKey { get; set; }

        public static LcInputStuff Instance = new LcInputStuff();
    }
}
