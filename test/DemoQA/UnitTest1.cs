using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace SeleniumTests
{
    [TestFixture]
    public class TestRegistration
    {
        private IWebDriver driver;
        private StringBuilder verificationErrors;
        private string baseURL;
        private bool acceptNextAlert = true;

        [SetUp]
        public void SetupTest()
        {
            driver = new FirefoxDriver();
            baseURL = "http://demoqa.com/";
            verificationErrors = new StringBuilder();
        }

        [TearDown]
        public void TeardownTest()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
            Assert.AreEqual("", verificationErrors.ToString());
        }

        [Test]
        public void TheRegistrationTest()
        {


            // var i
            var rand = new Random();
            var i = rand.Next(1, 100000);
            var j = rand.Next(1, 100000);

            driver.Navigate().GoToUrl(baseURL + "");
            driver.Manage().Window.Maximize();
            //ubaciti 
            //Driver.Wait.Until(ExpectedConditions.ElementIsVisible(By.Id("softwareList")));
            Thread.Sleep(1000);
            driver.FindElement(By.LinkText("Registration")).Click();
            Assert.AreEqual("Registration | Demoqa", driver.Title);
            driver.FindElement(By.Id("name_3_firstname")).SendKeys("TestName" + i);
            driver.FindElement(By.Id("name_3_lastname")).SendKeys("TestLastName" + j);
            driver.FindElement(By.Name("radio_4[]")).Click();
            driver.FindElement(By.XPath("(//input[@name='checkbox_5[]'])[2]")).Click();
            new SelectElement(driver.FindElement(By.Id("dropdown_7"))).SelectByText("Bahrain");
            new SelectElement(driver.FindElement(By.Id("mm_date_8"))).SelectByText("6");
            new SelectElement(driver.FindElement(By.Id("dd_date_8"))).SelectByText("5");
            new SelectElement(driver.FindElement(By.Id("yy_date_8"))).SelectByText("2006");
            driver.FindElement(By.Id("phone_9")).SendKeys("3854578596321");
            driver.FindElement(By.Id("username")).SendKeys("testuser" + i);
            driver.FindElement(By.Id("email_1")).SendKeys("testuser" + i + "@test.com");
            driver.FindElement(By.Id("description")).SendKeys("test user " + i);
            driver.FindElement(By.Id("password_2")).SendKeys("Test987654321");
            driver.FindElement(By.Id("confirm_password_password_2")).SendKeys("Test987654321");
            Assert.AreEqual("Very weak", driver.FindElement(By.Id("piereg_passwordStrength")).Text);
            driver.FindElement(By.Name("pie_submit")).Click();
            Assert.AreEqual("Thank you for your registration", driver.FindElement(By.CssSelector("p.piereg_message")).Text);
        }
        private bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }

        private bool IsAlertPresent()
        {
            try
            {
                driver.SwitchTo().Alert();
                return true;
            }
            catch (NoAlertPresentException)
            {
                return false;
            }
        }

        private string CloseAlertAndGetItsText()
        {
            try
            {
                IAlert alert = driver.SwitchTo().Alert();
                string alertText = alert.Text;
                if (acceptNextAlert)
                {
                    alert.Accept();
                }
                else
                {
                    alert.Dismiss();
                }
                return alertText;
            }
            finally
            {
                acceptNextAlert = true;
            }
        }
    }
}
