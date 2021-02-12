using System.Collections.Generic;

namespace Blazor.IntroJs
{
    /// <summary>
    /// IntroJs Options
    /// </summary>
    public class IntroJsOptions
    {
        /// <summary>
        /// Next button label in tooltip box
        /// </summary>
        public string NextLabel { get; set; } = "Next";
        /// <summary>
        /// Previous button label in tooltip box
        /// </summary>
        public string PrevLabel { get; set; } = "Back";
        /// <summary>
        /// Skip button label in tooltip box
        /// </summary>
        public string SkipLabel { get; set; } = "×";
        /// <summary>
        /// Done button label in tooltip box
        /// </summary>
        public string DoneLabel { get; set; } = "Done";
        /// <summary>
        /// Hide previous button in the first step? 
        /// Otherwise, it will be disabled button.
        /// </summary>
        public bool HidePrev { get; set; } = false;
        /// <summary>
        /// Hide next button in the last step? 
        /// Otherwise, it will be disabled button (note{get;set;} = this will also hide the "Done" button)
        /// </summary>
        public bool HideNext { get; set; } = false;
        /// <summary>
        /// Change the Next button to Done in the last step of the intro? 
        /// Otherwise, it will render a disabled button
        /// </summary>
        public bool NextToDone { get; set; } = true;
        /// <summary>
        /// Default tooltip box position
        /// </summary>
        public string TooltipPosition { get; set; } = "bottom";
        /// <summary>
        /// Next CSS class for tooltip boxes
        /// </summary>
        public string TooltipClass { get; set; } = "";
        /// <summary>
        /// CSS class that is added to the helperLayer
        /// </summary>
        public string HighlightClass { get; set; } = "";
        /// <summary>
        /// Close introduction when pressing Escape button?
        /// </summary>
        public bool ExitOnEsc { get; set; } = true;
        /// <summary>
        /// Close introduction when clicking on overlay layer?
        /// </summary>
        public bool ExitOnOverlayClick { get; set; } = true;
        /// <summary>
        /// Show step numbers in introduction?
        /// </summary>
        public bool ShowStepNumbers { get; set; } = false;
        /// <summary>
        /// Let user use keyboard to navigate the tour?
        /// </summary>
        public bool KeyboardNavigation { get; set; } = true;
        /// <summary>
        /// Show tour control buttons?
        /// </summary>
        public bool ShowButtons { get; set; } = true;
        /// <summary>
        /// Show tour bullets?
        /// </summary>
        public bool ShowBullets { get; set; } = true;
        /// <summary>
        /// Show tour progress?
        /// </summary>
        public bool ShowProgress { get; set; } = false;
        /// <summary>
        /// Scroll to highlighted element?
        /// </summary>
        public bool ScrollToElement { get; set; } = true;
        /// <summary>
        /// Should we scroll the tooltip or target element?
        /// Options are: = 'element' or 'tooltip'
        /// </summary>
        public string ScrollTo { get; set; } = "element";
        /// <summary>
        /// Padding to add after scrolling when element is not in the viewport (in pixels)
        /// </summary>
        public int ScrollPadding { get; set; } = 30;
        /// <summary>
        /// Set the overlay opacity
        /// </summary>
        public double OverlayOpacity { get; set; } = 0.5;
        /// <summary>
        /// To determine the tooltip position automatically based on the window.width/height
        /// </summary>
        public bool AutoPosition { get; set; } = true;
        /// <summary>
        /// Precedence of positions, when auto is enabled
        /// </summary>
        public string[] PositionPrecedence { get; set; } = { "bottom", "top", "right", "left" };
        /// <summary>
        /// Disable an interaction with element?
        /// </summary>
        public bool DisableInteraction { get; set; } = false;
        /// <summary>
        /// Set how much padding to be used around helper element
        /// </summary>
        public int HelperElementPadding { get; set; } = 10;
        /// <summary>
        /// Default hint position
        /// </summary>
        public string HintPosition { get; set; } = "top-middle";
        /// <summary>
        /// Hint button label
        /// </summary>
        public string HintButtonLabel { get; set; } = "Got it";
        /// <summary>
        /// Adding animation to hints?
        /// </summary>
        public bool HintAnimation { get; set; } = true;
        /// <summary>
        /// Additional classes to put on the buttons
        /// </summary>
        public string ButtonClass { get; set; } = "introjs-button";
        /// <summary>
        /// Additional classes to put on progress bar
        /// </summary>
        public bool ProgressBarAdditionalClass { get; set; } = false;
        /// <summary>
        /// List of Steps that will be included in the Intro
        /// </summary>
        public List<IntroJsStep> Steps { get; set; }
        /// <summary>
        /// List of Hints that will be included in the Intro
        /// </summary>
        public List<IntroJsHint> Hints { get; set; }


        /// <summary>
        /// Creates a shallow copy of the current Options object
        /// </summary>
        /// <returns></returns>
        internal IntroJsOptions Clone()
        {
            return (IntroJsOptions)MemberwiseClone();
        }
    }
}
