using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace StartingGoldMod
{
    [BepInPlugin("nyoxide.monstertrain.starting-gold-mod", "Moneybags", "1.1.0.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class GoldMod : BaseUnityPlugin
    {
        public static ConfigEntry<int> _goldAmt;
        private static ConfigEntry<bool> _useCustomAmt;
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Nyoxide's Logger");
        
        public static void log(LogLevel lvl, string msg)
        {
            logger.Log(lvl, msg);
        }
        
        void Patch()
        {
            var harmony = new Harmony("nyoxide.monstertrain.harmony");
            harmony.PatchAll();
        }

        void Awake()
        {
            _useCustomAmt = Config.Bind("General", "Enable Moneybags", true, "If you set this to false, vanilla Monster Train settings will be used to set your starting gold each run.");
            _goldAmt = Config.Bind("General", "Gold Amount", 420, "The amount of gold to start each run with.");
            if (_useCustomAmt.Value) 
                Patch();
        }

    }
}