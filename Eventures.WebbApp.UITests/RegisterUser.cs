using Eventures.Tests.Common;
using Eventures.WebApp;
using Microsoft.Win32;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Security.Principal;

namespace Eventures.WebbApp.UITests
{
    public class RegisterUser: BaseTests
    { 
        private string userEmail = DateTime.Now.Ticks.ToString();
        private string userPassword = DateTime.Now.Ticks.ToString();
        private string username = DateTime.Now.Ticks.ToString().Substring(12);
        private string firstName = DateTime.Now.Ticks.ToString().Substring(12);

        public IWebElement inputUsername => driver.FindElement(By.Id("Input_Username"));
        public IWebElement inputEmail => driver.FindElement(By.Id("Input_Email"));
        public IWebElement inputPassword => driver.FindElement(By.Id("Input_Password"));
        public IWebElement inputConfirmPassword => driver.FindElement(By.Id("Input_ConfirmPassword"));
        public IWebElement inputFirstName => driver.FindElement(By.Id("Input_FirstName"));
        public IWebElement inputLastName => driver.FindElement(By.Id("Input_LastName"));
        public IWebElement registerBtn => driver.FindElement(By.XPath("//button[@type='submit'][contains(.,'Register')]"));


        [Test]
        public void Test_RegisterPageTitle()
        {
            driver.Url = baseUrl;
            var linkRegister = driver.FindElement(By.LinkText("Register"));
            linkRegister.Click(); driver.FindElement(By.Id("Input_ConfirmPassword"));

            Assert.That(driver.Title, Is.EqualTo("Register - Eventures App"));
        }

        [Test]
        public void Test_RegisterValidUser()
        {
            driver.Navigate().GoToUrl(baseUrl + "/Identity/Account/Register");

            inputUsername.SendKeys(username);
            inputEmail.SendKeys(userEmail+"@test.com");
            inputPassword.SendKeys(userPassword);
            inputConfirmPassword.SendKeys(userPassword);
            inputFirstName.SendKeys(firstName);
            inputLastName.SendKeys("Last Name");
            registerBtn.Click();

            var labelName = driver.FindElement(By.XPath("(//a[@class='nav-link text-dark'])[1]"));
            Assert.That(labelName.Text, Is.EqualTo("Hello " + username + "!"));
        }
    }
}