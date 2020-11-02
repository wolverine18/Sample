using System.Threading.Tasks;
using Sample.Domain.Abstract;
using Sample.Domain.Entities;

namespace Sample.Infrastructure.Repositories
{
    public class HelloWorld : IHelloWorld
    {
        HelloWorldMessage _helloWorldMessage = new HelloWorldMessage();

        public Task<string> GetHelloWorld()
        {
            return Task.Run<string>(()=>_helloWorldMessage.HelloWorld);
        }
    }
}
