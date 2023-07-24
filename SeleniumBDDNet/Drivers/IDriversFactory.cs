using OpenQA.Selenium;
using OpenQA.Selenium.DevTools.V112.Target;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDNet.Drivers
{
    internal interface IDriversFactory
    {
        public WebDriver createDriver();
    }
}
