using OpenQA.Selenium;

namespace IdeasTests.Tests
{
	public class IdeasTests : BaseTest
	{
		private static string? createdIdeaTitle;
		private static string? createdIdeaDescription;

		[Test, Order(1)]
		public void CreateIdeaWithInvalidData_Test()
		{
			createPage.OpenPage();

			createPage.TitleInput.Clear();
			createPage.DescriptionInput.Clear();
			createPage.CreateButton.Click();

			createPage.AssertMainErrorMessage();
		}

		[Test, Order(2)]
		public void CreateRandomIdea_Test()
		{
			createdIdeaTitle = GenerateRandomString(5);
			createdIdeaDescription = GenerateRandomString(10);

			createPage.OpenPage();

			createPage.TitleInput.Clear();
			createPage.TitleInput.SendKeys(createdIdeaTitle);

			createPage.DescriptionInput.Clear();
			createPage.DescriptionInput.SendKeys(createdIdeaDescription);
			
			createPage.CreateButton.Click();

			Assert.That(driver.Url, Is.EqualTo(myIdeasPage.Url));
			Assert.That(myIdeasPage.LastIdeaDescription.Text, Is.EqualTo(createdIdeaDescription));
		}

		[Test, Order(3)]
		public void ViewLastCreatedIdea_Test()
		{
			myIdeasPage.OpenPage();

			var lastIdea = myIdeasPage.ideas.Last();

			actions.ScrollToElement(lastIdea).Perform();
			actions.MoveToElement(myIdeasPage.LastIdeaViewButton).Perform();

			myIdeasPage.LastIdeaViewButton.Click();

			Assert.That(readPage.IdeaTitle.Text, Is.EqualTo(createdIdeaTitle));
		}
	}
}
