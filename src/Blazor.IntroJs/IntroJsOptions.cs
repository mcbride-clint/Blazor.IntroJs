using System;
using System.Collections.Generic;

namespace Blazor.IntroJs
{
    public class IntroJsOptions
    {
        /* Next button label in tooltip box */
        public string NextLabel { get; set; } = "Next";
        /* Previous button label in tooltip box */
        public string PrevLabel { get; set; } = "Back";
        /* Skip button label in tooltip box */
        public string SkipLabel { get; set; } = "×";
        /* Done button label in tooltip box */
        public string DoneLabel { get; set; } = "Done";
        /* Hide previous button in the first step? Otherwise, it will be disabled button. */
        public bool HidePrev { get; set; } = false;

        /* Hide next button in the last step? Otherwise, it will be disabled button (note{get;set;} = this will also hide the "Done" button) */
        public bool HideNext { get; set; } = false;
        /* Change the Next button to Done in the last step of the intro? otherwise, it will render a disabled button */
        public bool NextToDone { get; set; } = true;
        /* Default tooltip box position */
        public string TooltipPosition { get; set; } = "bottom";
        /* Next CSS class for tooltip boxes */
        public string TooltipClass { get; set; } = "";
        /* CSS class that is added to the helperLayer */
        public string HighlightClass { get; set; } = "";
        /* Close introduction when pressing Escape button? */
        public bool ExitOnEsc { get; set; } = true;
        /* Close introduction when clicking on overlay layer? */
        public bool ExitOnOverlayClick { get; set; } = true;
        /* Show step numbers in introduction? */
        public bool ShowStepNumbers { get; set; } = false;
        /* Let user use keyboard to navigate the tour? */
        public bool KeyboardNavigation { get; set; } = true;
        /* Show tour control buttons? */
        public bool ShowButtons { get; set; } = true;
        /* Show tour bullets? */
        public bool ShowBullets { get; set; } = true;
        /* Show tour progress? */
        public bool ShowProgress { get; set; } = false;
        /* Scroll to highlighted element? */
        public bool ScrollToElement { get; set; } = true;
        /*
         * Should we scroll the tooltip or target element?
         *
         * Options are: = 'element' or 'tooltip'
         */
        public string ScrollTo { get; set; } = "element";
        /* Padding to add after scrolling when element is not in the viewport (in pixels) */
        public int ScrollPadding { get; set; } = 30;
        /* Set the overlay opacity */
        public double OverlayOpacity { get; set; } = 0.5;
        /* To determine the tooltip position automatically based on the window.width/height */
        public bool AutoPosition { get; set; } = true;
        /* Precedence of positions, when auto is enabled */
        public string[] PositionPrecedence { get; set; } = { "bottom", "top", "right", "left" };
        /* Disable an interaction with element? */
        public bool DisableInteraction { get; set; } = false;
        /* Set how much padding to be used around helper element */
        public int HelperElementPadding { get; set; } = 10;
        /* Default hint position */
        public string HintPosition { get; set; } = "top-middle";
        /* Hint button label */
        public string HintButtonLabel { get; set; } = "Got it";
        /* Adding animation to hints? */
        public bool HintAnimation { get; set; } = true;
        /* additional classes to put on the buttons */
        public string ButtonClass { get; set; } = "introjs-button";
        /* additional classes to put on progress bar */
        public bool ProgressBarAdditionalClass { get; set; } = false;
        public List<Step> Steps { get; set; }


        internal IntroJsOptions Clone()
        {
            return (IntroJsOptions)MemberwiseClone();
        }
    }
}
