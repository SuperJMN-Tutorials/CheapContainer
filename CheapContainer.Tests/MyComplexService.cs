namespace CheapContainer.Tests
{
    public class MyComplexService : IMyComplexService
    {
        public IMyOtherService OtherService { get; }

        public MyComplexService(IMyOtherService otherService)
        {
            OtherService = otherService;
        }
    }
}