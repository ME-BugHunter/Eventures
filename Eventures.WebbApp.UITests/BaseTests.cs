using Eventures.Tests.Common;
using Eventures.WebApp;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Eventures.WebbApp.UITests
{
    public class BaseTests
    {
        protected WebDriver driver;
        private ChromeOptions chromeOptions;
        private TestDb testDb;
        private TestEventuresApp<Startup> testEventuresApp;
        protected string baseUrl;

        [SetUp]
        public void Setup()
        {
            this.testDb = new TestDb();
            this.testEventuresApp = new TestEventuresApp<Startup>(testDb, "../../../../Eventures.WebApp");
            this.chromeOptions= new ChromeOptions();
            chromeOptions.AddArgument("--headless");
            this.driver = new ChromeDriver(chromeOptions);
            driver.Manage().Window.Maximize();
            this.baseUrl = testEventuresApp.ServerUri;
        }

        [TearDown]
        public void CloseApp()
        {
            driver.Quit();
            testEventuresApp.Dispose();
        }

    }
}
