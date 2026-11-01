# 工具与自写脚本索引

> 最后更新：2026-11-01

## 外部工具依赖

| 时间 | 工具 | 版本 | 用途 | 来源 | 安装方式 |
|---|---|---|---|---|---|
| 2026-08 | .NET SDK | 9.0.320 | 编译 C#（MSIL 目标） | 本机 `C:\DevTools` 全局环境 | 全局安装 |
| 2026-08 | Godot（.NET/mono） | 4.5.1-stable | 资源导入（`--import`）与 pck 打包（`--export-pack`） | 本机 `C:\Godot&GDRE\Godot_v4.5.1-stable_mono_win64\` | 免安装 |
| 2026-08 | HarmonyLib | 随游戏 | 运行时方法补丁（`0Harmony.dll`） | 游戏目录 `data_sts2_windows_x86_64/0Harmony.dll` | 随游戏提供，`Private=false` 引用 |
| 2026-08 | GDRE Tools | 2.6.0 | 反编译取证（塔1 素材与 107/110 源码比对） | 本机 `C:\Godot&GDRE\GDRE_tools-v2.6.0-windows\` | 免安装 |
| 2026-11 | git | 2.56.0.windows.4 | 版本管理（仓库级 `core.autocrlf=true`） | 系统 | 全局安装 |
| 2026-11 | GitHub CLI（`gh`） | 2.97.0 | 创建 Release 与上传资产 | 系统 | 全局安装 |

## 自写脚本

| 时间 | 脚本 | 用途 | 依赖 | 说明 |
|---|---|---|---|---|
| 2026-08 | `9.SRC/EvolveReplacementMod/build.ps1` | 一键构建：`dotnet build` → Godot 导入 → 导出 pck → 拷贝到游戏 `mods/EvolveReplacementMod/` | dotnet 9、Godot 4.5.1 mono、游戏本体 | 属于源码工程的一部分，故留在 `9.SRC/` 内 |

`TOOLS/scripts/` 目前为空：本项目未产生独立于工程之外的自写脚本。
