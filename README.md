# cec-dotnet

.NET client applications for [libCEC](https://github.com/Pulse-Eight/libcec), the
cross-platform library for controlling CEC-capable HDMI hardware (TVs, AV
receivers, etc.) — primarily via Pulse-Eight's USB-CEC adapter.

This repository contains the managed (C#) apps only. It is **not** standalone: it
is consumed as the `src/dotnet` git submodule of libCEC and builds against the
`LibCecSharp` binding that libCEC produces. See
[Relationship to libCEC](#relationship-to-libcec) below.

## What's in here

| Project | Path | Description |
| --- | --- | --- |
| **cec-tray** | `src/LibCecTray` | Windows system-tray application (`cec-tray.exe`) to configure the adapter, map keys to applications (Kodi, Windows Media Center, foreground app), and control connected CEC devices. WinForms, `net8.0-windows` (Windows only). |
| **CecSharpTester** | `src/CecSharpTester/netcore` | Minimal console sample showing how to open the adapter and log CEC traffic. Targets `net8.0`, so it runs anywhere the binding does. |

The tester compiles the shared sample source `src/CecSharpTester/CecSharpClient.cs`
and is the best starting point for learning the API.

## Relationship to libCEC

The C# code here talks to libCEC through the **`LibCecSharp` binding**, not
directly. The binding exposes the managed `CecSharp` namespace (`LibCecSharp`,
`LibCECConfiguration`, `CecCommand`, `CecCallbackMethods`, …).

That binding is **not part of this repository** — it lives in the libCEC repo at
`src/dotnetlib` and produces **`LibCecSharp.dll`**. It is a single, pure-C#
assembly that binds the native library through P/Invoke over libCEC's C API,
targets **net8.0**, and builds with the .NET SDK (no MSVC `/clr`). It replaced two
Windows-only C++/CLI wrappers (`LibCecSharp` for .NET Framework and
`LibCecSharpCore` for net8.0); both apps here now reference the one assembly.

The build layers are:

```
cec-tray / CecSharpTester        (this repo, C#)
        │  references
        ▼
LibCecSharp.dll                  (libcec/src/dotnetlib — pure C# P/Invoke binding, the CecSharp namespace)
        │  P/Invoke
        ▼
cec.dll / libcec.so              (libcec/src/libcec, native C/C++ engine)
```

The `.csproj` files here reference the binding by `HintPath` into libCEC's shared
output folder, e.g.:

```xml
<Reference Include="LibCecSharp">
  <HintPath>..\..\..\..\build\$(Configuration)\$(Platform)\net8.0\LibCecSharp.dll</HintPath>
</Reference>
```

so the binding (and therefore libCEC) must be built **before** these apps.

## Building

`cec-tray` is Windows-only (WinForms); the `CecSharpTester` console sample is
`net8.0` and runs anywhere. Build them through libCEC's orchestrator, which builds
the native library and the `LibCecSharp` binding, generates these projects from
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

Build artifacts land in libCEC's `build\<Configuration>\<Platform>\net8.0\`:
`cec-tray.exe` and `CecSharpTester.exe`, alongside `LibCecSharp.dll`.
Running them needs the [.NET 8 Desktop Runtime](https://dotnet.microsoft.com/download/dotnet/8.0)
(the installer offers to install it).

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
