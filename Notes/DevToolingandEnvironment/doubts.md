# Tooling Doubts

## Question 1

I followed the steps on the link: `https://learn.microsoft.com/en-gb/training/modules/install-configure-visual-studio-code/7-exercise-create-build-run-app` and used the following commands in a folder I had already created:

```bash
dotnet new console
dotnet build
dotnet run
```

I did this in Visual Studio Code editor(not the VS 2022 IDE).
One noticeable difference was the absence of a .sln file because of which my Visual Studio Code editor also doesn't show some features like squiggly lines under errors.

So, my question is what is the reason the combo of VS Code Editor & CLI didn't create a .sln file and can they do it the same as VS 2022 IDE? What have I done wrong or missed?

## Answer 1

When you run

```bash
dotnet new console
dotnet build
dotnet run
```

in an empty folder, the CLI’s **Console** template gives you:

- A single C# project file: `YourFolderName.csproj`
- A `Program.cs` with a minimal “Hello World” template
- No `.sln` (solution) file by default

That’s **by design**—the .NET CLI keeps things lightweight. Visual Studio 2022’s project wizards go a little further for you:

1. They **auto-generate** a `.sln`
2. They scaffold `launch.json` / `tasks.json` for debugging and IntelliSense
3. They wire up the folder → solution → project relationships so the C# extension (OmniSharp) shows you squiggles, IntelliSense, Test Explorer, etc.

---

## ✅ How to get a `.sln` (and full VS-Code experience) with the CLI

1. **Create the console project**

   ```bash
   mkdir MyApp
   cd MyApp
   dotnet new console
   ```

2. **Create a solution file**

   ```bash
   dotnet new sln -n MyApp
   ```

   This produces `MyApp.sln` next to your `MyApp.csproj`.

3. **Add your project to the solution**

   ```bash
   dotnet sln add ./MyApp.csproj
   ```

4. **Open the folder in VS Code**

   ```bash
   code .
   ```

   Now OmniSharp will see `MyApp.sln`, load the project correctly, and give you:

   - Error squiggles
   - IntelliSense completions
   - “Run” / “Debug” code lenses
   - Project-level operations (like Test Explorer)

---

### 👀 If you already have a `.csproj` but no `.sln`

You can skip step 1 and just do:

```bash
dotnet new sln -n MySolution
dotnet sln MySolution.sln add ./YourProjectFolder/YourProject.csproj
```

---

### 🔧 Why this matters

- **Solution file (`.sln`)** is a VS/OmniSharp concept that groups one or more projects.
- When you open a folder without a `.sln`, OmniSharp falls back to “loose” project loading and sometimes misses cross-project references or richer workspace features (squiggles, code lenses, test discovery).

---

Once you’ve got the `.sln` in place, VS Code + CLI will feel just as “feature-complete” as VS 2022 for your console app. Let me know if you hit any snags!

## Question 2

On an unrelated note, how can i check my c# version like 7.3 or 12. I ask this because when I try to initialize an array using [], error says: "Feature 'collection expressions' is not available in C# 7.3. Please use language version 12.0 or greater." I did this in a "Program.cs" file, that was created in a project which is a Console App(.NET Framework). What my mentor did to avoid this issue was to use a new project instead that is also a Console App(but the regular one(if I may call it so, not the .NET Framework one)) and used .NET Framework 4.8 instead of the one we used previously i.e, 4.7.2. Was the best was to solve this problem? If yes, why? If not, what else. What's the generalisation to learn here?

## Answer 2

### 📋 Summary

C# language features are gated by the **language version**, which the compiler picks **by default** based on your project’s **Target Framework** (TFM). A **Console App (.NET Framework)** always defaults to C# 7.3, so you can’t use C# 12-only syntax like collection expressions until you either:

1. **Target a newer TFM** that supports C# 12 (e.g. net8.0),
2. **Explicitly bump the `LangVersion`** in your `.csproj`, or
3. **Create a new project** using a template that already targets net8.0.

Your mentor’s “fix” was effectively option 1—starting a **regular** Console App (i.e. .NET 8+) instead of the **.NET Framework** template—so the default language version jumped high enough to include collection expressions.

---

### 1. How to **check** your C# language version

#### In Visual Studio (or VS 2022 IDE)

1. **Right-click** your project in **Solution Explorer → Properties**.
2. Go to the **Build** tab and click **Advanced…**.
3. The **Language version** dropdown shows exactly which C# version the compiler is using (for example “default” → 7.3). ([Medium][1])

#### In the .NET SDK (via CLI)

```bash
dotnet msbuild /t:ShowLanguageVersion
```

This prints the resolved `LangVersion`. Or inspect the `.csproj` directly for a `<LangVersion>` element. ([Microsoft Learn][2])

#### OmniSharp / VS Code

When you open a `.sln` or `.csproj`, OmniSharp’s output window will log the detected language version early in its startup messages.

---

### 2. Why **C# 7.3** by default on .NET Framework

The C# compiler picks a **default language** based on your TFM so that you don’t accidentally use features your runtime can’t support. Per Microsoft’s table:

| Target Framework              | Default C# version |                        |
| ----------------------------- | ------------------ | ---------------------- |
| .NET Framework (all versions) | **C# 7.3**         |                        |
| .NET Core 2.x                 | C# 7.3             |                        |
| .NET Core 3.x                 | C# 8.0             |                        |
| .NET 5.x                      | C# 9.0             |                        |
| .NET 6.x                      | C# 10              |                        |
| .NET 7.x                      | C# 11              |                        |
| .NET 8.x                      | C# 12              |                        |
| .NET 9.x                      | C# 13              | ([Microsoft Learn][2]) |

Since **Console App (.NET Framework)** projects target a .NET Framework TFM, they never get beyond C# 7.3 on “default.” That’s why `[]` collection expressions (a C# 12 feature) failed.

---

### 3. Your mentor’s workaround: New Console App → .NET 8+

By choosing the **“Console App”** template (instead of “Console App (.NET Framework)”), the project’s TFM became **net8.0**, whose default C# version is **12**—so collection expressions compile out of the box.

- **Was this the “best” fix?**

  - **Yes**, if you intend to use C# 12+ features. Targeting net8.0 aligns your compiler and runtime, ensuring both understand the new syntax ([Microsoft Learn][2]).
  - It also gives you the latest runtime performance and APIs.

---

### 4. Alternative approaches

#### A) **Retarget** an existing project

1. Open YourProject.csproj
2. Change:

   ```xml
   <TargetFramework>net472</TargetFramework>
   ```

   to:

   ```xml
   <TargetFramework>net8.0</TargetFramework>
   ```

3. Run `dotnet restore && dotnet run` ([Microsoft Learn][2])

#### B) **Override** only the language version

Add inside your `<PropertyGroup>`:

```xml
<LangVersion>12.0</LangVersion>
```

This forces C# 12 even if your TFM default is lower, but **use with caution**—you may invoke APIs or runtime behavior not present in your older framework. ([Microsoft Learn][2])

#### C) Pin SDK with `global.json`

In your solution root:

```jsonc
{
  "sdk": { "version": "8.0.100" }
}
```

Ensures `dotnet` uses the .NET 8 SDK (and thus C# 12 defaults) for this workspace. ([Microsoft Learn][2])

---

### 5. General lesson

> **“Your C# version = function(TFM, explicit `<LangVersion>`, SDK pinned).”**
> Always align your **target framework** with the **language features** you want. If you need brand-new syntax, either retarget to a newer .NET version or explicitly bump `LangVersion`, keeping in mind runtime compatibility.

This pattern applies whenever you see “Feature ... is not available in C# X.Y. Please use language version N.M or greater.” Check your **project’s TFM**, adjust it or override the language version, and restore/build again.

---

[1]: https://nuthanmurarysetty.medium.com/how-to-check-the-c-version-and-net-framework-being-used-in-their-visual-studio-projects-1374d16841c1?utm_source=chatgpt.com "How to check the C# version and .net framework being used in their ..."
[2]: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/language-versioning?utm_source=chatgpt.com "Language versioning - C# reference - Learn Microsoft"

## Question 3

Are there any regular/mainstream popular mouse shortcuts/ VS Code Text Editor(not the Visual Studio 2022 IDE) GUI options to replicate `dotnet run` & `dotnet build` without doing any difficult configuration changes?

## Answer 3

Yes, in Visual Studio Code (VS Code), you can execute `dotnet build` and `dotnet run` commands using GUI options and mouse interactions, without delving into complex configurations. Here's how:

---

## 🖱️ GUI Options to Build and Run C# Projects in VS Code

### 1. **Using the Run and Debug Panel**

- **Open the Run and Debug Panel**:

  - Click on the **Run and Debug** icon in the Activity Bar on the side of the window.
  - Alternatively, use the menu: `View` > `Run`.

- **Start Debugging**:

  - Click the green **Run** button (▶️) at the top of the panel.
  - This action will build and run your project.

_Note_: If it's your first time running the project, VS Code may prompt you to install necessary assets or configure the debugger. Accepting these prompts will set up the required configurations.

### 2. **Using the Command Palette**

- **Open the Command Palette**:

  - Press `Ctrl+Shift+P` (or `F1`) to open the Command Palette.

- **Run Build Task**:

  - Type `Run Build Task` and select it.
  - This will execute the build process for your project.

- **Run Without Debugging**:

  - Type `Run Without Debugging` and select it.
  - This will run your project without attaching the debugger.

### 3. **Using the Terminal Menu**

- **Access the Terminal Menu**:

  - Click on `Terminal` in the top menu bar.

- **Run Build Task**:

  - Select `Run Build Task` from the dropdown.
  - This will initiate the build process.

- **Run Without Debugging**:

  - Select `Run Without Debugging` to execute your project without the debugger.

---

## ⚙️ Setting Up Tasks for Build and Run (Optional)

For more streamlined operations, you can define custom tasks:

1. **Create a `tasks.json` File**:

   - Navigate to `Terminal` > `Configure Tasks` > `Create tasks.json file from template`.
   - Choose `.NET Core` as the template.

2. **Define Build and Run Tasks**:

   - In the `tasks.json` file, you can define tasks for building and running your project.
   - This allows you to execute these tasks via the Command Palette or assign them to keyboard shortcuts.

_Note_: While setting up tasks provides more control, it's optional for basic build and run operations.

---

## 🧩 Ensure Necessary Extensions Are Installed

To enhance your C# development experience in VS Code:

- **Install the C# Dev Kit Extension**:

  - Go to the Extensions view (`Ctrl+Shift+X`).
  - Search for `C# Dev Kit` and install it.

This extension provides features like IntelliSense, debugging, and project management tailored for C# development.

---

By utilizing these GUI options, you can efficiently build and run your C# projects in VS Code without relying solely on terminal commands.
