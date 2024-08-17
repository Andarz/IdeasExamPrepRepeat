using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IdeasTests.Pages
{
	public class CreatePage : BasePage
	{
        public CreatePage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Ideas/Create";

        public IWebElement TitleInput => driver.FindElement(By.Id("form3Example1c"));
        public IWebElement PictureUrlInput => driver.FindElement(By.Id("form3Example3c"));
        public IWebElement DescriptionInput => driver.FindElement(By.Id("form3Example4cd"));
        public IWebElement CreateButton => driver.FindElement(By.XPath("//button[text()='Create']"));
        public IWebElement MainErrorMessage => driver.FindElement(By.XPath("//li[text()='Unable to create new Idea!']"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }

        public void AssertMainErrorMessage()
        {
            Assert.That(MainErrorMessage.Text, Is.EqualTo("Unable to create new Idea!"));
        }
    }
}
