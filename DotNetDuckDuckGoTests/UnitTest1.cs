using System;
using System.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.IE;
using System.Threading;
using OpenQA.Selenium.Support.UI;


namespace DotNetDuckDuckGoSearch
{
    /// <summary>
    /// Summary description for MySeleniumTests
    /// </summary>
    [TestClass]
    public class MySeleniumTests
    {
        private TestContext testContextInstance;
        private IWebDriver driver;
        private string appURL;

        public MySeleniumTests()
        {
        }

        [TestMethod]
        [TestCategory("Chrome")]

        public void DotNetDuckDuckGoSearchTest()
        {
            driver.Navigate().GoToUrl(appURL + "/");
            driver.FindElement(By.Id("search_form_input_homepage")).SendKeys("Azure Pipelines");
            driver.FindElement(By.Id("search_button_homepage")).Click();
            Assert.IsTrue(driver.Title.Contains("Azure Pipelines"), "Verified title of the page");
        }

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestInitialize()]
        public void SetupTest()
        {
            appURL = "http://www.duckduckgo.com/";

            string browser = "Chrome";
            switch (browser)
            {
                case "Chrome":
                    ChromeOptions headlessChrome = new ChromeOptions();
                     headlessChrome.AddArgument("--headless");
                    driver = new ChromeDriver(headlessChrome);
                    break;
                case "Firefox":
                    FirefoxOptions headlessFireFox = new FirefoxOptions();
                    headlessFireFox.AddArgument("--headless");
                    driver = new FirefoxDriver(headlessFireFox);
                    break;
                case "IE":
                    driver = new InternetExplorerDriver();
                    break;
                default:
                    driver = new ChromeDriver();
                    break;
            }

        }

        [TestCleanup()]
        public void MyTestCleanup()
        {
           driver.Quit();
        }
    }
}