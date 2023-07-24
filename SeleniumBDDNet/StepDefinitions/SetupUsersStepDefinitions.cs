using System;
using TechTalk.SpecFlow;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium.Interactions;
using SeleniumBDDNet.PageObjects;

namespace SeleniumBDDNet.StepDefinitions
{
    [Binding]
    public class SetupUsersStepDefinitions
    {
        ScenarioContext scenarioContext;
       

        [Given(@"application is open in browser")]
        public void GivenApplicationIsOpenInBrowser()
        {

            LoginPage loginPage = new LoginPage();
            loginPage.openApplicaiton();
        }

        [When(@"i enter username and password")]
        public void WhenIEnterUsernameAndPassword()
        {
            Console.WriteLine("This is test application");
        }

        [When(@"i click on login button")]
        public void WhenIClickOnLoginButton()
        {
            Console.WriteLine("This is test application");
        }

        [Then(@"i should be logged into application")]
        public void ThenIShouldBeLoggedIntoApplication()
        {
            Console.WriteLine("This is test application");
        }
    }
}
