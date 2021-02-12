using Microsoft.AspNetCore.Components;
using System.Threading.Tasks;

namespace Blazor.IntroJs.Wasm.Pages
{
    public partial class ComponentBased : ComponentBase
    {
        [Inject] private IntroJsInterop introJs { get; set; }

        protected override async Task OnAfterRenderAsync(bool firstRender)
        {
            if (firstRender)
            {
                await introJs.Start();
            }
        }

        protected async Task StartIntroJs()
        {
            await introJs.Start();
        }


        protected async Task StartIntroJsClass()
        {
            await introJs.Start(".onlyThese");
        }

        protected async Task AddHints()
        {
            await introJs.AddHints();
        }

        protected async Task HideHints()
        {
            await introJs.HideHints();
        }

        protected async Task RemoveHints()
        {
            await introJs.RemoveHints();
        }
    }
}
