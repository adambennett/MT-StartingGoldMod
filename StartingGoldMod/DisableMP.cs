using System.Collections.Generic;
using HarmonyLib;
using ShinyShoe;

namespace StartingGoldMod
{
    // Credit to Rawsome, Stable Infery for this: a quick and dirty patch to disable the multiplayer button.
    [HarmonyPatch(typeof(MainMenuScreen), "CollectMenuButtons")]
    static class MainMenuScreen_CollectMenuButtons_Patch
    {
        static void Postfix(ref GameUISelectableButton ___multiplayerButton, ref List<GameUISelectableButton> ___menuButtons)
        {
            ___menuButtons.Remove(___multiplayerButton);
            ___multiplayerButton.enabled = false;
        }
    }
}