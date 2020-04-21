﻿using System;
using OpenQA.Selenium;
using Xunit;
using Alura.LeilaoOnline.Selenium.Fixtures;
using Alura.LeilaoOnline.Selenium.PageObjects;
using OpenQA.Selenium.Support.UI;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    [Collection("Chrome Driver")]
    public class AoOfertarLance
    {
        private IWebDriver driver;

        public AoOfertarLance(TestFixture fixture)
        {
            driver = fixture.Driver;
        }

        [Fact]
        public void DadoLoginInteressadaAtualizarLanceAtual()
        {
            var loginPO = new LoginPO(driver);
            loginPO.Visitar();
            loginPO.PreencheFormulario("fulano@example.org", "123");
            loginPO.SubmeteFormulario();

            var detalhePO = new DetalheLeilaoPO(driver);
            detalhePO.Visitar(1);

            detalhePO.OfertarLance(300);

            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(8)); //wait explicito, vai acontecer apenas nesse teste
            bool iguais = wait.Until(drv => detalhePO.LanceAtual == 300);

            Assert.True(iguais);
        }
    }
}
