using Microsoft.AspNetCore.Components;

namespace Blazor.IntroJs.Components
{
    public partial class BlazorIntro : ComponentBase
    {
        [Parameter] public string Title { get; set; }
        [Parameter] public string Hint { get; set; }
        [Parameter] public IntroJsHintPosition HintPosition { get; set; } = IntroJsHintPosition.TopMiddle;
        [Parameter] public string Text { get; set; }
        [Parameter] public int? Step { get; set; }
        [Parameter] public IntroJsPosition Position { get; set; } = IntroJsPosition.Bottom;
        [Parameter] public string Class { get; set; }

        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
