using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumBDDNet.Drivers
{
    class Browsers
    {
        private static IWebDriver driver;


        public static void Init(string browserName) {    


        switch (browserName)
            {
                case "chrome":
                    //Need to use webdriver manager to get specific driver 
                    driver = new ChromeDriver();
                    break;
                case "firefox":
                    driver = new FirefoxDriver();
                    break;
            }
            driver.Manage().Window.Maximize();
        }

        public static IWebDriver getDriver
        {
            get { return driver; }
        }

                
    }



}
