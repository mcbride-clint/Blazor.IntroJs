using Microsoft.AspNetCore.Components;
using System;
using System.Threading.Tasks;

namespace Blazor.IntroJs.Wasm.Pages
{
    public partial class QuickStart : ComponentBase, IAsyncDisposable
    {
        [Inject] private IntroJsInterop IntroJs { get; set; }


        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await IntroJs
                    .OnHintClick(OnHint)
                    .OnBeforeChange(OnBeforeChange)
                    .OnAfterChange(OnAfterChange)
                    .OnChange(OnChange)
                    .OnComplete(OnComplete)
                    .OnExit(OnExit)
                    .OnHintClose(OnHintClose)
                    .OnHintsAdded(OnHintsAdded)
                    .Start();
            }
        }

        private void OnHintsAdded(IntroJsArgs args)
        {
            var x = 0;
        }

        private void OnHintClose(IntroJsArgs args)
        {
            var x = 0;
        }

        private void OnExit(IntroJsArgs args)
        {
            var x = 0;
        }

        private void OnComplete(IntroJsArgs args)
        {
            var x = 0;
        }

        private void OnChange(object obj, IntroJsArgs args)
        {
            var x = 0;
        }

        private void OnAfterChange(object obj, IntroJsArgs args)
        {
            var x = 0;
        }

        private bool OnBeforeChange(object obj, IntroJsArgs args)
        {
            
            return args.CurrentStep == 0;
        }

        private void OnHint(IntroJsArgs args)
        {
            var x = 0;
        }

        protected bool OnBeforeExit(IntroJsArgs args)
        {
            return true;
        }

        protected async Task StartIntroJs()
        {
            await IntroJs.Start();
        }

        protected async Task StartIntroJsClass()
        {
            await IntroJs.Start(".onlyThese");
        }

        protected async Task AddHints()
        {
            await IntroJs.ShowHints();
        }

        public async ValueTask DisposeAsync()
        {
            await IntroJs.DisposeAsync();
        }
    }
}
