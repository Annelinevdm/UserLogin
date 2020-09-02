using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Interactions;
using System;

namespace UserLogin
{
    [TestClass]
    public class UserLogin
    {
        IWebDriver driver = new ChromeDriver(@"C:\\Users\\Anneline\\source\\repos\\");
        [SetUp]
        public void Setup()
        {
            driver.Navigate().GoToUrl("https://cams.azurewebsites.net/");
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            //****************Old code*******************************************
            //Take this code out when Login Page is correct
            //IWebElement LogInButton = driver.FindElement(By.CssSelector("body > div.lp-content.h-100 > div.card > div.card-body > form > input.btn.btn-primary"));
            //LogInButton.Click();
            
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            Console.WriteLine(driver.Title);
        }
        [TestCase]
        public void Login()
        {

            IWebElement UserName = driver.FindElement(By.Id("LoginInput_UserNameOrEmailAddress"));
            UserName.SendKeys("admin");
            IWebElement PassWord = driver.FindElement(By.Id("LoginInput_Password"));
            PassWord.SendKeys("1q2w3E*");
            IWebElement LoginButton2 = driver.FindElement(By.CssSelector("body > div.d-flex.align-items-center > div > div > div > div.card > div.card-body > div > form > button"));
            LoginButton2.Click();
        }
        [TearDown]
        public void Logout()
        {
            Actions action1 = new Actions(driver);
            action1.MoveToElement(driver.FindElement(By.Id("dropdownMenuUser"))).Build().Perform();
            IWebElement manageProfile = driver.FindElement(By.Id("MenuItem_Account.Logout"));
            manageProfile.Click();
            driver.Quit();
        }
         
    }
}
