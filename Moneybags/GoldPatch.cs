using BepInEx.Logging;
using HarmonyLib;

namespace Moneybags
{
    [HarmonyPatch(typeof(SaveManager), "GetStartingGoldForClass")]
    static class GoldPatch 
    {
        static void Postfix(ref int __result)
        {
            __result = MoneybagsMod._goldAmt.Value;
            MoneybagsMod.log(LogLevel.Debug, "New starting gold amount: " + __result);
        }
    }
}