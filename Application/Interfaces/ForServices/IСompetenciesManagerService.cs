namespace Application.Interfaces.ForServices
{
    public interface IСompetenciesManagerService
    {
        public Task<List<string>> GetAllCompetencies();
    }
}