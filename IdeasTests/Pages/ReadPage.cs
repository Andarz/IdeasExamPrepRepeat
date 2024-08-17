﻿using OpenQA.Selenium;

namespace IdeasTests.Pages
{
	public class ReadPage : BasePage
	{
        public ReadPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Ideas/Read";

		public IWebElement IdeaTitle =>
		   driver.FindElement(By.XPath("//h1[@class='mb-0 h4']"));

		public IWebElement IdeaDescription =>
		   driver.FindElement(By.XPath("//p[@class='offset-lg-3 col-lg-6']"));
	}
}