//code to run only testcases

//using Microsoft.Playwright;
//using NUnit.Framework;
//using System;
//using System.Text.RegularExpressions;
//using System.Threading.Tasks;

//namespace AutomationTesting
//{
//    public abstract class BaseTest
//    {
//        protected static IPlaywright Playwright;
//        protected static IBrowser Browser;
//        protected static IBrowserContext Context;
//        protected static IPage Page;

//        protected abstract IBrowserType GetBrowserType(IPlaywright playwright);
//        protected abstract string GetChannel();

//        [OneTimeSetUp]
//        public async Task GlobalSetup()
//        {
//            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

//            Browser = await GetBrowserType(Playwright).LaunchAsync(new()
//            {
//                Channel = GetChannel(),
//                Headless = false,
//                SlowMo = 600
//            });

//            Context = await Browser.NewContextAsync();
//            Page = await Context.NewPageAsync();
//            await Page.GotoAsync("http://localhost:3000");
//        }



//        [OneTimeTearDown]
//        public async Task GlobalTeardown()
//        {
//            if (Context != null) await Context.CloseAsync();
//            if (Browser != null) await Browser.CloseAsync();
//            Playwright?.Dispose();
//        }

//        [SetUp]
//        public async Task TestSetup()
//        {
//            // Reset state before each test instead of creating new context
//            await ResetState();
//        }

//        [TearDown]
//        public async Task TestTeardown()
//        {
//            // No need to close context/page here since we're reusing them
//            // You can add any cleanup that doesn't require context closure

//        }

//        protected async Task ResetState() => await Page.ReloadAsync();

//        protected async Task ScrollTo(string selector)
//        {
//            var section = Page.Locator(selector);
//            await section.ScrollIntoViewIfNeededAsync();
//            await Assertions.Expect(section).ToBeVisibleAsync(new() { Timeout = 10000 });
//        }

//        // ------------------------
//        // Intro Section Tests
//        // ------------------------

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

//        // ------------------------
//        // Index Section Tests
//        // ------------------------

//        [Test, Order(5)]
//        public async Task Index_ShouldRenderNavLinks()
//        {
//            var navLinks = Page.Locator(".navbar .nav-links li a");
//            await Assertions.Expect(navLinks).ToHaveCountAsync(4);
//        }

//        [Test, Order(6)]
//        public async Task Index_ClickNavLink_ShouldScrollToAbout()
//        {
//            var aboutLink = Page.Locator(".nav-links a", new() { HasTextString = "About" });
//            await aboutLink.ClickAsync();

//            await Page.WaitForFunctionAsync(@"() => {
//        const el = document.querySelector('#about');
//        if (!el) return false;
//        const rect = el.getBoundingClientRect();
//        return rect.top >= -5 && rect.top <= 120;
//    }");

//            var aboutYAfter = await Page.EvaluateAsync<int>(
//                "() => document.querySelector('#about').getBoundingClientRect().top"
//            );

//            Assert.That(aboutYAfter, Is.InRange(-5, 120),
//                $"Clicking About should bring section into viewport (got {aboutYAfter})");
//        }

//        [Test, Order(7)]
//        public async Task Index_ShouldShowPhoneNumber()
//        {
//            var phoneButton = Page.Locator(".phone .call-button");
//            await Assertions.Expect(phoneButton).ToHaveTextAsync("555-123-3456");
//            var href = await phoneButton.GetAttributeAsync("href");
//            Assert.AreEqual("tel:5551233456", href, "Phone button should be clickable with tel: link");
//        }

//        // ------------------------
//        // About Section Tests
//        // ------------------------

//        [Test, Order(8)]
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

//        [Test, Order(9)]
//        public async Task About_ShouldDisplayImage()
//        {
//            await ResetState();

//            var img = Page.Locator(".about .img3").First;

//            await Assertions.Expect(img).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string src = await img.GetAttributeAsync("src");
//            Assert.IsNotEmpty(src, "About section image should have a source");
//        }

//        //    [Test, Order(9)]
//        //    public async Task About_ShouldDisplayImage()
//        //    {
//        //        await ResetState();

//        //        var img = Page.Locator(".about .img3").First;

//        //        // ✅ Wait for image to be fully loaded (src, complete, naturalHeight > 0)
//        //        await Page.WaitForFunctionAsync(@"() => {
//        //    const img = document.querySelector('.about .img3');
//        //    return img && img.src && img.complete && img.naturalHeight > 0;
//        //}", null, new() { Timeout = 10000 });

//        //        await Assertions.Expect(img).ToBeVisibleAsync();

//        //        string src = await img.GetAttributeAsync("src");
//        //        Assert.IsNotEmpty(src, "About section image should have a source");
//        //    }

//        [Test, Order(10)]
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

//        // ------------------------
//        // Menu Section Tests
//        // ------------------------

//        [Test, Order(11)]
//        public async Task Menu_ShouldRenderHeadingAndNumber()
//        {
//            await ResetState();

//            var heading = Page.Locator(".menu .headings").First;
//            var number = Page.Locator(".menu .numbers").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(number).ToBeVisibleAsync();

//            string headingText = await heading.InnerTextAsync();
//            string numberText = await number.InnerTextAsync();

//            Assert.That(headingText, Is.EqualTo("Our Menu"), "Menu heading should be 'Our Menu'");
//            Assert.That(numberText, Does.Contain("02").IgnoreCase, "Expected section number 02");
//        }

//        [Test, Order(12)]
//        public async Task Menu_ShouldDisplayCategories()
//        {
//            await ResetState();

//            var categories = Page.Locator(".menu .list-container .listss");
//            await Assertions.Expect(categories.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int catCount = await categories.CountAsync();
//            Assert.Greater(catCount, 0, "Expected at least one category");

//            for (int i = 0; i < catCount; i++)
//            {
//                string catText = (await categories.Nth(i).InnerTextAsync()).Trim();
//                Assert.IsNotEmpty(catText, $"Category {i + 1} should not be empty");
//            }
//        }

//        [Test, Order(13)]
//        public async Task Menu_ShouldSwitchActiveCategory()
//        {
//            await ResetState();

//            var selectors = new[]
//            {
//                ".menu .list-container .listss",
//                ".menu .category",
//                ".menu li",
//                ".menu .tab",
//                ".menu-item",
//                ".menu a"
//            };

//            ILocator categories = null;
//            foreach (var sel in selectors)
//            {
//                var loc = Page.Locator(sel);
//                if (await loc.CountAsync() > 1)
//                {
//                    categories = loc;
//                    break;
//                }
//            }

//            Assert.NotNull(categories, "No menu categories found with any common selector");
//            int catCount = await categories.CountAsync();
//            Assert.Greater(catCount, 1, "Need at least 2 categories to test switching");

//            await categories.Nth(1).ClickAsync();

//            await Task.Delay(500);

//            var secondCategory = categories.Nth(1);
//            var hasActiveClass = await secondCategory.EvaluateAsync<bool>(@"el => {
//                return el.classList.contains('active') || 
//                       el.classList.contains('selected') || 
//                       el.getAttribute('aria-selected') === 'true';
//            }");

//            Assert.IsTrue(hasActiveClass, "Second category should become active after click");
//        }

//        // ------------------------
//        // Gallery Section Tests
//        // ------------------------

//        [Test, Order(14)]
//        public async Task Gallery_ShouldRenderHeadingAndNumber()
//        {
//            await ResetState();

//            var heading = Page.Locator(".gallery .headings").First;
//            var number = Page.Locator(".gallery .numbers").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(number).ToBeVisibleAsync();

//            string headingText = await heading.InnerTextAsync();
//            string numberText = await number.InnerTextAsync();

//            Assert.That(headingText, Is.EqualTo("Gallery"), "Gallery heading should be 'Gallery'");
//            Assert.That(numberText, Does.Contain("03").IgnoreCase, "Expected section number 03");
//        }

//        [Test, Order(15)]
//        public async Task Gallery_ShouldDisplayImages()
//        {
//            await ResetState();

//            var images = Page.Locator(".gallery-images .image-wrapper");
//            await Assertions.Expect(images.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int imgCount = await images.CountAsync();
//            Assert.Greater(imgCount, 0, "Expected at least one image in the gallery");

//            var firstImg = images.First.Locator("img");
//            string src = await firstImg.GetAttributeAsync("src");
//            Assert.IsNotEmpty(src, "Gallery image should have a valid src");
//        }

//        [Test, Order(16)]
//        public async Task Gallery_ClickImage_ShouldOpenModal()
//        {
//            await ResetState();

//            var firstImage = Page.Locator(".gallery-images .image-wrapper").First;
//            await firstImage.ClickAsync();

//            var modal = Page.Locator(".lightbox");
//            await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

//            var closeButton = modal.Locator(".close-button");
//            await Assertions.Expect(closeButton).ToBeVisibleAsync();
//        }

//        [Test, Order(17)]
//        public async Task Gallery_Modal_ShouldNavigateNextAndPrev()
//        {
//            await ResetState();

//            var selectors = new[]
//            {
//                ".gallery-images .image-wrapper",
//                ".gallery img",
//                ".gallery a",
//                ".gallery-item"
//            };

//            ILocator images = null;
//            foreach (var sel in selectors)
//            {
//                var loc = Page.Locator(sel);
//                if (await loc.CountAsync() > 1)
//                {
//                    images = loc;
//                    break;
//                }
//            }

//            Assert.NotNull(images, "No gallery images found with any common selector");
//            int imgCount = await images.CountAsync();
//            Assert.GreaterOrEqual(imgCount, 2, "Need at least 2 gallery images to test navigation");

//            await images.First.ClickAsync();
//            var modal = Page.Locator(".lightbox, .modal, .gallery-modal");

//            await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

//            var preview = modal.Locator(".preview-image, img, .current-image");
//            string srcBefore = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
//            Assert.IsNotEmpty(srcBefore, "Preview image should have src");

//            var nextBtn = modal.Locator(".arrow.right, .next, [aria-label='Next']");
//            await nextBtn.ClickAsync();

//            string srcAfter = srcBefore;
//            for (int i = 0; i < 10; i++)
//            {
//                await Task.Delay(500);
//                srcAfter = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
//                if (!string.IsNullOrEmpty(srcAfter) && srcAfter != srcBefore)
//                    break;
//            }

//            Assert.AreNotEqual(srcBefore, srcAfter, "Next button should change the preview image");

//            var prevBtn = modal.Locator(".arrow.left, .prev, [aria-label='Previous']");
//            await prevBtn.ClickAsync();

//            string srcBack = srcAfter;
//            for (int i = 0; i < 10; i++)
//            {
//                await Task.Delay(500);
//                srcBack = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
//                if (srcBack == srcBefore)
//                    break;
//            }

//            Assert.AreEqual(srcBefore, srcBack, "Prev button should return to the original image");

//            var closeBtn = modal.Locator(".close-button, .close");
//            await closeBtn.ClickAsync();
//            await Assertions.Expect(modal).Not.ToBeVisibleAsync();
//        }

//        //        [Test, Order(17)]
//        //public async Task Gallery_Modal_ShouldNavigateNextAndPrev()
//        //{
//        //    await ResetState();

//        //    var selectors = new[]
//        //    {
//        //        ".gallery-images .image-wrapper",
//        //        ".gallery img",
//        //        ".gallery a",
//        //        ".gallery-item"
//        //    };

//        //    ILocator images = null;
//        //    foreach (var sel in selectors)
//        //    {
//        //        var loc = Page.Locator(sel);
//        //        if (await loc.CountAsync() > 1) 
//        //        {
//        //            images = loc;
//        //            break;
//        //        }
//        //    }

//        //    Assert.NotNull(images, "No gallery images found with any common selector");
//        //    int imgCount = await images.CountAsync();
//        //    Assert.GreaterOrEqual(imgCount, 2, "Need at least 2 gallery images to test navigation");

//        //    await images.First.ClickAsync();
//        //    var modal = Page.Locator(".lightbox, .modal, .gallery-modal");

//        //    await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

//        //    var preview = modal.Locator(".preview-image, img, .current-image");
//        //    string srcBefore = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
//        //    Assert.IsNotEmpty(srcBefore, "Preview image should have src");

//        //    // ✅ Next
//        //    var nextBtn = modal.Locator(".arrow.right, .next, [aria-label='Next']");
//        //    await nextBtn.ClickAsync();

//        //    await Page.WaitForFunctionAsync(
//        //        @"(prevSrc) => {
//        //            const img = document.querySelector('.preview-image, .lightbox img, .current-image');
//        //            return img && img.src && img.src !== prevSrc;
//        //        }",
//        //        srcBefore,
//        //        new() { Timeout = 5000 }
//        //    );

//        //    string srcAfter = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
//        //    Assert.AreNotEqual(srcBefore, srcAfter, "Next button should change the preview image");

//        //    // ✅ Prev
//        //    var prevBtn = modal.Locator(".arrow.left, .prev, [aria-label='Previous']");
//        //    await prevBtn.ClickAsync();

//        //    await Page.WaitForFunctionAsync(
//        //        @"(origSrc) => {
//        //            const img = document.querySelector('.preview-image, .lightbox img, .current-image');
//        //            return img && img.src && img.src === origSrc;
//        //        }",
//        //        srcBefore,
//        //        new() { Timeout = 5000 }
//        //    );

//        //    string srcBack = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
//        //    Assert.AreEqual(srcBefore, srcBack, "Prev button should return to the original image");

//        //    var closeBtn = modal.Locator(".close-button, .close");
//        //    await closeBtn.ClickAsync();
//        //    await Assertions.Expect(modal).Not.ToBeVisibleAsync();
//        //}

//        //---------------------
//        //Description 
//        //---------------------

//        [Test, Order(18)]
//        public async Task Description_ShouldRenderHeading()
//        {
//            await ResetState();

//            var heading = Page.Locator("p.description").First;

//            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string headingText = await heading.InnerTextAsync();
//            Assert.That(headingText, Is.EqualTo("What Our Clients Say"), "Description section heading mismatch");
//        }

//        [Test, Order(19)]
//        public async Task Description_ShouldDisplayAtLeastOneClient()
//        {
//            await ResetState();

//            var clientCard = Page.Locator(".list-of-clients > div").First;

//            await Assertions.Expect(clientCard).ToBeVisibleAsync(new() { Timeout = 10000 });

//            var clientImage = clientCard.Locator("img");
//            await Assertions.Expect(clientImage).ToBeVisibleAsync();
//            string src = await clientImage.GetAttributeAsync("src");
//            Assert.IsNotEmpty(src, "Client image should have a source");

//            var clientName = await clientCard.Locator("p").First.InnerTextAsync();
//            Assert.IsNotEmpty(clientName, "Client name should not be empty");

//            var clientDesc = await clientCard.Locator(".client-data").InnerTextAsync();
//            Assert.IsNotEmpty(clientDesc, "Client description should not be empty");
//        }

//        [Test, Order(20)]
//        public async Task Description_ShouldHaveDotsForNavigation()
//        {
//            await ResetState();

//            var dots = Page.Locator(".dots .dot");

//            await Assertions.Expect(dots.First).ToBeVisibleAsync(new() { Timeout = 10000 });

//            int dotCount = await dots.CountAsync();
//            Assert.Greater(dotCount, 0, "Expected at least one dot for navigation");

//            int initialIndex = await dots.EvaluateAllAsync<int>(@"els => {
//        return els.findIndex(el => el.classList.contains('activedot'));
//    }");

//            if (dotCount > 1)
//            {
//                await dots.Nth(1).ClickAsync();

//                await Page.WaitForFunctionAsync(
//                    @"() => {
//                const dots = Array.from(document.querySelectorAll('.dots .dot'));
//                return dots.findIndex(el => el.classList.contains('activedot')) === 1;
//            }",
//                    null,
//                    new() { Timeout = 5000 }
//                );

//                int activeIndex = await dots.EvaluateAllAsync<int>(@"els => {
//            return els.findIndex(el => el.classList.contains('activedot'));
//        }");

//                Assert.AreEqual(1, activeIndex, "Clicking second dot should activate it (was " + activeIndex + ")");
//            }
//            else
//            {
//                TestContext.WriteLine("Only one dot rendered — skipping dot navigation click test.");
//            }
//        }

//        //--------------
//        //subscription
//        //-----------------

//        private async Task EnterEmail(string email)
//        {
//            var input = Page.Locator(".email-section");
//            await input.FillAsync("");
//            await input.TypeAsync(email, new() { Delay = 100 });
//        }

//        [Test, Order(21)]
//        public async Task Subscribe_WithValidEmail_ShouldShowSuccessMessage()
//        {
//            await ResetState();

//            await EnterEmail("test@example.com");
//            await Page.ClickAsync(".subscribe-section");

//            var successLocator = Page.Locator(".successMsg").First;
//            await Assertions.Expect(successLocator).ToBeVisibleAsync(new() { Timeout = 5000 });

//            var successMsg = (await successLocator.InnerTextAsync()).Trim();
//            Assert.That(successMsg, Does.Contain("Almost finished").IgnoreCase,
//                "Success message should indicate subscription progress");
//        }

//        [Test, Order(22)]
//        public async Task Subscribe_WithInvalidEmail_ShouldShowValidationMessage()
//        {
//            await ResetState();

//            await EnterEmail("invalidemail");
//            await Page.ClickAsync(".subscribe-section");

//            var errorLocator = Page.Locator(".message");
//            await Assertions.Expect(errorLocator).ToContainTextAsync(
//                "valid email address",
//                new() { Timeout = 5000 }
//            );
//        }

//        [Test, Order(23)]
//        public async Task Subscribe_WithEmptyEmail_ShouldShowErrorMessage()
//        {
//            await ResetState();

//            await Page.ClickAsync("button.subscribe-section");

//            var input = Page.Locator(".email-section");

//            bool isValid = await input.EvaluateAsync<bool>("el => el.checkValidity()");
//            Assert.False(isValid, "Expected email input to be invalid when empty");

//            string validationMsg = await input.EvaluateAsync<string>("el => el.validationMessage");
//            TestContext.WriteLine($"Browser validation message: {validationMsg}");

//            Assert.That(validationMsg, Does.Contain("Please fill out this field")
//                .Or.Contain("Please enter an email").IgnoreCase);
//        }

//        //---------------
//        //footer
//        //----------------

//        [Test, Order(24)]
//        public async Task Footer_ShouldRenderLogoName()
//        {
//            await ResetState();

//            var logo = Page.Locator(".footer .logoName");
//            await Assertions.Expect(logo).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string logoText = await logo.InnerTextAsync();
//            Assert.That(logoText, Is.EqualTo("Lounge."), "Footer logo text should be Lounge.");
//        }

//        [Test, Order(25)]
//        public async Task Footer_ShouldRenderSocialIcons()
//        {
//            await ResetState();

//            var selectors = new[]
//            {
//                ".footer .apps *",
//                ".footer .social a",
//                ".footer a[href*='facebook'], .footer a[href*='instagram'], .footer a[href*='twitter']",
//                ".footer i.fa, .footer i.icon, .footer svg",
//                ".footer .social-icons a",
//                ".footer .share a"
//            };

//            ILocator icons = null;
//            foreach (var sel in selectors)
//            {
//                var loc = Page.Locator(sel);
//                if (await loc.CountAsync() > 0)
//                {
//                    icons = loc;
//                    break;
//                }
//            }

//            Assert.NotNull(icons, "No social icons found with any common selector");

//            int iconCount = await icons.CountAsync();
//            TestContext.WriteLine($"Found {iconCount} social icons in footer");
//            Assert.Greater(iconCount, 0, "Expected at least one social media icon in footer");
//        }

//        [Test, Order(26)]
//        public async Task Footer_ShouldShowLocationContactAndHours()
//        {
//            await ResetState();

//            var location = Page.Locator(".footer .location .info p").First;
//            var contactEmail = Page.Locator(".footer .contacts .info p").First;
//            var contactPhone = Page.Locator(".footer .contacts .info p").Nth(1);
//            var weekDayHours = Page.Locator(".footer .openingHours .info p").First;

//            await Assertions.Expect(location).ToBeVisibleAsync(new() { Timeout = 10000 });
//            await Assertions.Expect(contactEmail).ToBeVisibleAsync();
//            await Assertions.Expect(contactPhone).ToBeVisibleAsync();
//            await Assertions.Expect(weekDayHours).ToBeVisibleAsync();

//            string locText = await location.InnerTextAsync();
//            string emailText = await contactEmail.InnerTextAsync();
//            string phoneText = await contactPhone.InnerTextAsync();
//            string hoursText = await weekDayHours.InnerTextAsync();

//            Assert.IsNotEmpty(locText, "Footer location should not be empty");
//            Assert.That(emailText, Does.Contain("@").IgnoreCase, "Footer should contain a valid email");
//            Assert.IsNotEmpty(phoneText, "Footer phone should not be empty");
//            Assert.That(hoursText, Does.Contain("Weekdays").IgnoreCase, "Footer should show opening hours");
//        }

//        [Test, Order(27)]
//        public async Task Footer_ShouldHaveBottomLine()
//        {
//            await ResetState();

//            var line = Page.Locator(".footer .lines");
//            await Assertions.Expect(line).ToBeVisibleAsync(new() { Timeout = 5000 });
//        }

//        //-----------------
//        //additional info
//        //------------------

//        [Test, Order(28)]
//        public async Task AdditionalInfo_ShouldRenderCopyright()
//        {
//            await ResetState();

//            var copyright = Page.Locator(".additional-information .copyright");
//            await Assertions.Expect(copyright).ToBeVisibleAsync(new() { Timeout = 10000 });

//            string text = (await copyright.InnerTextAsync()).Trim();
//            Assert.IsNotEmpty(text, "Copyright text should not be empty");
//        }

//        [Test, Order(29)]
//        public async Task AdditionalInfo_ShouldRenderDesignAndDistribution()
//        {
//            await ResetState();

//            var design = Page.Locator(".additional-information .styleshout .design");
//            var names = Page.Locator(".additional-information .styleshout .names");

//            var distribution = Page.Locator(".additional-information .themewagon .design");
//            var distNames = Page.Locator(".additional-information .themewagon .names");

//            await Assertions.Expect(design).ToBeVisibleAsync();
//            await Assertions.Expect(names).ToBeVisibleAsync();
//            await Assertions.Expect(distribution).ToBeVisibleAsync();
//            await Assertions.Expect(distNames).ToBeVisibleAsync();

//            string designText = (await design.InnerTextAsync()).Trim();
//            string distributionText = (await distribution.InnerTextAsync()).Trim();

//            Assert.IsNotEmpty(designText, "Design attribution should not be empty");
//            Assert.IsNotEmpty(distributionText, "Distribution attribution should not be empty");
//        }

//        [Test, Order(30)]
//        public async Task AdditionalInfo_ShouldHaveScrollToTopButton()
//        {
//            await ResetState();

//            var upArrow = Page.Locator(".additional-information .upArrow");
//            await Assertions.Expect(upArrow).ToBeVisibleAsync();

//            await Page.EvaluateAsync("() => window.scrollTo(0, document.body.scrollHeight)");

//            await upArrow.ClickAsync();

//            await Page.WaitForFunctionAsync("() => window.scrollY === 0", null, new() { Timeout = 5000 });

//            int scrollY = await Page.EvaluateAsync<int>("() => window.scrollY");
//            Assert.AreEqual(0, scrollY, "ScrollToTop button should scroll page to top");
//        }
//    }

//    // ========================
//    // Browser-Specific Fixtures
//    // ========================

//    [TestFixture]
//    public class Tests_Chrome : BaseTest
//    {
//        protected override IBrowserType GetBrowserType(IPlaywright playwright) => playwright.Chromium;
//        protected override string GetChannel() => "chrome";
//    }

//    [TestFixture]
//    public class Tests_Edge : BaseTest
//    {
//        protected override IBrowserType GetBrowserType(IPlaywright playwright) => playwright.Chromium;
//        protected override string GetChannel() => "msedge";
//    }

//    [TestFixture]
//    public class Tests_Firefox : BaseTest
//    {
//        protected override IBrowserType GetBrowserType(IPlaywright playwright) => playwright.Firefox;
//        protected override string GetChannel() => null;
//    }
//}



//code for screen recording

using Microsoft.Playwright;
using NUnit.Framework;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AutomationTesting
{
    public abstract class BaseTest
    {
        protected static IPlaywright Playwright;
        protected static IBrowser Browser;
        protected static IBrowserContext Context;
        protected static IPage Page;

        protected abstract IBrowserType GetBrowserType(IPlaywright playwright);
        protected abstract string GetChannel();

        [OneTimeSetUp]
        public async Task GlobalSetup()
        {
            Playwright = await Microsoft.Playwright.Playwright.CreateAsync();

            Browser = await GetBrowserType(Playwright).LaunchAsync(new()
            {
                Channel = GetChannel(),
                Headless = false,
                SlowMo = 600
            });

            // 🎥 Enable video recording
            Context = await Browser.NewContextAsync(new BrowserNewContextOptions
            {
                RecordVideoDir = "videos", // will appear under bin/Debug/netX.Y/videos/
                RecordVideoSize = new RecordVideoSize { Width = 1280, Height = 720 }
            });

            Page = await Context.NewPageAsync();
            await Page.GotoAsync("http://localhost:3000");
        }

        [OneTimeTearDown]
        public async Task GlobalTeardown()
        {
            string? videoPath = null;

            if (Page != null)
            {
                await Page.CloseAsync(); // ✅ must close to flush video
                if (Page.Video != null)
                {
                    videoPath = await Page.Video.PathAsync();
                }
            }

            if (Context != null)
                await Context.CloseAsync();

            if (Browser != null)
                await Browser.CloseAsync();

            Playwright?.Dispose();

            TestContext.WriteLine(videoPath != null
                ? $"🎥 Full run video saved at: {videoPath}"
                : "⚠️ No video was recorded.");
        }

        [SetUp]
        public async Task TestSetup()
        {
            // Reset state before each test instead of creating new context
            await ResetState();
        }

        [TearDown]
        public async Task TestTeardown()
        {
            // No need to close context/page here since we're reusing them
            // You can add any cleanup that doesn't require context closure

        }

        protected async Task ResetState() => await Page.ReloadAsync();

        protected async Task ScrollTo(string selector)
        {
            var section = Page.Locator(selector);
            await section.ScrollIntoViewIfNeededAsync();
            await Assertions.Expect(section).ToBeVisibleAsync(new() { Timeout = 10000 });
        }

        // ------------------------
        // Intro Section Tests
        // ------------------------

        [Test, Order(1)]
        public async Task Intro_ShouldRenderWelcomeAndName()
        {
            await ResetState();

            var welcome = Page.Locator("p.welcome");
            var name = Page.Locator("h1.big");

            await Assertions.Expect(welcome).ToBeVisibleAsync();
            await Assertions.Expect(name).ToBeVisibleAsync();

            var welcomeText = await welcome.InnerTextAsync();
            var nameText = await name.InnerTextAsync();

            Assert.IsNotEmpty(welcomeText, "Welcome text should not be empty");
            Assert.IsNotEmpty(nameText, "Name text should not be empty");
        }

        [Test, Order(2)]
        public async Task Intro_ShouldShowImagesAndParagraph()
        {
            await ResetState();

            var img1 = Page.Locator("img.img1");
            var img2 = Page.Locator("img.img2");
            var paragraph = Page.Locator("p.paragraph");

            await Assertions.Expect(img1).ToBeVisibleAsync();
            await Assertions.Expect(img2).ToBeVisibleAsync();
            await Assertions.Expect(paragraph).ToContainTextAsync("Savor moments of bliss");
        }

        [Test, Order(3)]
        public async Task Intro_ShouldDisplaySocialMediaLinks()
        {
            await ResetState();

            var tags = Page.Locator(".tags a");

            await Assertions.Expect(tags.First).ToBeVisibleAsync(new() { Timeout = 10000 });

            int count = await tags.CountAsync();
            Assert.Greater(count, 0, "Expected at least one social media link");

            for (int i = 0; i < count; i++)
            {
                string text = (await tags.Nth(i).InnerTextAsync()).Trim();
                Assert.IsNotEmpty(text, "Social media link should have text");
            }
        }

        [Test, Order(4)]
        public async Task Intro_ScrollCircle_ShouldBeClickable()
        {
            await ResetState();

            var circle = Page.Locator(".scroll-text-circle .center-icon");

            await Assertions.Expect(circle).ToBeVisibleAsync();
            await circle.ClickAsync();

            Assert.Pass("Scroll circle was clickable without errors");
        }

        // ------------------------
        // Index Section Tests
        // ------------------------

        [Test, Order(5)]
        public async Task Index_ShouldRenderNavLinks()
        {
            var navLinks = Page.Locator(".navbar .nav-links li a");
            await Assertions.Expect(navLinks).ToHaveCountAsync(4);
        }

        [Test, Order(6)]
        public async Task Index_ClickNavLink_ShouldScrollToAbout()
        {
            var aboutLink = Page.Locator(".nav-links a", new() { HasTextString = "About" });
            await aboutLink.ClickAsync();

            await Page.WaitForFunctionAsync(@"() => {
        const el = document.querySelector('#about');
        if (!el) return false;
        const rect = el.getBoundingClientRect();
        return rect.top >= -5 && rect.top <= 120;
    }");

            var aboutYAfter = await Page.EvaluateAsync<int>(
                "() => document.querySelector('#about').getBoundingClientRect().top"
            );

            Assert.That(aboutYAfter, Is.InRange(-5, 120),
                $"Clicking About should bring section into viewport (got {aboutYAfter})");
        }

        [Test, Order(7)]
        public async Task Index_ShouldShowPhoneNumber()
        {
            var phoneButton = Page.Locator(".phone .call-button");
            await Assertions.Expect(phoneButton).ToHaveTextAsync("555-123-3456");
            var href = await phoneButton.GetAttributeAsync("href");
            Assert.AreEqual("tel:5551233456", href, "Phone button should be clickable with tel: link");
        }

        // ------------------------
        // About Section Tests
        // ------------------------

        [Test, Order(8)]
        public async Task About_ShouldRenderHeadingAndNumber()
        {
            await ResetState();

            var heading = Page.Locator(".about .headings").First;
            var number = Page.Locator(".about .numbers").First;

            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
            await Assertions.Expect(number).ToBeVisibleAsync();

            string headingText = await heading.InnerTextAsync();
            string numberText = await number.InnerTextAsync();

            Assert.IsNotEmpty(headingText, "About heading should not be empty");
            Assert.That(numberText, Does.Contain("01").IgnoreCase, "Expected section number 01");
        }

        [Test, Order(9)]
        public async Task About_ShouldDisplayImage()
        {
            await ResetState();

            var img = Page.Locator(".about .img3").First;

            await Assertions.Expect(img).ToBeVisibleAsync(new() { Timeout = 10000 });

            string src = await img.GetAttributeAsync("src");
            Assert.IsNotEmpty(src, "About section image should have a source");
        }

        
        [Test, Order(10)]
        public async Task About_ShouldShowDescriptionParagraphs()
        {
            await ResetState();

            var paragraphs = Page.Locator(".about .text p");

            await Assertions.Expect(paragraphs.First).ToBeVisibleAsync(new() { Timeout = 10000 });

            int count = await paragraphs.CountAsync();
            Assert.Greater(count, 0, "Expected at least one description paragraph");

            for (int i = 0; i < count; i++)
            {
                string text = (await paragraphs.Nth(i).InnerTextAsync()).Trim();
                Assert.IsNotEmpty(text, $"Paragraph {i + 1} should not be empty");
            }
        }

        // ------------------------
        // Menu Section Tests
        // ------------------------

        [Test, Order(11)]
        public async Task Menu_ShouldRenderHeadingAndNumber()
        {
            await ResetState();

            var heading = Page.Locator(".menu .headings").First;
            var number = Page.Locator(".menu .numbers").First;

            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
            await Assertions.Expect(number).ToBeVisibleAsync();

            string headingText = await heading.InnerTextAsync();
            string numberText = await number.InnerTextAsync();

            Assert.That(headingText, Is.EqualTo("Our Menu"), "Menu heading should be 'Our Menu'");
            Assert.That(numberText, Does.Contain("02").IgnoreCase, "Expected section number 02");
        }

        [Test, Order(12)]
        public async Task Menu_ShouldDisplayCategories()
        {
            await ResetState();

            var categories = Page.Locator(".menu .list-container .listss");
            await Assertions.Expect(categories.First).ToBeVisibleAsync(new() { Timeout = 10000 });

            int catCount = await categories.CountAsync();
            Assert.Greater(catCount, 0, "Expected at least one category");

            for (int i = 0; i < catCount; i++)
            {
                string catText = (await categories.Nth(i).InnerTextAsync()).Trim();
                Assert.IsNotEmpty(catText, $"Category {i + 1} should not be empty");
            }
        }

        [Test, Order(13)]
        public async Task Menu_ShouldSwitchActiveCategory()
        {
            await ResetState();

            var selectors = new[]
            {
                ".menu .list-container .listss",
                ".menu .category",
                ".menu li",
                ".menu .tab",
                ".menu-item",
                ".menu a"
            };

            ILocator categories = null;
            foreach (var sel in selectors)
            {
                var loc = Page.Locator(sel);
                if (await loc.CountAsync() > 1)
                {
                    categories = loc;
                    break;
                }
            }

            Assert.NotNull(categories, "No menu categories found with any common selector");
            int catCount = await categories.CountAsync();
            Assert.Greater(catCount, 1, "Need at least 2 categories to test switching");

            await categories.Nth(1).ClickAsync();

            await Task.Delay(500);

            var secondCategory = categories.Nth(1);
            var hasActiveClass = await secondCategory.EvaluateAsync<bool>(@"el => {
                return el.classList.contains('active') || 
                       el.classList.contains('selected') || 
                       el.getAttribute('aria-selected') === 'true';
            }");

            Assert.IsTrue(hasActiveClass, "Second category should become active after click");
        }

        // ------------------------
        // Gallery Section Tests
        // ------------------------

        [Test, Order(14)]
        public async Task Gallery_ShouldRenderHeadingAndNumber()
        {
            await ResetState();

            var heading = Page.Locator(".gallery .headings").First;
            var number = Page.Locator(".gallery .numbers").First;

            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });
            await Assertions.Expect(number).ToBeVisibleAsync();

            string headingText = await heading.InnerTextAsync();
            string numberText = await number.InnerTextAsync();

            Assert.That(headingText, Is.EqualTo("Gallery"), "Gallery heading should be 'Gallery'");
            Assert.That(numberText, Does.Contain("03").IgnoreCase, "Expected section number 03");
        }

        [Test, Order(15)]
        public async Task Gallery_ShouldDisplayImages()
        {
            await ResetState();

            var images = Page.Locator(".gallery-images .image-wrapper");
            await Assertions.Expect(images.First).ToBeVisibleAsync(new() { Timeout = 10000 });

            int imgCount = await images.CountAsync();
            Assert.Greater(imgCount, 0, "Expected at least one image in the gallery");

            var firstImg = images.First.Locator("img");
            string src = await firstImg.GetAttributeAsync("src");
            Assert.IsNotEmpty(src, "Gallery image should have a valid src");
        }

        [Test, Order(16)]
        public async Task Gallery_ClickImage_ShouldOpenModal()
        {
            await ResetState();

            var firstImage = Page.Locator(".gallery-images .image-wrapper").First;
            await firstImage.ClickAsync();

            var modal = Page.Locator(".lightbox");
            await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

            var closeButton = modal.Locator(".close-button");
            await Assertions.Expect(closeButton).ToBeVisibleAsync();
        }

        [Test, Order(17)]
        public async Task Gallery_Modal_ShouldNavigateNextAndPrev()
        {
            await ResetState();

            var selectors = new[]
            {
                ".gallery-images .image-wrapper",
                ".gallery img",
                ".gallery a",
                ".gallery-item"
            };

            ILocator images = null;
            foreach (var sel in selectors)
            {
                var loc = Page.Locator(sel);
                if (await loc.CountAsync() > 1)
                {
                    images = loc;
                    break;
                }
            }

            Assert.NotNull(images, "No gallery images found with any common selector");
            int imgCount = await images.CountAsync();
            Assert.GreaterOrEqual(imgCount, 2, "Need at least 2 gallery images to test navigation");

            await images.First.ClickAsync();
            var modal = Page.Locator(".lightbox, .modal, .gallery-modal");

            await Assertions.Expect(modal).ToBeVisibleAsync(new() { Timeout = 5000 });

            var preview = modal.Locator(".preview-image, img, .current-image");
            string srcBefore = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
            Assert.IsNotEmpty(srcBefore, "Preview image should have src");

            var nextBtn = modal.Locator(".arrow.right, .next, [aria-label='Next']");
            await nextBtn.ClickAsync();

            string srcAfter = srcBefore;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                srcAfter = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
                if (!string.IsNullOrEmpty(srcAfter) && srcAfter != srcBefore)
                    break;
            }

            Assert.AreNotEqual(srcBefore, srcAfter, "Next button should change the preview image");

            var prevBtn = modal.Locator(".arrow.left, .prev, [aria-label='Previous']");
            await prevBtn.ClickAsync();

            string srcBack = srcAfter;
            for (int i = 0; i < 10; i++)
            {
                await Task.Delay(500);
                srcBack = await preview.GetAttributeAsync("src") ?? await preview.GetAttributeAsync("data-src");
                if (srcBack == srcBefore)
                    break;
            }

            Assert.AreEqual(srcBefore, srcBack, "Prev button should return to the original image");

            var closeBtn = modal.Locator(".close-button, .close");
            await closeBtn.ClickAsync();
            await Assertions.Expect(modal).Not.ToBeVisibleAsync();
        }

      

        //---------------------
        //Description 
        //---------------------

        [Test, Order(18)]
        public async Task Description_ShouldRenderHeading()
        {
            await ResetState();

            var heading = Page.Locator("p.description").First;

            await Assertions.Expect(heading).ToBeVisibleAsync(new() { Timeout = 10000 });

            string headingText = await heading.InnerTextAsync();
            Assert.That(headingText, Is.EqualTo("What Our Clients Say"), "Description section heading mismatch");
        }

        [Test, Order(19)]
        public async Task Description_ShouldDisplayAtLeastOneClient()
        {
            await ResetState();

            var clientCard = Page.Locator(".list-of-clients > div").First;

            await Assertions.Expect(clientCard).ToBeVisibleAsync(new() { Timeout = 10000 });

            var clientImage = clientCard.Locator("img");
            await Assertions.Expect(clientImage).ToBeVisibleAsync();
            string src = await clientImage.GetAttributeAsync("src");
            Assert.IsNotEmpty(src, "Client image should have a source");

            var clientName = await clientCard.Locator("p").First.InnerTextAsync();
            Assert.IsNotEmpty(clientName, "Client name should not be empty");

            var clientDesc = await clientCard.Locator(".client-data").InnerTextAsync();
            Assert.IsNotEmpty(clientDesc, "Client description should not be empty");
        }

        [Test, Order(20)]
        public async Task Description_ShouldHaveDotsForNavigation()
        {
            await ResetState();

            var dots = Page.Locator(".dots .dot");

            await Assertions.Expect(dots.First).ToBeVisibleAsync(new() { Timeout = 10000 });

            int dotCount = await dots.CountAsync();
            Assert.Greater(dotCount, 0, "Expected at least one dot for navigation");

            int initialIndex = await dots.EvaluateAllAsync<int>(@"els => {
        return els.findIndex(el => el.classList.contains('activedot'));
    }");

            if (dotCount > 1)
            {
                await dots.Nth(1).ClickAsync();

                await Page.WaitForFunctionAsync(
                    @"() => {
                const dots = Array.from(document.querySelectorAll('.dots .dot'));
                return dots.findIndex(el => el.classList.contains('activedot')) === 1;
            }",
                    null,
                    new() { Timeout = 5000 }
                );

                int activeIndex = await dots.EvaluateAllAsync<int>(@"els => {
            return els.findIndex(el => el.classList.contains('activedot'));
        }");

                Assert.AreEqual(1, activeIndex, "Clicking second dot should activate it (was " + activeIndex + ")");
            }
            else
            {
                TestContext.WriteLine("Only one dot rendered — skipping dot navigation click test.");
            }
        }

        //--------------
        //subscription
        //-----------------

        private async Task EnterEmail(string email)
        {
            var input = Page.Locator(".email-section");
            await input.FillAsync("");
            await input.TypeAsync(email, new() { Delay = 100 });
        }

        [Test, Order(21)]
        public async Task Subscribe_WithValidEmail_ShouldShowSuccessMessage()
        {
            await ResetState();

            await EnterEmail("test@example.com");
            await Page.ClickAsync(".subscribe-section");

            var successLocator = Page.Locator(".successMsg").First;
            await Assertions.Expect(successLocator).ToBeVisibleAsync(new() { Timeout = 5000 });

            var successMsg = (await successLocator.InnerTextAsync()).Trim();
            Assert.That(successMsg, Does.Contain("Almost finished").IgnoreCase,
                "Success message should indicate subscription progress");
        }

        [Test, Order(22)]
        public async Task Subscribe_WithInvalidEmail_ShouldShowValidationMessage()
        {
            await ResetState();

            await EnterEmail("invalidemail");
            await Page.ClickAsync(".subscribe-section");

            var errorLocator = Page.Locator(".message");
            await Assertions.Expect(errorLocator).ToContainTextAsync(
                "valid email address",
                new() { Timeout = 5000 }
            );
        }

        [Test, Order(23)]
        public async Task Subscribe_WithEmptyEmail_ShouldShowErrorMessage()
        {
            await ResetState();

            await Page.ClickAsync("button.subscribe-section");

            var input = Page.Locator(".email-section");

            bool isValid = await input.EvaluateAsync<bool>("el => el.checkValidity()");
            Assert.False(isValid, "Expected email input to be invalid when empty");

            string validationMsg = await input.EvaluateAsync<string>("el => el.validationMessage");
            TestContext.WriteLine($"Browser validation message: {validationMsg}");

            Assert.That(validationMsg, Does.Contain("Please fill out this field")
                .Or.Contain("Please enter an email").IgnoreCase);
        }

        //---------------
        //footer
        //----------------

        [Test, Order(24)]
        public async Task Footer_ShouldRenderLogoName()
        {
            await ResetState();

            var logo = Page.Locator(".footer .logoName");
            await Assertions.Expect(logo).ToBeVisibleAsync(new() { Timeout = 10000 });

            string logoText = await logo.InnerTextAsync();
            Assert.That(logoText, Is.EqualTo("Lounge."), "Footer logo text should be Lounge.");
        }

        [Test, Order(25)]
        public async Task Footer_ShouldRenderSocialIcons()
        {
            await ResetState();

            var selectors = new[]
            {
                ".footer .apps *",
                ".footer .social a",
                ".footer a[href*='facebook'], .footer a[href*='instagram'], .footer a[href*='twitter']",
                ".footer i.fa, .footer i.icon, .footer svg",
                ".footer .social-icons a",
                ".footer .share a"
            };

            ILocator icons = null;
            foreach (var sel in selectors)
            {
                var loc = Page.Locator(sel);
                if (await loc.CountAsync() > 0)
                {
                    icons = loc;
                    break;
                }
            }

            Assert.NotNull(icons, "No social icons found with any common selector");

            int iconCount = await icons.CountAsync();
            TestContext.WriteLine($"Found {iconCount} social icons in footer");
            Assert.Greater(iconCount, 0, "Expected at least one social media icon in footer");
        }

        [Test, Order(26)]
        public async Task Footer_ShouldShowLocationContactAndHours()
        {
            await ResetState();

            var location = Page.Locator(".footer .location .info p").First;
            var contactEmail = Page.Locator(".footer .contacts .info p").First;
            var contactPhone = Page.Locator(".footer .contacts .info p").Nth(1);
            var weekDayHours = Page.Locator(".footer .openingHours .info p").First;

            await Assertions.Expect(location).ToBeVisibleAsync(new() { Timeout = 10000 });
            await Assertions.Expect(contactEmail).ToBeVisibleAsync();
            await Assertions.Expect(contactPhone).ToBeVisibleAsync();
            await Assertions.Expect(weekDayHours).ToBeVisibleAsync();

            string locText = await location.InnerTextAsync();
            string emailText = await contactEmail.InnerTextAsync();
            string phoneText = await contactPhone.InnerTextAsync();
            string hoursText = await weekDayHours.InnerTextAsync();

            Assert.IsNotEmpty(locText, "Footer location should not be empty");
            Assert.That(emailText, Does.Contain("@").IgnoreCase, "Footer should contain a valid email");
            Assert.IsNotEmpty(phoneText, "Footer phone should not be empty");
            Assert.That(hoursText, Does.Contain("Weekdays").IgnoreCase, "Footer should show opening hours");
        }

        [Test, Order(27)]
        public async Task Footer_ShouldHaveBottomLine()
        {
            await ResetState();

            var line = Page.Locator(".footer .lines");
            await Assertions.Expect(line).ToBeVisibleAsync(new() { Timeout = 5000 });
        }

        //-----------------
        //additional info
        //------------------

        [Test, Order(28)]
        public async Task AdditionalInfo_ShouldRenderCopyright()
        {
            await ResetState();

            var copyright = Page.Locator(".additional-information .copyright");
            await Assertions.Expect(copyright).ToBeVisibleAsync(new() { Timeout = 10000 });

            string text = (await copyright.InnerTextAsync()).Trim();
            Assert.IsNotEmpty(text, "Copyright text should not be empty");
        }

        [Test, Order(29)]
        public async Task AdditionalInfo_ShouldRenderDesignAndDistribution()
        {
            await ResetState();

            var design = Page.Locator(".additional-information .styleshout .design");
            var names = Page.Locator(".additional-information .styleshout .names");

            var distribution = Page.Locator(".additional-information .themewagon .design");
            var distNames = Page.Locator(".additional-information .themewagon .names");

            await Assertions.Expect(design).ToBeVisibleAsync();
            await Assertions.Expect(names).ToBeVisibleAsync();
            await Assertions.Expect(distribution).ToBeVisibleAsync();
            await Assertions.Expect(distNames).ToBeVisibleAsync();

            string designText = (await design.InnerTextAsync()).Trim();
            string distributionText = (await distribution.InnerTextAsync()).Trim();

            Assert.IsNotEmpty(designText, "Design attribution should not be empty");
            Assert.IsNotEmpty(distributionText, "Distribution attribution should not be empty");
        }

        [Test, Order(30)]
        public async Task AdditionalInfo_ShouldHaveScrollToTopButton()
        {
            await ResetState();

            var upArrow = Page.Locator(".additional-information .upArrow");
            await Assertions.Expect(upArrow).ToBeVisibleAsync();

            await Page.EvaluateAsync("() => window.scrollTo(0, document.body.scrollHeight)");

            await upArrow.ClickAsync();

            await Page.WaitForFunctionAsync("() => window.scrollY === 0", null, new() { Timeout = 5000 });

            int scrollY = await Page.EvaluateAsync<int>("() => window.scrollY");
            Assert.AreEqual(0, scrollY, "ScrollToTop button should scroll page to top");
        }
    }

    // ========================
    // Browser-Specific Fixtures
    // ========================

    [TestFixture]
    public class Tests_Chrome : BaseTest
    {
        protected override IBrowserType GetBrowserType(IPlaywright playwright) => playwright.Chromium;
        protected override string GetChannel() => "chrome";
    }

    [TestFixture]
    public class Tests_Edge : BaseTest
    {
        protected override IBrowserType GetBrowserType(IPlaywright playwright) => playwright.Chromium;
        protected override string GetChannel() => "msedge";
    }

    [TestFixture]
    public class Tests_Firefox : BaseTest
    {
        protected override IBrowserType GetBrowserType(IPlaywright playwright) => playwright.Firefox;
        protected override string GetChannel() => null;
    }
}
