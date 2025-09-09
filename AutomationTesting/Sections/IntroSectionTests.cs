//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(2)]  // Run Intro first
//    [NonParallelizable]

//    public class IntroSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task Intro_ShouldRenderWelcomeAndName()
//        {
//            await ResetState();

//            var welcome = Page.Locator("p.welcome");
//            var name = Page.Locator("h1.big");

//            await Assertions.Expect(welcome).ToBeVisibleAsync();
//            await Assertions.Expect(name).ToBeVisibleAsync();

//            var welcomeText = await welcome.InnerTextAsync();
//            var nameText = await name.InnerTextAsync();

//            Assert.IsNotEmpty(welcomeText, "Welcome text should not be empty");
//            Assert.IsNotEmpty(nameText, "Name text should not be empty");
//        }

//        [Test, Order(2)]
//        public async Task Intro_ShouldShowImagesAndParagraph()
//        {
//            await ResetState();

//            var img1 = Page.Locator("img.img1");
//            var img2 = Page.Locator("img.img2");
//            var paragraph = Page.Locator("p.paragraph");

//            await Assertions.Expect(img1).ToBeVisibleAsync();
//            await Assertions.Expect(img2).ToBeVisibleAsync();
//            await Assertions.Expect(paragraph).ToContainTextAsync("Savor moments of bliss");
//        }

//        [Test, Order(3)]
//        public async Task Intro_ShouldDisplaySocialMediaLinks()
//        {
//            await ResetState();

//            var tags = Page.Locator(".tags a");

//            await Assertions.Expect(tags.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int count = await tags.CountAsync();
//            Assert.Greater(count, 0, "Expected at least one social media link");

//            for (int i = 0; i < count; i++)
//            {
//                string text = (await tags.Nth(i).InnerTextAsync()).Trim();
//                Assert.IsNotEmpty(text, "Social media link should have text");
//            }
//        }

//        [Test, Order(4)]
//        public async Task Intro_ScrollCircle_ShouldBeClickable()
//        {
//            await ResetState();

//            var circle = Page.Locator(".scroll-text-circle .center-icon");

//            await Assertions.Expect(circle).ToBeVisibleAsync();
//            await circle.ClickAsync();

//            Assert.Pass("Scroll circle was clickable without errors");
//        }
//    }
//}
