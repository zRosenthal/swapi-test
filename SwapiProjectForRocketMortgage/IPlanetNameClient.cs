namespace SwapiProjectForRocketMortgage
{
    public interface INameClient
    {
        public Task<List<string>> GetNames();
    }
}