using Microsoft.AspNetCore.Components;

namespace Blazor.IntroJs.Components
{
    public partial class BlazorIntro : ComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string Hint { get; set; }
        [Parameter] public string Text { get; set; }
        [Parameter] public int? Step { get; set; }
        [Parameter] public IntroJsPosition Position { get; set; } = IntroJsPosition.Bottom;
        [Parameter] public bool Floating { get; set; } = false;

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
