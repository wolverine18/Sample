using System.Threading.Tasks;

namespace Sample.Domain.Abstract
{
   public interface IHelloWorld
    {
        Task<string> GetHelloWorld();
    }
}
