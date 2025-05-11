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

* A single C# project file: `YourFolderName.csproj`
* A `Program.cs` with a minimal “Hello World” template
* No `.sln` (solution) file by default

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

   * Error squiggles
   * IntelliSense completions
   * “Run” / “Debug” code lenses
   * Project-level operations (like Test Explorer)

---

### 👀 If you already have a `.csproj` but no `.sln`

You can skip step 1 and just do:

```bash
dotnet new sln -n MySolution
dotnet sln MySolution.sln add ./YourProjectFolder/YourProject.csproj
```

---

### 🔧 Why this matters

* **Solution file (`.sln`)** is a VS/OmniSharp concept that groups one or more projects.
* When you open a folder without a `.sln`, OmniSharp falls back to “loose” project loading and sometimes misses cross-project references or richer workspace features (squiggles, code lenses, test discovery).

---

Once you’ve got the `.sln` in place, VS Code + CLI will feel just as “feature-complete” as VS 2022 for your console app. Let me know if you hit any snags!
