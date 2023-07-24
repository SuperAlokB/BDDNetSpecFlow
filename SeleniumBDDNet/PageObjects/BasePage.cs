using OpenQA.Selenium;
using RazorEngine.Compilation.ImpromptuInterface.Dynamic;
using SeleniumBDDNet.Drivers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDriverManager;

namespace SeleniumBDDNet.PageObjects
{
    internal class BasePage
    {

        CreateDrivers createDriver = new CreateDrivers();
        WebDriver webDriver;
        string driverType = "chrome";
        public BasePage()
        {

            webDriver = createDriver.createDriver(driverType);
        }

        public WebDriver getWebDriver()
        {
           return createDriver.getDriver(driverType);
        }

    }
}
