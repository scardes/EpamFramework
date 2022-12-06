using NUnit.Framework;

/// <summary>
/// Autorization on Mail.ru 
/// </summary>
namespace ExampleService.Tests
{
    [TestFixture]
    public class MailRu_Autorization 
    {
        public class MailCorrectAutorization : CommonConditions.NunitSetupAutorization
        {
            
            [Test, Order(1)]
            public void Authorization_WithCorrectEmailPassword_AuthorizationSuccess()
            {
                //Success of authorization
                Assert.AreEqual("Авторизация", driver.Title);
            }
          
        }
    }
}