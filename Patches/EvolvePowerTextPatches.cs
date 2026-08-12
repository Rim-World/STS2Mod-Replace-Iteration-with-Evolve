using HarmonyLib;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace EvolveReplacementMod.Patches;

/// <summary>
/// IterationPower（打出后获得的 Buff）名称/描述/智能描述切换为 RE_EVOLVE_POWER.*
/// （塔1 EvolvePower“进化”文案）。
/// </summary>
[HarmonyPatch(typeof(PowerModel), "Title", MethodType.Getter)]
public static class EvolvePowerTitlePatch
{
    private static void Postfix(PowerModel __instance, ref LocString __result)
    {
        if (__instance is IterationPower && ModConfig.IsReplaceIterationEnabled)
        {
            __result = new LocString("powers", "RE_EVOLVE_POWER.title");
        }
    }
}

[HarmonyPatch(typeof(PowerModel), "Description", MethodType.Getter)]
public static class EvolvePowerDescriptionPatch
{
    private static void Postfix(PowerModel __instance, ref LocString __result)
    {
        if (__instance is IterationPower && ModConfig.IsReplaceIterationEnabled)
        {
            __result = new LocString("powers", "RE_EVOLVE_POWER.description");
        }
    }
}

[HarmonyPatch(typeof(PowerModel), "SmartDescription", MethodType.Getter)]
public static class EvolvePowerSmartDescriptionPatch
{
    private static void Postfix(PowerModel __instance, ref LocString __result)
    {
        if (__instance is IterationPower && ModConfig.IsReplaceIterationEnabled)
        {
            __result = new LocString("powers", "RE_EVOLVE_POWER.smartDescription");
        }
    }
}
