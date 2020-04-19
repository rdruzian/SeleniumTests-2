using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using System.Threading;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoCriarLeilao
    {
        private IWebDriver driver;

        public AoCriarLeilao(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginAdminCadLeilao()
        {
            var loginPO = new LoginPO(driver);

            loginPO.Visitar();
            loginPO.PreencheFormulario("admin@example.org", "123");
            loginPO.SubmeteFormulario();

            var novoLeilaoPO = new NovoLeilaoPO(driver);
            novoLeilaoPO.Visitar();
            novoLeilaoPO.PreencheForm("Leilão de coleção 1", "Lorem ipsum dolor sit amet, consectetur adipiscing elit", "Item de Colecionador", 4000, "C:\\Users\\renat\\Downloads\\dados.jpg", DateTime.Now.AddDays(20), DateTime.Now.AddDays(40));

            novoLeilaoPO.SubmeteForm();

            Assert.Contains("Leilões cadastrados no sistema", driver.PageSource);        
        }
    }
}
