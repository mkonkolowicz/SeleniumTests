using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
// TODO Need to figure out how to return new page objects from actions
namespace Tests
{
    [TestFixture]
    public class Chrome
    {   
        private static string DriverLocation = "C:\\GitHub\\Selenium\\SeleniumTests";
        private static string WebSite = "http://www.google.com";
        IWebDriver driver = new ChromeDriver(DriverLocation);

        [Test]
        public void WhenPageLoadsThenElementsExist()
        {
            driver.Navigate().GoToUrl(WebSite);
            var model = new GoogleSearchModel(driver);
            model.SearchCriteria.SendKeys("Maciek");
            model.SearchCriteria.SendKeys(Keys.Enter);
        }

        [SetUp]
        public void Initialize()
        {

        }

        [TearDown]
        public void tearDown()
        {
            driver.Quit();
        }
    }
    public interface IGoogleSearch
    {
        IWebElement Search { get; }
        IWebElement SearchCriteria { get; }
    }
    public class GoogleSearchModel : IGoogleSearch
    {
        IWebDriver driver;
        public GoogleSearchModel(IWebDriver driver)
        {
            this.driver = driver;
        }
        public IWebElement SearchCriteria
        {
            get
            {
                return driver.FindElement(By.XPath("/html/body[@id='gsr']/div[@id='viewport']/div[@id='searchform']/form[@id='tsf']/div[@class='tsf-p']/div[@class='sfibbbc']/div[@id='sbtc']/div[@class='sbibtd']/div[@id='sfdiv']/div[@class='gstl_0 sbib_a']/div[@id='sb_ifc0']/div[@id='gs_lc0']/input[@id='lst-ib']"));
            }
        }
        public IWebElement Search
        {
            get
            {
                return (driver.FindElement(By.XPath("/html/body[@id='gsr']/div[@id='viewport']/div[@id='searchform']/form[@id='tsf']/div[@class='tsf-p']/div[@class='jsb']/center/input[1]")));
            }
        }
    }

}
