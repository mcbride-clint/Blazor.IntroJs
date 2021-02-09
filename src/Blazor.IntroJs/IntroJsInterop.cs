using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.IntroJs
{
    public class IntroJsInterop
    {
        private readonly IJSRuntime _jsRuntime;
        private IntroJsOptions _options;
        private bool _customOptionsNeedApplied = false;
        public IntroJsInterop(IJSRuntime jsRuntime, IntroJsOptions options)
        {
            _jsRuntime = jsRuntime;
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

        public IntroJsOptions CreateNewOptions()
        {
            return _options.Clone();
        }

        private async Task ShouldUpdateOptions()
        {
            if (_customOptionsNeedApplied)
            {
               await  ApplyOptions();
            }
        }

        public async Task Start()
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start");
        }

        public async Task Start(string elementSelection)
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start", elementSelection);
        }

        public async Task Start(IntroJsOptions options)
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.startWithOptions",  options);
        }

        public async Task AddHints()
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.addHints");
        }

        public async Task AddHints(int step)
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.addHints", step);
        }

        public async Task HideHints()
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.hideHints");
        }

        public async Task HideHints(int step)
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.hideHints", step);
        }

        public async Task RemoveHints()
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.removeHints");
        }

        public async Task RemoveHints(int step)
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.removeHints", step);
        }

        public async Task ShowHintDialog(int step)
        {
            await ShouldUpdateOptions();
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.showHintDialog", step);
        }

        private async Task ApplyOptions()
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.setOptions", _options);
        }

        public async Task ResetOptions()
        {
            _options = new IntroJsOptions();
            await ApplyOptions();
        }
    }
}
