
namespace CheapContainer
{
    public class CheapDependencyContainer
    {
        public void Register<TKey, TResult>()
        {
        }

        public object Resolve<T>()
        {
            return new MyService();
        }
    }
}