# Repository Guidelines

## Project Structure & Module Organization
The repository root contains `sample_wpf_community_tool_kit_mvvm.sln`, NuGet caches under `packages/`, and the WPF app inside `sample_wpf_community_tool_kit_mvvm/`. Core bootstrapping happens in `App.xaml` and `App.xaml.cs`, while `MainWindow.xaml` provides the persistent header with the A/B menu buttons. Screen layouts now live in `Views/ScreenA.xaml` and `Views/ScreenB.xaml`; add future pages to `Views/` with matching code-behind partials. Business logic belongs in `ViewModels/`, and every view model should derive from `ObservableObject` so CommunityToolkit (v7) attributes such as `[ObservableProperty]` and `[RelayCommand]` can be used. Generated artifacts continue to live in `bin/` and `obj/` and should never be checked in.

## Build, Test, and Development Commands
- `dotnet restore sample_wpf_community_tool_kit_mvvm.sln` — restores NuGet packages listed in `packages.config`.
- `dotnet build sample_wpf_community_tool_kit_mvvm.sln -c Release` — compiles the WPF app and runs analyzers; use `-c Debug` for day-to-day work.
- `dotnet run --project sample_wpf_community_tool_kit_mvvm` — launches the shell window so you can toggle between the A/B screens manually.
- `msbuild sample_wpf_community_tool_kit_mvvm.sln /t:Rebuild /p:Configuration=Release` — preferred for CI servers that target .NET Framework tooling bundled with Visual Studio.

## Coding Style & Naming Conventions
Stick to four-space indentation for XAML and C#. Follow .NET naming rules (PascalCase for public members, camelCase for locals and fields) and append `ViewModel` to view-model classes and `Command` to ICommand wrappers. Keep view-specific resources inside each control’s XAML file; shared brushes or themes should move to `App.xaml`. Bind `ContentControl.Content` to view-model instances instead of adding UI logic to code-behind. When using CommunityToolkit attributes, keep the backing fields `private` and let the source generators emit the public properties.

## Testing Guidelines
There is no automated test project yet; add one named `sample_wpf_community_tool_kit_mvvm.Tests` alongside the app. Use xUnit or MSTest, mirror namespaces, and focus on verifying command routing (`ShowScreenACommand`, etc.) plus observable properties (such as `ScreenBViewModel.Greeting`). Adopt the `MethodName_StateUnderTest_ExpectedOutcome` naming pattern and run `dotnet test sample_wpf_community_tool_kit_mvvm.Tests` before opening a PR. Manual validation notes (e.g., “Toggled A/B buttons while app running”) should accompany UI-heavy changes.

## Commit & Pull Request Guidelines
History uses short imperative messages (`add screen views`, `wire header commands`); continue that format and keep the subject under 72 characters. Every pull request should include: summary of the problem, explanation of the MVVM approach, screenshots or recordings if the UI shifts, and explicit test evidence. Link related issues, mention dependency upgrades (especially CommunityToolkit updates), and call out any manual steps reviewers must perform (e.g., clearing `bin/obj` before rebuilding).
