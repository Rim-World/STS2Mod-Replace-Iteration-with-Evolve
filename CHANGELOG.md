# 更新日志

本文件记录本项目所有重要变更。
格式参考 [Keep a Changelog](https://keepachangelog.com/zh-CN/1.1.0/)，版本号遵循语义化版本。
分版本的详细施工记录（含开发人员反馈、失败教训与提交编号）见 `5.ChangeLog/`。

## [1.0] - 2026-08-15

### 新增

- 卡名替换：`Iteration` → 「进化」，15 个语言目录统一改用 `RE_EVOLVE.title`。
- 卡面文本替换为塔1 原文，动态数值走 `{IterationPower:diff()}` 与单复数语法（15 个语言目录）。
- 卡图替换为塔1 原版立绘，1000×760 与 250×190 两档。
- Buff 名称、描述、智能描述替换为塔1 EvolvePower 文案（`RE_EVOLVE_POWER.*`）。
- Buff 图标替换为塔1 图集图标，64×64 与 256×256 两档。
- Godot + C# 工程、`build.ps1` 构建链、`export_presets.cfg`（35 个导出条目）、创意工坊文案与封面图。

### 变更

- 触发条件：由原版「每回合第一次抽到状态牌」改为「每次抽到状态牌」（塔1 语义，可连锁）。
- 数值：由 2 / 3（基础 / 升级）改为塔1 的 1 / 2。
- mod 清单定稿：`version` 由 `0.1.0` 改为 `1.0`，`author` 由占位符改为正式笔名。

### 修复

- 移除开发期的形状守卫与 API 存在性检测：删除 `IterationShapeGuard.cs`，`ModConfig.IsReplaceIterationEnabled` 恒为 `true`，
  `ModEntry` 简化为直接 `PatchAll`。
- mod 封面由 420×420 纯色占位换为用户提供的 `pics/Evolve_small.png`。

### 已知问题

- 仓库内没有 beta 110 实机验证与 default 107 自测的通过记录，连锁抽牌与升级预览仅有静态验证。
- `assets/evolve_small.png` 被内嵌进 DLL 但没有代码引用（小图走 pck），属冗余资源。
- `IterationPower` 若被其它卡牌复用，会同样按「进化」语义触发。

## [0.1.0] - 2026-08-10

### 新增

- 首个可安装构建：14 个 Harmony 补丁 + 15 语言本地化 + 塔1 素材，安装到 `mods/EvolveReplacementMod/`。
- 补充：2026-08-11 同日修订（去守卫、换封面）后重新构建安装。

## 未发布

### 变更

- 仓库整理：源码移入 `9.SRC/EvolveReplacementMod/`，文档按 AGENTS.md 十目录规范重新编号，
  新建 `4.SDD`、`5.ChangeLog` 与各目录索引。未改动任何代码文件。（提交 `3eb62ec`）
- 新建 GitHub Release `v1.0`，资产为安装包与源码包。
