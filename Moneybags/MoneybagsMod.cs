using BepInEx;
using BepInEx.Configuration;
using BepInEx.Logging;
using HarmonyLib;

namespace Moneybags
{
    [BepInPlugin("moneybags.nyoxide", "Moneybags", "1.1.1.0")]
    [BepInProcess("MonsterTrain.exe")]
    [BepInProcess("MtLinkHandler.exe")]
    [BepInDependency("api.modding.train.monster")]
    public class MoneybagsMod : BaseUnityPlugin
    {
        public static ConfigEntry<int> _goldAmt;
        private static ManualLogSource logger = BepInEx.Logging.Logger.CreateLogSource("Moneybags");
        
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
            _goldAmt = Config.Bind("General", "Gold Amount", 420, "The amount of gold to start each run with.");
            Patch();
        }

    }
}