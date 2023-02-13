using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace automate.test_cases
{
    internal class PageElementsCorreios
    {
        public String HOME_PAGE = "https://www.correios.com.br/";
        public By ziPCodeField = By.XPath("/html/body/div/div/div/div[3]/div/div/article/div[3]/div/div[2]/div[2]/form/div[2]/input");
        public By btnCookie = By.Id("btnCookie");
        public By btnSearch = By.XPath("//*[@id=\"content\"]/div[3]/div/div[2]/div[2]/form/div[2]/button/i");
        public By messageCepFailedID = By.Id("mensagem-resultado-alerta");
        public By messageCEPFailedXPATH = By.XPath("//*[@id=\"mensagem-resultado\"]");
        public By messageCEPFailedCSS = By.CssSelector("#mensagem-resultado");
        public By streetSearchCEP = By.XPath("//*[@id=\"resultado-DNEC\"]/tbody/tr/td[1]");
        public By rastreamentoEncomenda = By.XPath("//*[@id=\"objetos\"]");
    }
}
