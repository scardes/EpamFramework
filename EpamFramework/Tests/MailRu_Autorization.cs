using EpamWebDriver.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.IO;

/// <summary>
/// Selenium test project with two emails 
/// first email on https://account.mail.ru/
/// </summary>
namespace ExampleService.Tests
{
    [TestFixture]
    public class MailRu_Autorization
    {
        public class NunitSetupAutorization
        {
            IWebDriver driver;

            [OneTimeSetUp]
            public void Setup()
            {
                //Below code is to get the drivers folder path dynamically.
                string path = Directory.GetParent(Environment.CurrentDirectory).Parent.Parent.FullName;

                //Creates the ChomeDriver object, Executes tests on Google Chrome
                driver = new ChromeDriver(path + @"\Drivers\");

                // Make full autorization on mail.ru
                var autorizationMailru = new MailRuAutorizationPageObjects(driver);
                autorizationMailru.AutorizationInMailRU("epamtestmail93@mail.ru", "EpamTest185");
            }

            [Test, Order(1)]
            public void Authorization_WithCorrectEmailPassword_AuthorizationSuccess()
            {
                //Success of authorization
                Assert.AreEqual("Авторизация", driver.Title);
            }


            // runs once after all tests finished
            [OneTimeTearDown]
            public void Dispose()
            {
                // close down the browser
                driver.Quit();
                driver.Dispose();
            }
        }
    }
}