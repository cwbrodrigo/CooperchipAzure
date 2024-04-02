using Cooperchip.ItDeveloper.Mvc.Extensions.Repository;
using Cooperchip.ItDeveloper.Mvc.Models;

namespace Cooperchip.ItDeveloper.Mvc.Extensions.Utils
{
    public class Utilities
    {
        #region: Mappers
        public class Mappers : IUtilities
        {
            public async Task<Paciente> MapViewModelToModel(PacienteViewModel model = null)
            {
                Paciente paciente = new()
                {
                    Id = model.Id,
                    Ativo = model.Ativo,
                    Cpf = model.Cpf,
                    DataInternacao = model.DataInternacao,
                    DataNascimento = model.DataNascimento,
                    Email = model.Email,
                    EstadoPacienteId = model.EstadoPacienteId,
                    Motivo = model.Motivo,
                    Nome = model.Nome,
                    Rg = model.Rg,
                    RgDataEmissao = model.RgDataEmissao,
                    RgOrgao = model.RgOrgao,
                    Sexo = model.Sexo,
                    TipoPaciente = model.TipoPaciente
                };

                return await Task.FromResult(paciente);
            }

            public async Task<PacienteViewModel> MapModelToViewModel(Paciente? model = null)
            {
                PacienteViewModel pacienteViewModel = new()
                {
                    Id = model.Id,
                    Ativo = model.Ativo,
                    Cpf = model.Cpf,
                    DataInternacao = model.DataInternacao,
                    DataNascimento = model.DataNascimento,
                    Email = model.Email,
                    EstadoPacienteId = model.EstadoPacienteId,
                    Motivo = model.Motivo,
                    Nome = model.Nome,
                    Rg = model.Rg,
                    RgDataEmissao = model.RgDataEmissao,
                    RgOrgao = model.RgOrgao,
                    Sexo = model.Sexo,
                    TipoPaciente = model.TipoPaciente
                };

                return await Task.FromResult(pacienteViewModel);
            }

            public async Task<List<PacienteViewModel>> MapListModelToListViewModel(List<Paciente>? model = null)
            {
                List<PacienteViewModel> listView = new List<PacienteViewModel>();

                foreach (var item in model)
                {
                    listView.Add(new PacienteViewModel
                    {
                        Ativo = item.Ativo,
                        Cpf = item.Cpf,
                        DataInternacao = item.DataInternacao,
                        DataNascimento = item.DataNascimento,
                        Email = item.Email,
                        EstadoPacienteId = item.EstadoPacienteId,
                        Id = item.Id,
                        Motivo = item.Motivo,
                        Nome = item.Nome,
                        Rg = item.Rg,
                        RgDataEmissao = item.RgDataEmissao,
                        RgOrgao = item.RgOrgao,
                        Sexo = item.Sexo,
                        TipoPaciente = item.TipoPaciente
                    });
                }

                return await Task.FromResult(listView);
            }
        }
        #endregion

        #region Utils
        public static class Utils
        {
            public static int TotReg(ApplicationDbContext context)
            {
                return (from paciente in context.Paciente.AsNoTrackingWithIdentityResolution() select paciente).Count();
            }

            public static decimal GetNumReg(ApplicationDbContext context, string estado)
            {
                return (context.Paciente.AsNoTracking().Count(x => x.EstadoPaciente.Descricao.Contains(estado)));
            }
        }
        #endregion
    }
}
