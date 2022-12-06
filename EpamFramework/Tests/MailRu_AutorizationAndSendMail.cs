using EpamFramework.BusinessObjects;
using EpamWebDriver;
using EpamWebDriver.PageObjects;
using NUnit.Framework;

/// <summary>
/// Selenium test project with two emails 
/// first email on https://account.mail.ru/
/// </summary>
namespace ExampleService.Tests
{
    [TestFixture]
    public class MailRu_AutorizationAndSendMail : CommonConditions
    {
        User testUserSuccess = new User("epamtestmail93@mail.ru", "EpamTest185");
        User testUserError = new User("123@mail.ru", "123");

        [Test, Order(1)]
        public void LoadMailInBrowser_ClickSignUp_LoadSuccess()
        {
            // Open mail.ru page
            var autorizationMailru = new MailRuAutorizationPageObjects(driver);
            autorizationMailru.AutorizationInMailRU();

            //Check window is loaded
            Assert.AreEqual("Account Mail.Ru", driver.Title);
        }

        [Test, Order(2)]
        public void Authorization_WithEmptyEmailPassword_AuthorizationError()
        {
            // Open mail.ru page again with empty login data
            var autorizationMailru = new MailRuAutorizationPageObjects(driver);
            autorizationMailru.AutorizationInMailRU("");

            //Take a error of empty username/email address
            autorizationMailru.AssertPopUpEmptyError();
        }

        [Test, Order(3)]
        public void Authorization_WithErrorEmailPassword_AuthorizationError()
        {
            //  Open mail.ru page again for incorrent data
            var autorizationMailru = new MailRuAutorizationPageObjects(driver);
            autorizationMailru.AutorizationInMailRU(testUserError);

            //And catch error of authorization
            autorizationMailru.AssertPopUpInputError();
        }

        [Test, Order(4)]
        public void Authorization_WithCorrectEmailPassword_AuthorizationSuccess()
        {
            // Make full autorization on mail.ru
            var autorizationMailru = new MailRuAutorizationPageObjects(driver);
            autorizationMailru.AutorizationInMailRU(testUserSuccess);

            //And success of authorization
            Assert.AreEqual("Авторизация", driver.Title);
        }

        [Test, Order(5)]
        public void SendEmail_WithSomeInformation_SendSuccess()
        {
            // Make full autorization on mail.ru
            var autorizationMailru = new MailRuAutorizationPageObjects(driver);
            autorizationMailru.AutorizationInMailRU(testUserSuccess);
            WebDriverExtensions.WaitSomeInterval(7);

            //Fill SendEmailFromMailRU with 1.email receiver 2.Theme of letter 3.letter content and then send email
            MailRuSendMailPageObjects SendMail = new MailRuSendMailPageObjects(driver);
            SendMail.SendEmailFromMailRU("testepammail@yandex.ru", "Test Letter From mail.ru", "Content of test letter");
        }
        
    }
}