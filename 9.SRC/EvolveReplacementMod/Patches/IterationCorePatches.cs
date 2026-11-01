using System.Collections.Generic;
using HarmonyLib;
using MegaCrit.Sts2.Core.Localization.DynamicVars;
using MegaCrit.Sts2.Core.Models.Cards;
using MegaCrit.Sts2.Core.Models.Powers;

namespace EvolveReplacementMod.Patches;

/// <summary>
/// Iteration 核心数值替换：PowerVar 2 → 1（塔1 Evolve 基础抽 1 张）。
/// 升级保持 OnUpgrade +1，自动得到升级抽 2 张，无需补丁 OnUpgrade。
/// 类型/费用/稀有度/目标与塔1 Evolve 完全一致，无需其他形状补丁。
/// </summary>
[HarmonyPatch(typeof(Iteration), "CanonicalVars", MethodType.Getter)]
public static class IterationCanonicalVarsPatch
{
    private static void Postfix(Iteration __instance, ref IEnumerable<DynamicVar> __result)
    {
        if (ModConfig.IsReplaceIterationEnabled)
        {
            __result = new DynamicVar[] { new PowerVar<IterationPower>(1m) };
        }
    }
}
