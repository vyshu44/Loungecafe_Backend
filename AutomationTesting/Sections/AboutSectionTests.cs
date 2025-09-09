//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(3)]  // Run About after Intro
//    [NonParallelizable]

//    public class AboutSectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task About_ShouldRenderHeadingAndNumber()
//        {
//            await ResetState();

//            var heading = Page.Locator(".about .headings").First;
//            var number = Page.Locator(".about .numbers").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(number).ToBeVisibleAsync();

//            string headingText = await heading.InnerTextAsync();
//            string numberText = await number.InnerTextAsync();

//            Assert.IsNotEmpty(headingText, "About heading should not be empty");
//            Assert.That(numberText, Does.Contain("01").IgnoreCase, "Expected section number 01");
//        }

//        [Test, Order(2)]
//        public async Task About_ShouldDisplayImage()
//        {
//            await ResetState();


//            var img = Page.Locator(".about .img3").First;

//            await Assertions.Expect(img).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string src = await img.GetAttributeAsync("src");
//            Assert.IsNotEmpty(src, "About section image should have a source");
//        }

//        [Test, Order(3)]
//        public async Task About_ShouldShowDescriptionParagraphs()
//        {
//            await ResetState();

//            var paragraphs = Page.Locator(".about .text p");

//            await Assertions.Expect(paragraphs.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int count = await paragraphs.CountAsync();
//            Assert.Greater(count, 0, "Expected at least one description paragraph");

//            for (int i = 0; i < count; i++)
//            {
//                string text = (await paragraphs.Nth(i).InnerTextAsync()).Trim();
//                Assert.IsNotEmpty(text, $"Paragraph {i + 1} should not be empty");
//            }
//        }
//    }
//}
