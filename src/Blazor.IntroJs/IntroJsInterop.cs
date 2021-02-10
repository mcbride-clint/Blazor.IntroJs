using Microsoft.JSInterop;
using System;
using System.Threading.Tasks;

namespace Blazor.IntroJs
{
    public class IntroJsInterop
    {
        private readonly IJSRuntime _jsRuntime;
        private readonly IntroJsInteropEvents _events;
        private IntroJsOptions _options;
        private bool _customOptionsNeedApplied = false;
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
                _customOptionsNeedApplied = true;
                _options = options;
            }
        }

        public async Task Initialize()
        {
            var objRef = DotNetObjectReference.Create(_events);
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.initialize", objRef);

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

        private async Task ShouldUpdateOptions()
        {
            if (_customOptionsNeedApplied)
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
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start");
        }

        /// <summary>
        /// Start the introduction for defined element(s).
        /// </summary>
        /// <param name="elementSelection">Specific id (#) or class (.)</param>
        /// <returns></returns>
        public async Task Start(string elementSelection)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start", elementSelection);
        }

        /// <summary>
        /// Start the introduction given an options object.
        /// </summary>
        /// <param name="options"></param>
        /// <returns></returns>
        public async Task Start(IntroJsOptions options)
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.startWithOptions", options);
        }

        /// <summary>
        /// Start the introduction given an options object for defined element(s).
        /// </summary>
        /// <param name="options"></param>
        /// <param name="elementSelection">Specific id (#) or class (.)</param>
        /// <returns></returns>
        public async Task Start(IntroJsOptions options, string elementSelection)
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.startWithOptions", options, elementSelection);
        }

        /// <summary>
        /// Go to specific step of introduction.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public async Task GoToStep(int step)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.goToStep", step);
        }

        /// <summary>
        /// Go to specific step of introduction with the concrete step. This differs from goToStep in the way that data-step does not have be continuous to pick the desired element.
        /// </summary>
        /// <param name="step"></param>
        /// <returns></returns>
        public async Task GoToStepNumber(int step)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.goToStepNumber", step);
        }

        /// <summary>
        /// Exit the introduction.
        /// </summary>
        /// <param name="force">Exit the tour even if introJs.onbeforeexit returns false</param>
        /// <returns></returns>
        public async Task Exit(bool force = false)
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.exit", force);
        }

        /// <summary>
        /// To refresh and order layers manually. This function rearranges all hints as well.
        /// </summary>
        /// <returns></returns>
        public async Task Refresh()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.refresh");
        }

        /// <summary>
        /// Show the hint with given hintId.
        /// </summary>
        /// <param name="hintId"></param>
        /// <returns></returns>
        public async Task ShowHint(int hintId)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHint", hintId);
        }

        /// <summary>
        /// Show all hints.
        /// </summary>
        /// <returns></returns>
        public async Task ShowHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHints");
        }

        /// <summary>
        /// To add available hints to the page (using data-hint or JSON)
        /// </summary>
        /// <returns></returns>
        public async Task AddHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.addHints");
        }

        /// <summary>
        /// Hides all hints on the page.
        /// </summary>
        /// <returns></returns>
        public async Task HideHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.hideHints");
        }

        /// <summary>
        /// Hides the hint with given stepId. The stepId is an integer and it’s the value of data-step attribute on the hint element.
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public async Task HideHint(int stepId)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.hideHint", stepId);
        }

        /// <summary>
        /// Shows the popup dialog next to the hint with given stepId. The stepId is an integer and it’s the value of data-step attribute on the hint element.
        /// </summary>
        /// <param name="stepId"></param>
        /// <returns></returns>
        public async Task ShowHintDialog(int stepId)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHintDialog", stepId);
        }

        public async Task RemoveHints()
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.removeHints");
        }

        public async Task RemoveHints(int step)
        {
            await Initialize();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.removeHints", step);
        }

        /// <summary>
        /// Sets the IntroJs Default Options Object
        /// </summary>
        /// <returns></returns>
        private async Task ApplyOptions()
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.setOptions", _options);
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

        public IntroJsInterop OnAfterChange(Action<string> callback)
        {
            _events.OnAfterChange = callback;
            return this;
        }
        public IntroJsInterop OnBeforeChange(Action<string> callback)
        {
            _events.OnBeforeChange = callback;
            return this;
        }
        public IntroJsInterop OnChange(Action<string> callback)
        {
            _events.OnChange = callback;
            return this;
        }
        public IntroJsInterop OnBeforeExit(Func<bool> callback)
        {
            _events.OnBeforeExit = callback;
            return this;
        }
        public IntroJsInterop OnExit(Action callback)
        {
            _events.OnExit = callback;
            return this;
        }
        public IntroJsInterop OnHintClick(Action callback)
        {
            _events.OnHintClick = callback;
            return this;
        }
        public IntroJsInterop OnHintClose(Action callback)
        {
            _events.OnHintClose = callback;
            return this;
        }
        public IntroJsInterop OnHintsAdded(Action callback)
        {
            _events.OnHintsAdded = callback;
            return this;
        }
    }
}
