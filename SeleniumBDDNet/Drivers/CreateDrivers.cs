using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace SeleniumBDDNet.Drivers
{


    class CreateDrivers : Drivers
    {

        public WebDriver? driver;
        public override WebDriver createDriver(string driverType)
        {
            switch (driverType)
            {
                case "chrome":
                    driver = new ChromeDriverManager().createDriver();
                    break;
                case "firefox":
                    driver = new FireFoxDriverManager().createDriver();
                    break;
                default:
                    throw new Exception("Bowser not foung " + driverType);
            }

            return driver;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }


        public WebDriver getDriver(string driverType)
        {

            if (driver == null)
            {
                driver = createDriver(driverType);

            }
            return driver;

        }

    }
}
