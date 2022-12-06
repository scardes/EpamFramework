using EpamFramework.BusinessObjects;
using EpamWebDriver.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.IO;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;


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
            public static NUnit.Framework.TestContext CurrentContext { get; }

            [OneTimeSetUp]
            public void Setup()
            {
                // The properties are read from the .runsettings file
                string driverParam = TestContext.Parameters["browser"];
                string userMailParam = TestContext.Parameters["userMail"];
                string userPassParam = TestContext.Parameters["userPass"];
                
                switch (driverParam) 
                {
                    case "chrome":
                        new DriverManager().SetUpDriver(new ChromeConfig());
                        driver = new ChromeDriver();
                        break;
                    case "firefox":
                        new DriverManager().SetUpDriver(new FirefoxConfig());
                        driver = new FirefoxDriver();
                        break;
                }

                // Make full autorization on mail.ru
                User testUser = new User(userMailParam, userPassParam);
                MailRuAutorizationPageObjects autorizationMailru = new MailRuAutorizationPageObjects(driver);

                autorizationMailru.AutorizationInMailRU(testUser);
            }


            [Test, Order(1)]
            public void Authorization_WithCorrectEmailPassword_AuthorizationSuccess()
            {
                //Success of authorization
                Assert.AreEqual("Авторизация", driver.Title);
            }

            [Test, Order(2)]
            public void TestRunsettingParameters()
            {
                //Arrange
                string expectedUrl = "chrome";

                // Act
                // The properties are read from the .runsettings file
                string actualUrl = TestContext.Parameters["browser"];

                // Assert
                Assert.AreEqual(expectedUrl, actualUrl);
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