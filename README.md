# STS2Mod-进化

> 把《杀戮尖塔 2》故障机器人的「迭代」整卡替换为《杀戮尖塔 1》铁甲战士的「进化」。
> Replaces The Defect's "Iteration" card in Slay the Spire 2 with the Ironclad's "Evolve" card from Slay the Spire 1.

- 当前版本：**1.0**（mod 清单 `version=1.0`）
- 游戏版本：default 0.107.1 / public beta 0.110.x（清单 `min_game_version=0.107.1`）
- 仓库：<https://github.com/Rim-World/STS2Mod-Replace-Iteration-with-Evolve>
- 许可：MIT（`LICENSE`，Copyright (c) 2026 戏剧性机器）

## 功能

- **触发条件**：原版「迭代」每回合只在**第一次**抽到状态牌时触发；本 mod 改为**每次**抽到状态牌都触发（塔1 语义）。
- **数值**：原版基础抽 2 张、升级抽 3 张；本 mod 改为塔1 的**基础 1 张、升级 2 张**。
- **整卡呈现**：卡名改「进化」，卡面文本、卡图（1000×760 与 250×190 两档）、Buff 名称、Buff 描述、
  Buff 智能描述、Buff 图标（64×64 与 256×256 两档）全部换为塔1 样式。
- **15 种语言**：deu / eng / esp / fra / ita / jpn / kor / pol / ptb / rus / spa / tha / tur / zhs / zht，
  文本取自塔1 原文（详见 `3.DOCS/003-T`）。
- **不改卡池**：直接在原卡模型上修改，不新增卡牌、不禁用旧卡；mod 开启时历史记录里的「迭代」一并呈现为「进化」，
  关闭后恢复原状。

费用、类型（Power）、稀有度（Uncommon）、目标（自身）与塔1 进化完全一致，未作修改。

## 兼容性

- **不依赖任何基础 mod**：不依赖 BaseLib / RitsuLib，清单 `dependencies: []`。
- **单 DLL 通吃 107 / 110**：两版 `Iteration` / `IterationPower` 反编译逐行一致，依赖 API 签名一致
  （取证见 `3.DOCS/001-T`）。
- **低冲突**：无新增卡牌、无自定义 Power 类、无全局状态；本地化键使用模组专属前缀 `RE_EVOLVE.*` / `RE_EVOLVE_POWER.*`。
- **不保证**与盗版、修改版、移动版、老旧版本或冷门次级 mod 的兼容性。
- 已知边界：`IterationPower` 目前只被「迭代」使用；若未来其他卡牌复用该 Power，本 mod 也会同样按「进化」语义触发。

## 安装

1. 构建产物为 `EvolveReplacementMod.dll` + `EvolveReplacementMod.pck` + `EvolveReplacementMod.json`
   （`EvolveReplacementMod.pdb` 为可选调试符号）。
2. 整个文件夹放到 `<游戏目录>/mods/EvolveReplacementMod/`（**放文件夹本身，不要只放内部文件**）。
3. 启动游戏。日志出现下面两行即表示补丁挂载成功：

   ```
   EvolveReplacementMod: loading...
   EvolveReplacementMod: Harmony patches applied (Iteration -> Evolve)
   ```

4. 从 110 降回 107 时请先结束或放弃当前 run，否则游戏会判定存档版本过新并改名 `.FUT.corrupt`
   （原因与对策见 `3.DOCS/002-T`）。

## 构建

```powershell
cd 9.SRC\EvolveReplacementMod
pwsh .\build.ps1
```

`build.ps1` 依次执行：`dotnet build EvolveReplacementMod.csproj -c Debug` → Godot 4.5.1 mono
headless `--import` → `--export-pack "Windows Desktop"` 生成 pck → 拷贝 `dll` / `pdb` / `json`
到游戏 `mods/EvolveReplacementMod/`。

依赖：.NET SDK 9.0、Godot 4.5.1 mono（`Godot.NET.Sdk/4.5.1`、`net9.0`）、游戏自带
`data_sts2_windows_x86_64/sts2.dll` 与 `0Harmony.dll`。本机路径写在 `EvolveReplacementMod.csproj` 与
`build.ps1` 顶部，换机器需先改这两处。

## 目录结构

```
1.ADR/          决策记录（ADR.md 索引）
2.PLANS/        施工计划（PLANS.md 索引）
3.DOCS/         知识与译文（DOCS.md 索引）
4.SDD/          软件设计（SDD.md 索引）
5.ChangeLog/    版本日志分片（ChangeLog.md 索引）
9.SRC/          源码（Godot + C# 工程）
10.OUTPUT/      构建产物与发布包（output.md 索引，不入库）
PRIVACY/        机密信息（PRIVACY.md 索引，不入库）
TMP/            临时与过程文件（TMP.md 索引，不入库）
TOOLS/          工具与自写脚本（TOOLS.md 索引）
description/    创意工坊文案（中/英）
pics/           封面与素材图
```

## 文档索引

- 决策：[1.ADR/001-迭代替换为进化的整卡替换.md](1.ADR/001-迭代替换为进化的整卡替换.md)
- 计划：[2.PLANS/001-G-迭代替换为进化施工计划.md](2.PLANS/001-G-迭代替换为进化施工计划.md)
- 取证笔记：[3.DOCS/001-T-进化替换工程取证笔记.md](3.DOCS/001-T-进化替换工程取证笔记.md)
- 存档兼容：[3.DOCS/002-T-版本切换导致存档损坏根因.md](3.DOCS/002-T-版本切换导致存档损坏根因.md)
- 15 语言译文：[3.DOCS/003-T-进化15语言译文与转换规则.md](3.DOCS/003-T-进化15语言译文与转换规则.md)
- 设计：[4.SDD/001-总体设计.md](4.SDD/001-总体设计.md)
- 版本日志：[5.ChangeLog/001-1.0-2026-08-15.md](5.ChangeLog/001-1.0-2026-08-15.md)、[CHANGELOG.md](CHANGELOG.md)

## 致谢

本 mod 使用 Codex（桌面版）+ DeepSeek V4 Flash（0731 正式版）完成，感谢梁圣。

感谢《杀戮尖塔 2》制作组为了方便玩家制作 mod 所做的努力。

感谢 Baselib 制作者提供的文档，感谢 GitHub 项目 [jiegec/STS2RevertAnthony](https://github.com/jiegec/STS2RevertAnthony)
提供的源码参考，以及同系列替换 mod（幻杀 / 死割 / 尸爆术 / 回收）提供的工程骨架。

## 反馈

开源地址：<https://github.com/Rim-World/STS2Mod-Replace-Iteration-with-Evolve>，
欢迎在创意工坊评论区或 GitHub Issues 提出意见与反馈。
