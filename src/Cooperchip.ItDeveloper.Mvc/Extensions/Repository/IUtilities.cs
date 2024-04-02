using Cooperchip.ItDeveloper.Mvc.Models;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.Repository
{
    public interface IUtilities
    {
        Task<Paciente> MapViewModelToModel(PacienteViewModel model);
        Task<PacienteViewModel> MapModelToViewModel(Paciente? model);
        Task<List<PacienteViewModel>> MapListModelToListViewModel(List<Paciente>? model);
    }
}
