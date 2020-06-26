using Cycles.Test.Cycles;
using NUnit.Framework;

namespace Cycles.Test
{
    public class AuthTests
    {
        [Test]
        public void CSharpEventAndStateTest()
        {
            var authCycle = new AuthCycle();
        
            void ErrorAssertion(User user)
            {
                Assert.AreEqual(AuthCycle.ERROR_MESSAGE, user.error);
                Assert.AreEqual(false, user.isLogged);
            }

            void SuccessAssertion(User user)
            {
                Assert.AreEqual("John Doe", user.name);
                Assert.AreEqual(AuthCycle.VALID_USERNAME, user.username);
                Assert.AreEqual(true, user.isLogged);
                Assert.AreEqual(null, user.error);
            }

            void LogOutAssertion(User user)
            {
                Assert.AreEqual(null, user.name);
                Assert.AreEqual(null, user.username);
                Assert.AreEqual(false, user.isLogged);
                Assert.AreEqual(null, user.error);
            }
            
            authCycle.OnError += ErrorAssertion;
            authCycle.OnSuccess += SuccessAssertion;
            authCycle.OnLogout += LogOutAssertion;
            
            authCycle.Login("ted", "bear");
            Assert.AreEqual(AuthState.LoginError, authCycle.State);

            authCycle.Login(AuthCycle.VALID_USERNAME, AuthCycle.VALID_PASSWORD);
            Assert.AreEqual(AuthState.Logged, authCycle.State);
            
            authCycle.Logout();
            Assert.AreEqual(AuthState.Logout, authCycle.State);
        }
    }
}