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
                CompanySizeId = 3
            };

            Assert.NotNull(clientViewModel);
        }
    }
}
