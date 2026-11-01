using Godot;
using HarmonyLib;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace EvolveReplacementMod.Patches;

/// <summary>
/// 把 IterationPower（进化 Buff）图标替换为 STS1 EvolvePower 图标。
/// 覆盖小图标路径、大图标路径以及两个 Texture 属性（含 pck 加载失败时的内嵌兜底）。
/// </summary>
[HarmonyPatch(typeof(PowerModel), "PackedIconPath", MethodType.Getter)]
public static class EvolvePowerPackedIconPathPatch
{
    private static bool Prefix(PowerModel __instance, ref string __result)
    {
        if (__instance is not IterationPower || !ModConfig.IsReplaceIterationEnabled)
        {
            return true;
        }

        __result = ModEntry.PowerIcon64Path;
        return false;
    }
}

[HarmonyPatch(typeof(PowerModel), "ResolvedBigIconPath", MethodType.Getter)]
public static class EvolvePowerBigIconPathPatch
{
    private static bool Prefix(PowerModel __instance, ref string __result)
    {
        if (__instance is not IterationPower || !ModConfig.IsReplaceIterationEnabled)
        {
            return true;
        }

        __result = ModEntry.PowerIcon256Path;
        return false;
    }
}

[HarmonyPatch(typeof(PowerModel), "Icon", MethodType.Getter)]
public static class EvolvePowerIconPatch
{
    private static bool Prefix(PowerModel __instance, ref Texture2D __result)
    {
        if (__instance is not IterationPower || !ModConfig.IsReplaceIterationEnabled)
        {
            return true;
        }

        __result = PowerIconTextureLoader.Get64();
        return false;
    }
}

[HarmonyPatch(typeof(PowerModel), "BigIcon", MethodType.Getter)]
public static class EvolvePowerBigIconPatch
{
    private static bool Prefix(PowerModel __instance, ref Texture2D __result)
    {
        if (__instance is not IterationPower || !ModConfig.IsReplaceIterationEnabled)
        {
            return true;
        }

        __result = PowerIconTextureLoader.Get256();
        return false;
    }
}
