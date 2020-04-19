﻿using Alura.LeilaoOnline.Selenium.Helpers;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using System.Collections.Generic;
using System.Linq;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogout;
        private By byMeuPerfilLink;
        private By bySelectCategorias;
        private By byInputTermo;
        private By byInputAndamento;
        private By byBotaoPesquisar;


        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogout = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
            bySelectCategorias = By.ClassName("select-wrapper");
            byInputTermo = By.Id("termo");
            byInputAndamento = By.ClassName("switch");
            byBotaoPesquisar = By.CssSelector("form>button.btn");
        }

        public void PesquisarLeiloes(List<string> categorias, string termo, bool emAndamento)
        {
            var select = new SelectMaterialize(driver, bySelectCategorias);

            select.Deseleciona();

            categorias.ForEach(categ => { select.SelectByText(categ); });

            driver.FindElement(byInputTermo).SendKeys(termo);
            if(emAndamento)
                driver.FindElement(byInputAndamento).Click();

            driver.FindElement(byBotaoPesquisar).Click();
        }

        public void EfetuarLogout()
        {
            var linkMeuPerfil = driver.FindElement(byMeuPerfilLink);
            var linklogout = driver.FindElement(byLogout);

            //mover para o elemento pai
            //mover para o link de logout
            //clicar no link de logout
            IAction acaoLogout = new Actions(driver).MoveToElement(linkMeuPerfil).MoveToElement(linklogout).Click().Build(); //Ações apenas criada

            //esecuta a ação criada acima
            acaoLogout.Perform();
            
        }
    }
}
