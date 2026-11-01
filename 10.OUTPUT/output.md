# 构建产物与发布包索引

> 最后更新：2026-11-01
> 本目录内容不入库（`.gitignore` 已忽略 `10.OUTPUT/*`，仅保留本文件）。

## 归档产物

| 时间 | 名称 | 版本号 | 大小 | 说明 |
|---|---|---|---|---|
| 2026-11-01 | `02-发布包/EvolveReplacementMod.v1.0.zip` | 1.0 | 1 128 002 B（4 个文件） | GitHub Release `v1.0` 附件一：从游戏 `mods/EvolveReplacementMod/` 打包的安装包（已排除 `.sts2-workshop-uploader` 等以 `.` 开头的项） |
| 2026-11-01 | `02-发布包/EvolveReplacementModSourceCode.zip` | 1.0 | 1 160 349 B（74 个文件） | GitHub Release `v1.0` 附件二：从 `9.SRC/EvolveReplacementMod/` 打包的源码包（排除 `.godot/`、`bin/`、`obj/`、`*.dll`、`*.pck`、`*.pdb`） |

发布页：<https://github.com/Rim-World/STS2Mod-Replace-Iteration-with-Evolve/releases/tag/v1.0>
（该仓库此前没有任何 Release，v1.0 为第一个；标签指向提交 `04c62cb`。）

## 产物构成（安装包内容）

| 文件 | 大小 | 说明 |
|---|---|---|
| `EvolveReplacementMod.dll` | 506 880 B | 14 个 Harmony 补丁 + 内嵌 PNG 兜底资源 |
| `EvolveReplacementMod.pck` | 629 780 B | 卡图 2 档、Buff 图标 2 档、`mod_image.png`、15 语言 × 2 个 JSON（共 35 条） |
| `EvolveReplacementMod.json` | 519 B | mod 清单：`id`、`version=1.0`、`min_game_version=0.107.1`、依赖为空 |
| `EvolveReplacementMod.pdb` | 15 932 B | 调试符号（可选分发） |

## 说明

- 本机构建由 `9.SRC/EvolveReplacementMod/build.ps1` 直接写入游戏目录
  `C:\Game\Steam\steamapps\common\Slay the Spire 2\mods\EvolveReplacementMod\`，仓库内只归档发布用压缩包。
- 游戏目录中的 `.sts2-workshop-uploader/` 是本机创意工坊上传状态（含账号相关状态文件），**永不入库、永不打包**。
