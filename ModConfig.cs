namespace EvolveReplacementMod;

/// <summary>
/// 替换功能固定开启（已移除 RitsuLib 实时开关与形状守卫/API 检测，补丁始终生效）。
/// </summary>
public static class ModConfig
{
    public static bool IsReplaceIterationEnabled => true;
}
