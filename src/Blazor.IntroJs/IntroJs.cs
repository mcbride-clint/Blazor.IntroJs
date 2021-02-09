using Microsoft.JSInterop;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Blazor.IntroJs
{
    public class IntroJs
    {
        private readonly IJSRuntime _jsRuntime;

        public IntroJs(IJSRuntime jsRuntime)
        {
            _jsRuntime = jsRuntime;
        }

        public async Task Start()
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start");
        }

        public async Task Start(string elementSelection)
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.start", elementSelection);
        }

        public async Task AddHints()
        {
            await _jsRuntime.InvokeVoidAsync("blazorIntroJs.addHints");
        }
    }
}
