using System.Reflection;
using System.Threading.Tasks;
using HarmonyLib;
using MegaCrit.Sts2.Core.Commands;
using MegaCrit.Sts2.Core.Entities.Cards;
using MegaCrit.Sts2.Core.GameActions.Multiplayer;
using MegaCrit.Sts2.Core.Models;
using MegaCrit.Sts2.Core.Models.Powers;

namespace EvolveReplacementMod.Patches;

/// <summary>
/// 原版 IterationPower.AfterCardDrawn：本人抽到 Status 且本回合已抽 Status 数 &lt;= 1 才触发
/// （即“每回合第一次”）。替换为塔1 Evolve 语义：每次抽到 Status 都抽 Amount 张牌。
/// 保留 Flash 动画（PowerModel.Flash 为 protected，经反射调用）。
/// </summary>
[HarmonyPatch(typeof(IterationPower), "AfterCardDrawn")]
public static class IterationPowerAfterCardDrawnPatch
{
    private static readonly MethodInfo? FlashMethod =
        AccessTools.Method(typeof(PowerModel), "Flash");

    private static bool Prefix(
        PlayerChoiceContext choiceContext,
        CardModel card,
        bool fromHandDraw,
        IterationPower __instance,
        ref Task __result)
    {
        if (!ModConfig.IsReplaceIterationEnabled)
        {
            return true;
        }

        __result = EvolveOnCardDrawn(choiceContext, card, __instance);
        return false;
    }

    private static async Task EvolveOnCardDrawn(
        PlayerChoiceContext choiceContext,
        CardModel card,
        IterationPower power)
    {
        if (card.Owner.Creature == power.Owner && card.Type == CardType.Status)
        {
            Flash(power);
            await CardPileCmd.Draw(choiceContext, power.Amount, power.Owner.Player!);
        }
    }

    private static void Flash(IterationPower power)
    {
        try
        {
            FlashMethod?.Invoke(power, null);
        }
        catch
        {
            // Flash 只是表现动画，失败不影响效果
        }
    }
}
