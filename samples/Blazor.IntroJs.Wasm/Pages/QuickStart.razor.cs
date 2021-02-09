using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.IntroJs.Wasm.Pages
{
    public partial class QuickStart : ComponentBase
    {
        [Inject] private IntroJsInterop IntroJs { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await IntroJs.Start();
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
            await IntroJs.AddHints();
        }
    }
}
