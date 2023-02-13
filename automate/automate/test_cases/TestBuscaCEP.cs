using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace automate.test_cases
{
    [TestFixture]
    public class TestBuscaCEP
    {
        IWebDriver? driver;
        PageElementsCorreios pg = new PageElementsCorreios();

        [SetUp]
        public void Setup()
        {
            driver = new ChromeDriver();
        }

        [Test]
        public void TestCEPCorreios()
        {
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(pg.HOME_PAGE);

            waitByElement(pg.btnCookie);

            driver.FindElement(pg.btnCookie).Click();

            waitByElement(pg.ziPCodeField);

            driver.FindElement(pg.ziPCodeField).SendKeys("80700000" + Keys.Return);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            waitByElement(pg.messageCepFailedID); 

            Assert.IsTrue(driver.FindElement(pg.messageCepFailedID).Displayed);
            Assert.IsTrue(driver.FindElement(pg.messageCEPFailedCSS).Displayed);

            driver.Close();
            driver.SwitchTo().Window(driver.WindowHandles[0]);

            driver.Navigate().GoToUrl(pg.HOME_PAGE);

            waitByElement(pg.ziPCodeField);
            driver.FindElement(pg.ziPCodeField).SendKeys("01013-001" + Keys.Return);

            driver.SwitchTo().Window(driver.WindowHandles[1]);

            waitByElement(pg.streetSearchCEP);

            String expectedStreet = "Rua Quinze de Novembro - lado ímpar";
            String actualStreet = driver.FindElement(pg.streetSearchCEP).Text;

            Assert.AreEqual(expectedStreet, actualStreet);
        }

        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }

        public void waitByElement(By element)
        {
            int timeOut = 60;
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeOut));
            IWebElement myElement = wait.Until(x => x.FindElement(element));
        }
    }
}