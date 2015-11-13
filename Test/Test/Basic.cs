using Microsoft.VisualStudio.TestTools.UITesting;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Edge;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace Test
{
    /// <summary>
    /// Summary description for CodedUITest1
    /// </summary>
    [CodedUITest]
    public class ChromeTests
    {
        private OpenQA.Selenium.IWebDriver chromeDriver { get; set; }
        private OpenQA.Selenium.IWebDriver edgeDriver { get; set; }
        private const string WebDriverLocation = "C:\\GitHub";
        public ChromeTests()
        {
            chromeDriver = new ChromeDriver(WebDriverLocation);
            edgeDriver = new EdgeDriver(WebDriverLocation);
        }

        [TestMethod]
        public void GivenNavigationToGooglePageLoads()
        {
            const string pageToGoTo = "https://www.reddit.com/";
            chromeDriver.Navigate().GoToUrl(pageToGoTo);
            Assert.IsTrue(string.Equals(chromeDriver.Url, pageToGoTo, System.StringComparison.OrdinalIgnoreCase));
        }


        [TestMethod]
        public void GivenEdgeBrowserNavigationToGooglePageLoads()
        {
            const string pageToGoTo = "https://www.reddit.com/";
            edgeDriver.Navigate().GoToUrl(pageToGoTo);
            Assert.IsTrue(string.Equals(edgeDriver.Url, pageToGoTo, System.StringComparison.OrdinalIgnoreCase));
        }

        [TestMethod]
        public void GivenNavigationToSeleniumDocsThenSearchForFindMethodDoc()
        {
            const string pageToGoTo = "http://docs.seleniumhq.org/";
            const string questionFieldIdentifier = "q";
            const string searchIdentifier = "submit";
            const string query = "Find";

            chromeDriver
                .Navigate()
                .GoToUrl(pageToGoTo);

            var question = chromeDriver.FindElement(By.Id(questionFieldIdentifier));
            question.SendKeys(query);

            var search = chromeDriver.FindElement(By.Id(searchIdentifier));
            search.Click();

            var wait = new WebDriverWait(chromeDriver, new System.TimeSpan(0, 0, 5));
            wait.Until(x => x.Url != pageToGoTo);
            Assert.IsFalse(string.Equals(pageToGoTo, chromeDriver.Url, System.StringComparison.InvariantCultureIgnoreCase));
        }

        #region Additional test attributes

        // You can use the following additional attributes as you write your tests:

        ////Use TestInitialize to run code before running each test 
        //[TestInitialize()]
        //public void MyTestInitialize()
        //{        
        //    // To generate code for this test, select "Generate Code for Coded UI Test" from the shortcut menu and select one of the menu items.
        //}

        //Use TestCleanup to run code after each test has run
        [TestCleanup()]
        public void MyTestCleanup()
        {
            chromeDriver.Close();
            edgeDriver.Close();
        }

        #endregion

    }
}
