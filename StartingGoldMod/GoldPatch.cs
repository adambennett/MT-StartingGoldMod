using HarmonyLib;

namespace StartingGoldMod
{
    [HarmonyPatch(typeof(SaveManager), "GetStartingGoldForClass")]
    static class GoldPatch 
    {
        static void Postfix(ref int __result)
        {
            __result = GoldMod._goldAmt.Value;
        }
    }
}