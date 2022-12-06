using NUnit.Framework;

/// <summary>
/// Autorization on Mail.ru 
/// </summary>
namespace ExampleService.Tests
{
    [TestFixture]
    public class MailRu_Autorization : CommonConditions
    {
        [Test, Order(1)]
        public void Authorization_WithCorrectEmailPassword_AuthorizationSuccess()
        {
            //Success of authorization
            Assert.AreEqual("Авторизация", driver.Title);
        }
          
    }
}