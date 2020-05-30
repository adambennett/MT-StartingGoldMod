using BepInEx;
using BepInEx.Configuration;
using HarmonyLib;

namespace StartingGoldMod
{
    [BepInPlugin("nyoxide.monstertrain.starting-gold-mod", "Starting Gold Mod", "1.0.0.2")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    public class GoldMod : BaseUnityPlugin
    {
        private static ConfigEntry<int> _goldAmt;
        private static ConfigEntry<bool> _useCustomAmt;
        
        [HarmonyPatch(typeof(SaveManager), "GetStartingGoldForClass")]
        static class GoldPatch 
        {
            static void Postfix(ref int __result)
            {
                __result = _goldAmt.Value;
            }
        }

        void Patch()
        {
            var harmony = new Harmony("nyoxide.monstertrain.testmod.harmony");
            harmony.PatchAll();
        }

        void Awake()
        {
            _useCustomAmt = Config.Bind("General", "Customize Gold Amount", true, "If you set this to false, vanilla Monster Train settings will be used to set your starting gold each run.");
            _goldAmt = Config.Bind("General", "Gold Amount", 420, "The amount of gold to start each run with.");
            if (_useCustomAmt.Value)
            {
                Patch();
            }
        }

    }
}