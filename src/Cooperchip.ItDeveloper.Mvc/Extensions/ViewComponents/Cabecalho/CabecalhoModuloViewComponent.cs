using Cooperchip.ItDeveloper.Mvc.Extensions.Helpers;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.ViewComponents.Cabecalho
{
    [ViewComponent(Name = "Cabecalho")]
    public class CabecalhoModuloViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string title, string subTitle)
        {
            Modulo model = new()
            {
                SubTitle = subTitle,
                Title = title
            };

            return await Task.FromResult(View(model));
        }
    }
}
