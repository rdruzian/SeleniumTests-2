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
        }

        public void PesquisarLeiloes(List<string> categorias)
        {
            var selectWrapper = driver.FindElement(bySelectCategorias);
            selectWrapper.Click();

            var opcoes = selectWrapper.FindElements(By.CssSelector("li>span")).ToList();

            opcoes.ForEach(o => { o.Click(); });

            categorias.ForEach(categ => {opcoes.Where(o => o.Text.Contains(categ)).ToList().ForEach( o => {o.Click(); }); });

            selectWrapper.FindElement(By.TagName("li")).SendKeys(Keys.Tab);
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
