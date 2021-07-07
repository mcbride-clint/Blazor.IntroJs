using Microsoft.JSInterop;
using System;

namespace Blazor.IntroJs
{
    /// <summary>
    /// IntroJs Events that are triggered via JavaScript
    /// </summary>
    public class IntroJsInteropEvents
    {

        // *****************************************
        // Events
        // *****************************************

        /// <summary>
        /// Set callback for when introduction completed.
        /// </summary>
        public Action<IntroJsArgs> OnComplete { get; set; }
        /// <summary>
        /// Set callback to exit of introduction. 
        /// Exit also means pressing ESC key and clicking on the overlay layer by the user.
        /// </summary>
        public Action<IntroJsArgs> OnExit { get; set; }
        /// <summary>
        /// Set callback to change of each step of introduction. 
        /// Given callback function will be called after completing each step. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public Action<object, IntroJsArgs> OnChange { get; set; }
        /// <summary>
        /// Given callback function will be called before starting a new step of introduction. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public Func<object, IntroJsArgs, bool> OnBeforeChange { get; set; }
        /// <summary>
        /// Given callback function will be called after starting a new step of introduction. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public Action<object, IntroJsArgs> OnAfterChange { get; set; }
        /// <summary>
        /// Works exactly same as onexit but calls before closing the tour. 
        /// Also, returning false would prevent the tour from closing.
        /// </summary>
        public Func<IntroJsArgs, bool> OnBeforeExit { get; set; }
        /// <summary>
        /// Invokes given function when user clicks on one of hints.
        /// </summary>
        public Action<IntroJsArgs> OnHintClick { get; set; }
        /// <summary>
        /// Invokes given callback function after adding and rendering all hints.
        /// </summary>
        public Action<IntroJsArgs> OnHintsAdded { get; set; }
        /// <summary>
        /// Set callback for when a single hint removes from page (e.g. when user clicks on “Got it” button)
        /// </summary>
        public Action<IntroJsArgs> OnHintClose { get; set; }

        /// <summary>
        /// Resets all event callbacks to null
        /// </summary>
        public void ClearEvents()
        {
            OnComplete = null;
            OnExit = null;
            OnChange = null;
            OnBeforeChange = null;
            OnAfterChange = null;
            OnBeforeExit = null;
            OnHintClick = null;
            OnComplete = null;
            OnHintsAdded = null;
            OnHintClose = null;
        }

        /// <summary>
        /// Method to Trigger OnComplete Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnCompleteJsEvent(IntroJsArgs args)
        {
            OnComplete?.Invoke(args);
        }

        /// <summary>
        /// Method to Trigger OnExit Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnExitJsEvent(IntroJsArgs args)
        {
            OnExit?.Invoke(args);
        }

        /// <summary>
        /// Method to Trigger OnChange Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnChangeJsEvent(object targetElement, IntroJsArgs args )
        {
            OnChange?.Invoke(targetElement, args);
        }

        /// <summary>
        /// Method to Trigger OnBeforeChange Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public bool OnBeforeChangeJsEvent(object targetElement, IntroJsArgs args)
        {
            return (OnBeforeChange?.Invoke(targetElement, args)).GetValueOrDefault(true);
        }

        /// <summary>
        /// Method to Trigger OnAfterChange Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnAfterChangeJsEvent(object targetElement, IntroJsArgs args)
        {
            OnAfterChange?.Invoke(targetElement, args);
        }

        /// <summary>
        /// Method to Trigger OnHintClick Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnHintClickJsEvent(IntroJsArgs args)
        {
            OnHintClick?.Invoke(args);
        }

        /// <summary>
        /// Method to Trigger OnHintsAdded Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnHintsAddedJsEvent(IntroJsArgs args)
        {
            OnHintsAdded?.Invoke(args);
        }

        /// <summary>
        /// Method to Trigger OnHintClose Action.  JsInvokable
        /// </summary>
        [JSInvokable]
        public void OnHintCloseJsEvent(IntroJsArgs args)
        {
            OnHintClose?.Invoke(args);
        }

        /// <summary>
        /// Method to Trigger OnBeforeExit Func.  JsInvokable
        /// </summary>
        /// <returns>bool</returns>
        [JSInvokable]
        public bool OnBeforeExitJsEvent(IntroJsArgs args)
        {
            return (OnBeforeExit?.Invoke(args)).GetValueOrDefault(true);
        }
    }
}
