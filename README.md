# Blazor.IntroJs

Blazor.IntroJs is a [IntroJs](https://introjs.com/) wrapper for Blazor.
It attempts to keep most of the same functionality and interations and also adding in some additional Blazor specific component functionality. 

## Installation

Install the Blazor.IntroJs package from Nuget. (Todo add link once up)

Add the following to your `_Host.cshtml` (Blazor Server) or `index.html` (WASM)

```html
<link href="https://unpkg.com/intro.js/minified/introjs.min.css" rel="stylesheet" />
    ...
<script src="https://unpkg.com/intro.js/minified/intro.min.js"></script>
<script src="_content/Blazor.IntroJs/blazor.intro.js"></script>
```


Add the following to your `_Imports.razor`

```csharp
@using Blazor.IntroJs.Components
```

Setup IntroJs for Dependency Injection using the built-in extention method helpers.
There are several overloads for customizing your IntroJs options.


```csharp
services.AddIntroJs(); // In Startup.cs for Blazor Server
or
builder.Services.AddIntroJs(); // In Program.cs for WASM
```

## Component Setup

Similar to normal IntroJs usage, there are several ways to initalize intros and hints. 

1. Setup using the normal IntroJs html Attributes attached to straight html or components that directly use extra attributes such as the MudCard from MudBlazor.

```html
    <MudCard Class="mb-2 onlyThese" 
             data-intro="Look at this Story" 
             data-title="Now with Title" 
             data-hint="Hint, Hint">
```

2. Setup using Blazor Components that can wrap what you want to include in the intro or hint.

```html
    <BlazorIntro Text="Look at this Story" 
                 Title="Now with Title" 
                 Hint="Hint, Hint"
                 Step="3">
        <MudCard>
            <MudCardContent>
                <MudText>Story Time</MudText>
                <MudText Typo="Typo.body2">The quick, brown fox jumps over a lazy dog.</MudText>
            </MudCardContent>
        </MudCard>
    </BlazorIntro>
```

3. Setup via Code. 
Can be setup using an `IntroJsOptions` class or a json string that will be deserialized into an options object.
Follows the same Json structure as standard IntroJs.

```csharp
    private async Task ShowIntro()
    {
        string json = "";
        IntroJs.SetOptions(options =>
        {
            options.Steps = new List<IntroJsStep>();
            options.Steps.Add(new IntroJsStep() { Element = "#t1", Intro = "Test Manual Setup 1", Title = "Test Title" });
            options.Steps.Add(new IntroJsStep() { Element = "#t2", Intro = "Test Manual Setup 2", Title = "Test Title" });
            options.Steps.Add(new IntroJsStep() { Element = "#t3", Intro = "Test Manual Setup 3", Title = "Test Title" });
            options.Steps.Add(new IntroJsStep() { Intro = "Test Floating Element", Title = "Test Title" });

            json = System.Text.Json.JsonSerializer.Serialize(options);
        });

        await IntroJs.SetOptions(json).Start();
    }
```

### Code Interaction

To interact with IntroJs within a component inject an instance of `IntroJsInterop`.

In your *.razor:
```csharp
@inject IntroJsInterop IntroJs
```

or in your code behind *.razor.cs. 

```csharp
[Inject] protected IntroJsInterop IntroJs { get; set; }
```

Interactions with this IntroJs object were attempted to keep as close to the Javascript usage of IntroJs as possible.
So to just kick off all Intros currently on the page across all components simply:

```csharp
await introJs.Start();
```

**NOTE:** `IntroJsInterop` uses an internal instance of `IJSRuntime` so it has the same limitations as that in terms of Component Lifecycle.
Depending on Server or WASM Javascript Interop may or may not be available during `OnInitialized` or `OnAfterRender`.

### Cleanup

In order for Blazor to clean up hints and other Javascript artifacts it is best to have your component implement `IAsyncDisposable`.

```csharp
    public async ValueTask DisposeAsync()
    {
        await IntroJs.DisposeAsync();
    }
```

### BlazorIntro Component

The `<BlazorIntro>` component can receive the following parameters  and will attach intros and hints to the ChildContent.
If `Text` is present then it will render as an intro.
If `Hint` is present then it will render as a hint.
Both can be included to render as both.

```csharp
    [Parameter] public string Title { get; set; }
    [Parameter] public string Hint { get; set; }
    [Parameter] public IntroJsHintPosition HintPosition { get; set; } = IntroJsHintPosition.TopMiddle;
    [Parameter] public string Text { get; set; }
    [Parameter] public int? Step { get; set; }
    [Parameter] public IntroJsPosition Position { get; set; } = IntroJsPosition.Bottom;
    [Parameter] public string Class { get; set; }
```

Effectively boils down to creating a div with those html attributes.

```html
    <div data-intro="@Text"
         data-hint="@Hint"
         data-hintPosition="@HintPosition.ConvertToString()"
         data-step="@Step"
         data-title="@Title"
         data-position="@(Position.ToString().ToLower())"
         class="@Class"
         id="@Id">
        @ChildContent
    </div>
```

### Events

IntroJs can also recieve all the same events that IntroJs will fire within JavaScript.

Events:
 - OnComplete
 - OnAfterChange
 - OnBeforeChange
 - OnChange
 - OnBeforeExit
 - OnExit
 - OnHintClick
 - OnHintClose
 - OnHintsAdded

# Known Issues
- Starting with a certain class does not work properly.
- HideHints() can be inconsistent and cannot be added back.
  - RemoveHints() seems to work remove the hints and then allows them to be added back later.
