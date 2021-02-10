using Microsoft.JSInterop;
using System;

namespace Blazor.IntroJs
{
    public class IntroJsInteropEvents
    {

        // *****************************************
        // Events
        // *****************************************

        /// <summary>
        /// Set callback for when introduction completed.
        /// </summary>
        public Action OnComplete { get; set; }
        /// <summary>
        /// Set callback to exit of introduction. 
        /// Exit also means pressing ESC key and clicking on the overlay layer by the user.
        /// </summary>
        public Action OnExit { get; set; }
        /// <summary>
        /// Set callback to change of each step of introduction. 
        /// Given callback function will be called after completing each step. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public Action<string> OnChange { get; set; }
        /// <summary>
        /// Given callback function will be called before starting a new step of introduction. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public Action<string> OnBeforeChange { get; set; }
        /// <summary>
        /// Given callback function will be called after starting a new step of introduction. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public Action<string> OnAfterChange { get; set; }
        /// <summary>
        /// Works exactly same as onexit but calls before closing the tour. 
        /// Also, returning false would prevent the tour from closing.
        /// </summary>
        public Func<bool> OnBeforeExit { get; set; }
        /// <summary>
        /// Invokes given function when user clicks on one of hints.
        /// </summary>
        public Action OnHintClick { get; set; }
        /// <summary>
        /// Invokes given callback function after adding and rendering all hints.
        /// </summary>
        public Action OnHintsAdded { get; set; }
        /// <summary>
        /// Set callback for when a single hint removes from page (e.g. when user clicks on “Got it” button)
        /// </summary>
        public Action OnHintClose { get; set; }

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

        [JSInvokable]
        public void OnCompleteJsEvent()
        {
            OnComplete?.Invoke();
        }

        [JSInvokable]
        public void OnExitJsEvent()
        {
            OnExit?.Invoke();
        }

        [JSInvokable]
        public void OnChangeJsEvent(string targetElement)
        {
            OnChange?.Invoke(targetElement);
        }

        [JSInvokable]
        public void OnBeforeChangeJsEvent(string targetElement)
        {
            OnBeforeChange?.Invoke(targetElement);
        }

        [JSInvokable]
        public void OnAfterChangeJsEvent(string targetElement)
        {
            OnAfterChange?.Invoke(targetElement);
        }

        [JSInvokable]
        public void OnHintClickJsEvent()
        {
            OnHintClick?.Invoke();
        }

        [JSInvokable]
        public void OnHintsAddedJsEvent()
        {
            OnHintsAdded?.Invoke();
        }

        [JSInvokable]
        public void OnHintCloseJsEvent()
        {
            OnHintClose?.Invoke();
        }

        [JSInvokable]
        public bool OnBeforeExitJsEvent()
        {
            return (OnBeforeExit?.Invoke()).GetValueOrDefault(true);
        }
    }
}
