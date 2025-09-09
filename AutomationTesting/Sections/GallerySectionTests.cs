//using Microsoft.Playwright;
//using NUnit.Framework;
//using System.Threading.Tasks;

//namespace AutomationTesting.Sections
//{
//    [TestFixture, Order(5)]  // Run Gallery after Menu
//    [NonParallelizable]

//    public class GallerySectionTests : SectionTestBase
//    {
//        [Test, Order(1)]
//        public async Task Gallery_ShouldRenderHeadingAndNumber()
//        {
//            await ResetState();
//            //await ScrollTo(".gallery");

//            var heading = Page.Locator(".gallery .headings").First;
//            var number = Page.Locator(".gallery .numbers").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(number).ToBeVisibleAsync();

//            string headingText = await heading.InnerTextAsync();
//            string numberText = await number.InnerTextAsync();

//            Assert.That(headingText, Is.EqualTo("Gallery"), "Gallery heading should be 'Gallery'");
//            Assert.That(numberText, Does.Contain("03").IgnoreCase, "Expected section number 03");
//        }

//        [Test, Order(2)]
//        public async Task Gallery_ShouldDisplayImages()
//        {
//            await ResetState();
//            //await ScrollTo(".gallery");

//            var images = Page.Locator(".gallery-images .image-wrapper");
//            await Assertions.Expect(images.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int imgCount = await images.CountAsync();
//            Assert.Greater(imgCount, 0, "Expected at least one image in the gallery");

//            var firstImg = images.First.Locator("img");
//            string src = await firstImg.GetAttributeAsync("src");
//            Assert.IsNotEmpty(src, "Gallery image should have a valid src");
//        }

//        [Test, Order(3)]
//        public async Task Gallery_ClickImage_ShouldOpenModal()
//        {
//            await ResetState();
//            //await ScrollTo(".gallery");

//            var firstImage = Page.Locator(".gallery-images .image-wrapper").First;
//            await firstImage.ClickAsync();

//            var modal = Page.Locator(".lightbox");
//            await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

//            var closeButton = modal.Locator(".close-button");
//            await Assertions.Expect(closeButton).ToBeVisibleAsync();
//        }
//        [Test, Order(4)]
//        public async Task Gallery_Modal_ShouldNavigateNextAndPrev()
//        {
//            await ResetState();
//            //await ScrollTo(".gallery");

//            var images = Page.Locator(".gallery-images .image-wrapper");
//            int imgCount = await images.CountAsync();
//            if (imgCount < 2)
//            {
//                Assert.Inconclusive("Need at least 2 gallery images to test navigation");
//            }

//            // Open first image
//            await images.First.ClickAsync();
//            var modal = Page.Locator(".lightbox");

//            await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

//            var preview = modal.Locator(".preview-image");
//            string srcBefore = await preview.GetAttributeAsync("src");

//            // Click next
//            var nextBtn = modal.Locator(".arrow.right");
//            await nextBtn.ClickAsync();

//            // Poll until src changes
//            string srcAfter = srcBefore;
//            for (int i = 0; i < 10; i++) // 10 attempts * 500ms = 5s
//            {
//                await Task.Delay(500);
//                srcAfter = await preview.GetAttributeAsync("src");
//                if (srcAfter != null && srcAfter != srcBefore)
//                    break;
//            }

//            Assert.AreNotEqual(srcBefore, srcAfter, "Next button should change the preview image");

//            // Click previous
//            var prevBtn = modal.Locator(".arrow.left");
//            await prevBtn.ClickAsync();

//            // Poll until it goes back
//            string srcBack = srcAfter;
//            for (int i = 0; i < 10; i++)
//            {
//                await Task.Delay(500);
//                srcBack = await preview.GetAttributeAsync("src");
//                if (srcBack == srcBefore)
//                    break;
//            }

//            Assert.AreEqual(srcBefore, srcBack, "Prev button should return to the original image");

//            // Close modal
//            var closeBtn = modal.Locator(".close-button");
//            await closeBtn.ClickAsync();
//            await Assertions.Expect(modal).Not.ToBeVisibleAsync();
//        }


//    }
//}

