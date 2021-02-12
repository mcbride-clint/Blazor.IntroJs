using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.IntroJs
{
    /// <summary>
    /// Used to interact with the IntroJs javascript functions through JSInterop
    /// </summary>
    public class IntroJsInterop : IDisposable
    {
        private readonly string _id = Guid.NewGuid().ToString();
        private readonly IJSRuntime _jsRuntime;
        private readonly IntroJsInteropEvents _events;
        private IntroJsOptions _options;
        private bool _shouldOptionsBeApplied = false;

        private readonly IntroJsStatus _status;

        /// <summary>
        /// Instantiate a new instance IntroJsInterop
        /// </summary>
        /// <param name="jsRuntime"></param>
        /// <param name="events"></param>
        /// <param name="options"></param>
        public IntroJsInterop(IJSRuntime jsRuntime, IntroJsInteropEvents events, IntroJsOptions options)
        {
            _jsRuntime = jsRuntime;
            _events = events;
            if (options is null)
            {
                _options = new IntroJsOptions();
            }
            else
            {
                _shouldOptionsBeApplied = true;
                _options = options;
            }

            _status = new IntroJsStatus();
        }

        private async Task Initialize()
        {
            var objRef = DotNetObjectReference.Create(_events);
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.initialize", _id, objRef);

            await ShouldUpdateOptions();
        }

        /// <summary>
        /// Create a new instance of current IntroJs options.  Can be used for one-off settings or manual configuration of Steps and Hints.
        /// </summary>
        /// <returns></returns>
        public IntroJsOptions CreateNewOptions()
        {
            return _options.Clone();
        }

        /// <summary>
        /// Set a group of options to the introJs object.
        /// </summary>
        /// <param name="func"></param>
        /// <returns></returns>
        public IntroJsInterop SetOptions(Func<IntroJsOptions, IntroJsOptions> func)
        {
            _options = func.Invoke(CreateNewOptions());
            _shouldOptionsBeApplied = true;
            return this;
        }

        /// <summary>
        /// Set a single or group of options to the introJs object.
        /// </summary>
        /// <param name="action"></param>
        /// <returns></returns>
        public IntroJsInterop SetOption(Action<IntroJsOptions> action)
        {
            _options = CreateNewOptions();
            action.Invoke(_options);
            _shouldOptionsBeApplied = true;
            return this;
        }

        private async Task ShouldUpdateOptions()
        {
            if (_shouldOptionsBeApplied)
            {
                await ApplyOptions();
            }
        }

        /// <summary>
        /// Start the introduction for defined element(s).
        /// </summary>
        /// <returns></returns>
        public async Task Start()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start", _id, _status);
        }

        /// <summary>
        /// Start the introduction for defined element(s).
        /// </summary>
        /// <param name="elementSelection">Specific id (#) or class (.)</param>
        /// <returns></returns>
        public async Task Start(string elementSelection)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start", _id, _status, elementSelection);
        }

        /// <summary>
        /// Go to specific step of introduction.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public IntroJsInterop GoToStep(int step)
        {
            _status.GoToStep = step;

            return this;
        }

        /// <summary>
        /// Go to specific step of introduction with the concrete step. This differs from goToStep in the way that data-step does not have be continuous to pick the desired element.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public IntroJsInterop GoToStepNumber(int step)
        {
            _status.GoToStepNumber = step;
            return this;
        }

        /// <summary>
        /// Exit the introduction.
        /// </summary>
        /// <param name="force">Exit the tour even if introJs.onbeforeexit returns false</param>
        /// <returns></returns>
        public async Task Exit(bool force = false)
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.exit", _id, force);
        }

        /// <summary>
        /// To refresh and order layers manually. This function rearranges all hints as well.
        /// </summary>
        /// <returns></returns>
        public async Task Refresh()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.refresh", _id);
        }

        /// <summary>
        /// Show the hint with given hintId.
        /// </summary>
        /// <param name="hintId"></param>
        /// <returns></returns>
        public async Task ShowHint(int hintId)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHint", _id, hintId);
        }

        /// <summary>
        /// Show all hints.
        /// </summary>
        /// <returns></returns>
        public async Task ShowHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHints", _id);
        }

        /// <summary>
        /// To add available hints to the page (using data-hint or JSON)
        /// </summary>
        /// <returns></returns>
        public async Task AddHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.addHints", _id);
        }

        /// <summary>
        /// Hides all hints on the page.
        /// </summary>
        /// <returns></returns>
        public async Task HideHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.hideHints", _id);
        }

        /// <summary>
        /// Hides the hint with given stepId. The stepId is an integer and it’s the value of data-step attribute on the hint element.
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public async Task HideHint(int stepId)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.hideHint", _id, stepId);
        }

        /// <summary>
        /// Shows the popup dialog next to the hint with given stepId. The stepId is an integer and it’s the value of data-step attribute on the hint element.
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public async Task ShowHintDialog(int stepId)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHintDialog", _id, stepId);
        }

        /// <summary>
        /// Found in the source code.  
        /// Seems to actually hide the Hints and allows them to be reshown later.  
        /// Not sure if supported.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.removeHints", _id);
        }

        /// <summary>
        /// Found in the source code.  
        /// Seems to actually hide the Hints and allows them to be reshown later.  
        /// Not sure if supported.
        /// </summary>
        /// <returns></returns>
        public async Task RemoveHints(int step)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.removeHints", _id, step);
        }

        /// <summary>
        /// Sets the IntroJs Default Options Object
        /// </summary>
        /// <returns></returns>
        private async Task ApplyOptions()
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.setOptions", _id, _options);
        }

        /// <summary>
        /// Resets all IntroJs Options to default settings.  Removes configured settings for application.
        /// </summary>
        /// <returns></returns>
        public async Task ResetOptions()
        {
            _options = new IntroJsOptions();
            await ApplyOptions();
        }

        // *******************************************
        // Events
        // *******************************************

        /// <summary>
        /// Reset all IntroJs Events
        /// </summary>
        /// <returns></returns>
        public IntroJsInterop ClearEvents()
        {
            _events.ClearEvents();
            return this;
        }

        /// <summary>
        /// Set callback for when introduction completed.
        /// </summary>
        public IntroJsInterop OnComplete(Action callback)
        {
            _events.OnComplete = callback;
            return this;
        }
        /// <summary>
        /// Given callback function will be called after starting a new step of introduction. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public IntroJsInterop OnAfterChange(Action<object> callback)
        {
            _events.OnAfterChange = callback;
            return this;
        }
        /// <summary>
        /// Given callback function will be called before starting a new step of introduction. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public IntroJsInterop OnBeforeChange(Action<object> callback)
        {
            _events.OnBeforeChange = callback;
            return this;
        }
        /// <summary>
        /// Set callback to change of each step of introduction. 
        /// Given callback function will be called after completing each step. 
        /// The callback function receives the element of the new step as an argument.
        /// </summary>
        public IntroJsInterop OnChange(Action<object> callback)
        {
            _events.OnChange = callback;
            return this;
        }
        /// <summary>
        /// Works exactly same as onexit but calls before closing the tour. 
        /// Also, returning false would prevent the tour from closing.
        /// </summary>
        public IntroJsInterop OnBeforeExit(Func<bool> callback)
        {
            _events.OnBeforeExit = callback;
            return this;
        }
        /// <summary>
        /// Set callback to exit of introduction. 
        /// Exit also means pressing ESC key and clicking on the overlay layer by the user.
        /// </summary>
        public IntroJsInterop OnExit(Action callback)
        {
            _events.OnExit = callback;
            return this;
        }
        /// <summary>
        /// Invokes given function when user clicks on one of hints.
        /// </summary>
        public IntroJsInterop OnHintClick(Action callback)
        {
            _events.OnHintClick = callback;
            return this;
        }
        /// <summary>
        /// Set callback for when a single hint removes from page (e.g. when user clicks on “Got it” button)
        /// </summary>
        public IntroJsInterop OnHintClose(Action callback)
        {
            _events.OnHintClose = callback;
            return this;
        }
        /// <summary>
        /// Invokes given callback function after adding and rendering all hints.
        /// </summary>
        public IntroJsInterop OnHintsAdded(Action callback)
        {
            _events.OnHintsAdded = callback;
            return this;
        }

        /// <summary>
        /// Removes the instance of introJs from JS memory
        /// </summary>
        public void Dispose()
        {
            _jsRuntime.InvokeVoidAsync("blazorIntroJs.dipose", _id);
        }
    }
}
