using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasTests.Pages
{
	public class LoginPage : BasePage
	{
        public LoginPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Users/Login";

        public IWebElement EmailInput => driver.FindElement(By.XPath("//input[@id='typeEmailX-2']"));
        public IWebElement PasswordInput => driver.FindElement(By.XPath("//input[@id='typePasswordX-2']"));
        public IWebElement SubmitButton => driver.FindElement(By.XPath("/html/body/section/div/div/div/div/form/button[1]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void PerformLogin(string email, string password)
        {
            EmailInput.Clear();
            EmailInput.SendKeys(email);

            PasswordInput.Clear();
            PasswordInput.SendKeys(password);

            SubmitButton.Click();
        }
	}
}
