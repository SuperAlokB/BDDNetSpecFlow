using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDNet.Drivers
{
    internal class FireFoxDriverManager : IDriversFactory
    {
        WebDriver? driver;
        public WebDriver createDriver()
        {
            WebDriver driver = new FirefoxDriver();
            return driver;
        }
    }
}
