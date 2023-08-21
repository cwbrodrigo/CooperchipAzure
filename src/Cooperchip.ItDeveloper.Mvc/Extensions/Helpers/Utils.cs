namespace Cooperchip.ItDeveloper.Mvc.Extensions.Helpers
{
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
}
