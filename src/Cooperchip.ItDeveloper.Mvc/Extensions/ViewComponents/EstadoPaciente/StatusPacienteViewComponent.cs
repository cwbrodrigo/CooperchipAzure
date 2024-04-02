using Cooperchip.ItDeveloper.Mvc.Extensions.Utils;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.ViewComponents.EstadoPaciente
{
    [ViewComponent(Name = "StatusPaciente")]
    public class StatusPacienteViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public StatusPacienteViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync(string estado)
        {
            int totalGeral = Utilities.Utils.TotReg(_context);

            decimal totalEstado = Utilities.Utils.GetNumReg(_context, estado);

            decimal progress = (totalGeral > 0) ? totalEstado * 100 / totalGeral : 0;

            string percent = progress.ToString("F1");

            var classContainer = string.Empty;
            var iconLg = string.Empty;

            switch (estado)
            {
                case "Crítico":
                    classContainer = "panel panel-info tile panelClose panelRefresh";
                    iconLg = "l-basic-geolocalize-05";
                    break;
                case "Em Observação":
                    classContainer = "panel panel-default tile panelClose panelRefresh";
                    iconLg = "l-banknote";
                    break;
                case "Grave":
                    classContainer = "panel panel-danger tile panelClose panelRefresh";
                    iconLg = "l-basic-life-buoy";
                    break;
                case "Estável":
                    classContainer = "panel panel-success tile panelClose panelRefresh";
                    iconLg = "l-ecommerce-cart-content";
                    break;
                default:
                    classContainer = "panel panel-info tile panelClose panelRefresh";
                    iconLg = "l-basic-geolocalize-05";
                    break;
            }

            ContadorEstadoPaciente model = new()
            {
                Title = $"Pacientes {estado}",
                Partial = (int)totalEstado,
                Percentage = percent,
                Progress = progress,
                ClassContainer = classContainer,
                IconLg = iconLg,
                IconSm = "fa fa-arrow-circle-o-up s20 mr5 pull-left"
            };

            return await Task.FromResult(View(model));
        }
    }
}
