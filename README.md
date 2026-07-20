# cec-dotnet

.NET client applications for [libCEC](https://github.com/Pulse-Eight/libcec), the
cross-platform library for controlling CEC-capable HDMI hardware (TVs, AV
receivers, etc.) — primarily via Pulse-Eight's USB-CEC adapter.

This repository contains the managed (C#) apps only. It is **not** standalone: it
is consumed as the `src/dotnet` git submodule of libCEC and builds against the
managed wrapper assemblies that libCEC produces. See
[Relationship to libCEC](#relationship-to-libcec) below.

## What's in here

| Project | Path | Description |
| --- | --- | --- |
| **cec-tray** | `src/LibCecTray` | Windows system-tray application (`cec-tray.exe`) to configure the adapter, map keys to applications (Kodi, Windows Media Center, foreground app), and control connected CEC devices. .NET Framework 4.5, WinForms. |
| **CecSharpTester** (.NET Framework) | `src/CecSharpTester/netfx` | Minimal console sample showing how to open the adapter and log CEC traffic. Targets .NET Framework 4.5. |
| **CecSharpCoreTester** (.NET) | `src/CecSharpTester/netcore` | The same console sample targeting modern .NET (net8.0). |

Both testers compile the shared sample source `src/CecSharpTester/CecSharpClient.cs`
and are the best starting point for learning the API.

## Relationship to libCEC

The C# code here talks to libCEC through a **C++/CLI wrapper**, not directly. The
wrapper is what exposes the managed `CecSharp` namespace (`LibCecSharp`,
`LibCECConfiguration`, `CecCommand`, `CecCallbackMethods`, …).

That wrapper is **not part of this repository** — it lives in the libCEC repo:

- `src/dotnetlib/LibCecSharp` → **`LibCecSharp.dll`** — `CecSharp` namespace for .NET Framework (used by cec-tray and the netfx tester).
- `src/dotnetlib/LibCecSharpCore` → **`LibCecSharpCore.dll`** — the same `CecSharp` namespace for modern .NET (used by CecSharpCoreTester).

These assemblies wrap the native `cec.dll`. The build layers are:

```
cec-tray / CecSharpTester        (this repo, C#)
        │  references
        ▼
LibCecSharp(.Core).dll           (libcec/src/dotnetlib, C++/CLI wrapper — the CecSharp namespace)
        │  wraps
        ▼
cec.dll                          (libcec/src/libcec, native C/C++ engine)
```

The `.csproj` files here reference the wrapper by `HintPath` into libCEC's shared
output folder, e.g.:

```xml
<Reference Include="LibCecSharp">
  <HintPath>..\..\..\..\build\$(Configuration)\$(Platform)\LibCecSharp.dll</HintPath>
</Reference>
```

so the wrapper (and therefore libCEC) must be built **before** these apps.

## Building

This is a **Windows-only** build (the wrappers are C++/CLI). Do not open this
solution and build it on its own first — build it through libCEC's orchestrator,
which builds the native library and the wrappers, generates these projects from
their `.in` templates, and then compiles the apps in the right order.

From a checkout of libCEC:

```
git clone https://github.com/Pulse-Eight/libcec
cd libcec
git submodule update --init --recursive     # checks out this repo into src/dotnet
python windows\create-installer.py           # builds cec.dll, the wrappers, and these apps
```

Useful flags (run from libCEC): `-ni` builds everything but skips packaging the
installer; `-vs` generates the Visual Studio project files for development;
`-a {x64,x86,arm64}` selects the architecture. See libCEC's `windows/` and its
`CLAUDE.md`/README for the full toolchain requirements (Visual Studio, CMake,
Python 3.12+).

Build artifacts land in libCEC's `build\<Configuration>\<Platform>\`:
`cec-tray.exe`, and `net8.0\CecSharpCoreTester.exe`.

> **Note:** several project files here (`*.csproj`, `Properties/AssemblyInfo.cs`)
> are **generated** from `.in` templates by libCEC's cmake step so the version
> number is substituted in. Edit the `.in` file, not the generated file.

Once built, the solution `project/cec-dotnet.sln` can be opened in Visual Studio
for development and debugging.

## Getting a device

The USB-CEC adapter these apps drive is available from Pulse-Eight:
<https://www.pulse-eight.com/>.

## License

Dual-licensed under the GNU GPL v2 (or later) — see `COPYING` — or a commercial
license from Pulse-Eight. Contact <license@pulse-eight.com> for commercial
licensing.
