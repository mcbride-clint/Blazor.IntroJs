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
