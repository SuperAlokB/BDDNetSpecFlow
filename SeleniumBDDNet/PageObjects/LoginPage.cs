using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AventStack.ExtentReports;
using OpenQA.Selenium;
using SeleniumBDDNet.Drivers;

namespace SeleniumBDDNet.PageObjects
{

   

    class LoginPage : BasePage
    {
        WebDriver webDriver;

        public LoginPage() => webDriver = getWebDriver();
        public void openApplicaiton()
        {
            webDriver.Navigate().GoToUrl("https://google.com");
           
        }


    }
}
