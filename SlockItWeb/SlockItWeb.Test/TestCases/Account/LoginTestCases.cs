using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;

namespace TestCases.Account
{
    [TestClass]
    public class LoginTestCases
    {
        [TestMethod]
        public void Login_IncorrectCredentials_WillShowErrorStatusMessage()
        {
            ChromeDriver driver = new ChromeDriver();
            try
            {
                string url = "http://localhost:53101/account/login.aspx";
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("MainContent_txtEmail")).SendKeys("Admin@admin.com");
                driver.FindElement(By.Id("MainContent_txtPassword")).SendKeys("password");
                driver.FindElement(By.Id("MainContent_btnLogin")).Click();
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                IWebElement result = wait.Until(wt => wt.FindElement(By.Id("MainContent_lblStatus")));
                Assert.AreEqual("Login and/or password mismatch.", result.Text);
                driver.Close();
                driver.Dispose();
            }
            catch (Exception ex)
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile("Login_IncorrectCredentials_WillShowErrorStatusMessage.png", ScreenshotImageFormat.Png);
                driver.Quit();
                Assert.Fail(ex.Message);
            }
        }

        [TestMethod]
        public void Login_CorrectCredentials_WillShowMainDashboard()
        {
            ChromeDriver driver = new ChromeDriver();
            try
            {
                string url = "http://localhost:53101/account/login.aspx";
                driver.Navigate().GoToUrl(url);
                driver.Manage().Window.Maximize();
                driver.FindElement(By.Id("MainContent_txtEmail")).SendKeys("test@test.it");
                driver.FindElement(By.Id("MainContent_txtPassword")).SendKeys("testit");
                driver.FindElement(By.Id("MainContent_btnLogin")).Click();
                WebDriverWait wait = new WebDriverWait(driver, new TimeSpan(0, 0, 5));
                IWebElement result = wait.Until(wt => wt.FindElement(By.Id("sidebar-collapse")));
                Assert.IsTrue(true);
                driver.Close();
                driver.Dispose();
            }
            catch (Exception ex)
            {
                ITakesScreenshot screenshotDriver = driver as ITakesScreenshot;
                Screenshot screenshot = screenshotDriver.GetScreenshot();
                screenshot.SaveAsFile("Login_CorrectCredentials_WillShowMainDashboard.png", ScreenshotImageFormat.Png);
                driver.Quit();
                Assert.Fail(ex.Message);
            }
        }
    }
}
