namespace Blazor.IntroJs.Wasm.Pages
{
    using System;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;

    public partial class QuickStart : ComponentBase, IAsyncDisposable
    {
        [Inject] private IntroJsInterop IntroJs { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await IntroJs
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

        private void OnChange(IntroJsArgs args,object obj)
        {
            var x = 0;
        }

        private void OnAfterChange(IntroJsArgs args,object obj)
        {
            var x = 0;
        }

        private bool OnBeforeChange(IntroJsArgs args,object obj)
        {
            
            return args.CurrentStep == 0;
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
