using Microsoft.AspNetCore.Components;

namespace Blazor.IntroJs.Components
{
    /// <summary>
    /// Wraps inner syntax in a IntroJs step
    /// </summary>
    public partial class BlazorIntro : ComponentBase
    {
        /// <summary>
        /// Title displayed at the top of the tooltip
        /// </summary>
        [Parameter] public string Title { get; set; }
        /// <summary>
        /// Hint Text
        /// </summary>
        [Parameter] public string Hint { get; set; }
        /// <summary>
        /// Hint Positioning on the element
        /// </summary>
        [Parameter] public IntroJsHintPosition HintPosition { get; set; } = IntroJsHintPosition.TopMiddle;
        /// <summary>
        /// Text to display on Intro tooltip
        /// </summary>
        [Parameter] public string Text { get; set; }
        /// <summary>
        /// Step order of this intro
        /// </summary>
        [Parameter] public int? Step { get; set; }
        /// <summary>
        /// Positioning of the popout tooltip in relation to the targeted content
        /// </summary>
        [Parameter] public IntroJsPosition Position { get; set; } = IntroJsPosition.Bottom;
        /// <summary>
        /// Class to identify groups of tooltips to display
        /// </summary>
        [Parameter] public string Class { get; set; }
        /// <summary>
        /// Id to identify this tooltip
        /// </summary>
        [Parameter] public string Id { get; set; }

        /// <summary>
        /// Content to target with the Intro Js tooltip
        /// </summary>
        [Parameter] public RenderFragment ChildContent { get; set; }
    }
}
