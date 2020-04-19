using Alura.LeilaoOnline.Selenium.PageObjects;
using Alura.LeilaoOnline.Selenium.Fixtures;
using OpenQA.Selenium;
using Xunit;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class AoNavegarParaFormNovoLeilao
    {
        private IWebDriver driver;

        public AoNavegarParaFormNovoLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminValidaDrop()
        {
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();

            Assert.Equal(3, novoLeilaoPO.Categorias.Count());
        }
    }
}
