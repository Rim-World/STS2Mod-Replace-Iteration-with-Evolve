using HarmonyLib;
using MegaCrit.Sts2.Core.Localization;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Cards;

namespace EvolveReplacementMod.Patches;

/// <summary>
/// 文本替换补丁：本地化文件新增 RE_EVOLVE.title/.description 键
/// （模组专属前缀，避免与其他 mod 的 EVOLVE.* 键冲突），由这里切换到新键。
/// </summary>
[HarmonyPatch(typeof(CardModel), "TitleLocString", MethodType.Getter)]
public static class IterationTitleLocStringPatch
{
    private static void Postfix(CardModel __instance, ref LocString __result)
    {
        if (__instance is Iteration && ModConfig.IsReplaceIterationEnabled)
        {
            __result = new LocString("cards", "RE_EVOLVE.title");
        }
    }
}

[HarmonyPatch(typeof(CardModel), "Description", MethodType.Getter)]
public static class IterationDescriptionPatch
{
    private static void Postfix(CardModel __instance, ref LocString __result)
    {
        if (__instance is Iteration && ModConfig.IsReplaceIterationEnabled)
        {
            __result = new LocString("cards", "RE_EVOLVE.description");
        }
    }
}
