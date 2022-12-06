using EpamFramework.BusinessObjects;
using EpamWebDriver.PageObjects;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

/// <summary>
/// Selenium test project with two emails 
/// first email on https://account.mail.ru/
/// </summary>
namespace ExampleService.Tests
{
    [TestFixture]
    public class CommonConditions
    {
        protected IWebDriver driver;
        public static NUnit.Framework.TestContext CurrentContext { get; }

        // The properties are read from the .runsettings file
        string driverParam = TestContext.Parameters["browser"];
        string userMailParam = TestContext.Parameters["userMail"];
        string userPassParam = TestContext.Parameters["userPass"];

        [OneTimeSetUp]
        public void Setup()
        {

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