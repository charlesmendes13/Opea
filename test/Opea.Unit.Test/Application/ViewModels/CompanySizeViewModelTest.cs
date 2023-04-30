using Opea.Application.ViewModels;

namespace Opea.Unit.Test.Application.ViewModels
{
    public class CompanySizeViewModelTest
    {
        [Fact]
        public void CompanySizeViewModel()
        {
            var companySizeViewModel = new CompanySizeViewModel()
            {
                Id = 1
            };

            Assert.NotNull(companySizeViewModel);
        }
    }
}
