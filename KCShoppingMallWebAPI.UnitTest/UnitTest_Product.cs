using Microsoft.Extensions.Configuration;

namespace KCShoppingMallWebAPI.UnitTest
{
    public class Tests()
    {
        [SetUp]
        public void Setup()
        {

        }

        [Test]
        public async Task Test_Null_GetProducts()
        {
            BLL.BLL.Product product = new BLL.BLL.Product(GetConfiguration());
            var products = await product.GetProducts(null);
            Assert.That(products != null, Is.True);
        }

        [Test]
        public async Task Test_Empty_GetProducts()
        {
            BLL.BLL.Product product = new BLL.BLL.Product(GetConfiguration());
            var products = await product.GetProducts(null);
            Assert.That(products.Count != 0, Is.True);
        }

        [Test]
        public async Task Test_Featured_GetProducts()
        {
            BLL.BLL.Product product = new BLL.BLL.Product(GetConfiguration());
            var products = await product.GetProducts(true);
            Assert.That(products.Where(x => x.Featured == false).ToList().Count == 0, Is.True);
        }

        private IConfiguration GetConfiguration()
        {
            IConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
            configurationBuilder.AddJsonFile("appsettings.Development.json");
            return configurationBuilder.Build();
        }
    }
}