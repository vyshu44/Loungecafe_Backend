//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(6)]
//    [NonParallelizable]

//    public class DescriptionSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task Description_ShouldRenderHeading()
//        {
//            await ResetState();
//            //await ScrollTo(".description");

//            var heading = Page.Locator("p.description").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string headingText = await heading.InnerTextAsync();
//            Assert.That(headingText, Is.EqualTo("What Our Clients Say"), "Description section heading mismatch");
//        }

//        [Test, Order(2)]
//        public async Task Description_ShouldDisplayAtLeastOneClient()
//        {
//            await ResetState();
//            //await ScrollTo(".description");

//            var clientCard = Page.Locator(".list-of-clients > div").First;

//            await Assertions.Expect(clientCard).ToBeVisibleAsync(new() { Timeout = 10000 });

//            // Check client image
//            var clientImage = clientCard.Locator("img");
//            await Assertions.Expect(clientImage).ToBeVisibleAsync();
//            string src = await clientImage.GetAttributeAsync("src");
//            Assert.IsNotEmpty(src, "Client image should have a source");

//            // Check client name
//            var clientName = await clientCard.Locator("p").First.InnerTextAsync();
//            Assert.IsNotEmpty(clientName, "Client name should not be empty");

//            // Check client description
//            var clientDesc = await clientCard.Locator(".client-data").InnerTextAsync();
//            Assert.IsNotEmpty(clientDesc, "Client description should not be empty");
//        }

//        [Test, Order(3)]
//        public async Task Description_ShouldHaveDotsForNavigation()
//        {
//            await ResetState();
//            //await ScrollTo(".description");

//            var dots = Page.Locator(".dots .dot");

//            int dotCount = await dots.CountAsync();
//            Assert.Greater(dotCount, 0, "Expected at least one dot for navigation");

//            // Check active dot
//            var activeDot = Page.Locator(".dots .dot.activedot");
//            await Assertions.Expect(activeDot).ToBeVisibleAsync(new() { Timeout = 5000 });
//        }
//    }
//}
