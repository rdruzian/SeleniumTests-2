using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;

namespace Alura.LeilaoOnline.Selenium.Testes
{
    public class DashboardInteressadaPO
    {
        private IWebDriver driver;
        private By byLogout;
        private By byMeuPerfilLink;

        public DashboardInteressadaPO(IWebDriver driver)
        {
            this.driver = driver;
            byLogout = By.Id("logout");
            byMeuPerfilLink = By.Id("meu-perfil");
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
