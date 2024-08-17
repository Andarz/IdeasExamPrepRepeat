using OpenQA.Selenium;

namespace IdeasTests.Pages
{
	public class MyIdeasPage : BasePage
	{
        public MyIdeasPage(IWebDriver driver) : base(driver)
        {
            
        }

        public string Url => BaseUrl + "/Ideas/MyIdeas";

        public IReadOnlyCollection<IWebElement> ideas => driver.FindElements(By.XPath("//div[@class='col-md-4']"));
        public IWebElement LastIdeaDescription => ideas.Last().FindElement(By.CssSelector(".card-text"));
        public IWebElement LastIdeaViewButton => ideas.Last().FindElement(By.XPath(".//a[contains(@href, '/Ideas/Read')]"));

        public void OpenPage()
        {
            driver.Navigate().GoToUrl(Url);
        }
    }
}
