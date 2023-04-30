using Opea.Application.ViewModels;

namespace Opea.Unit.Test.Application.ViewModels
{
    public class ClientViewModelTest
    {
        [Fact]
        public void ClientViewModel()
        {
            var clientViewModel = new ClientViewModel()
            {
                Id = 1,
                CompanyName = "Google",
                CompanySize = new CompanySizeViewModel()
                {
                    Id = 1
                }
            };

            Assert.NotNull(clientViewModel);
        }
    }
}
