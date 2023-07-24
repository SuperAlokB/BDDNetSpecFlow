using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Chrome;
using WebDriverManager.DriverConfigs.Impl;
using OpenQA.Selenium.Firefox;

namespace SeleniumBDDNet.Drivers
{
    abstract class Drivers
    {
        public abstract WebDriver createDriver(string driverType);

    }
}
