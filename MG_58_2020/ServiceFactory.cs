namespace MG_58_2020
{
    public class ServiceFactory : IServiceFactory
    {
        public IResultsService GetResultService() => new ResultService();
    }
}