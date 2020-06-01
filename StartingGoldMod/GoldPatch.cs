using BepInEx.Logging;
using HarmonyLib;

namespace StartingGoldMod
{
    [HarmonyPatch(typeof(SaveManager), "GetStartingGoldForClass")]
    static class GoldPatch 
    {
        static void Postfix(ref int __result)
        {
            __result = GoldMod._goldAmt.Value;
            GoldMod.log(LogLevel.Debug, "New starting gold amount: " + __result);
        }
    }
}