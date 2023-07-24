using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager.DriverConfigs.Impl;
using WebDriverManager;

namespace SeleniumBDDNet.Drivers
{
    public class ChromeDriverManager : IDriversFactory
    {
        private WebDriver? driver = null;

        public WebDriver createDriver()
        {
            var options = new ChromeOptions();
            Dictionary<string, object> browserStackOptions = new Dictionary<string, object>();
            browserStackOptions.Add("unhandledPromptBehavior", "ignore");
            options.AddAdditionalOption("bstack:options", browserStackOptions);

            //new DriverManager().SetUpDriver(new ChromeConfig(), "114.0");

            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());
            driver = new ChromeDriver();
            return driver;
        }
    }
}
