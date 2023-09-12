namespace Cooperchip.ItDeveloper.Mvc.Extensions.ViewComponents.ExperienciaUsuario
{
    [ViewComponent(Name = "ExperienciaUsuario")]
    public class ExperienciaUsuarioViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return await Task.FromResult(View());
        }
    }
}
