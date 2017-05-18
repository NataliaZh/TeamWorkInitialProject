﻿using BartlettAreTheQAs.Attributes;
using BartlettAreTheQAs.Models;
using BartlettAreTheQAs.Pages.HomePage;
using NUnit.Framework;
using NUnit.Framework.Interfaces;
using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using System;
using System.Configuration;
using System.IO;
using TestStack.Seleno.Configuration;

namespace BartlettAreTheQAs
{

    [TestFixture]
    class BlogHomePageTests
    {
        public IWebDriver driver;
        public BlogHomePage home;

        [SetUp]

        public void Initialized()
        {
            this.driver = BrowserHost.Instance.Application.Browser;
            this.home = new BlogHomePage(this.driver);
            home.NavigateTo();
        }

        [TearDown]
        public void LogsandScreenshot()
        {
           TearDownClass TearLogs = new TearDownClass(this.driver);
           TearLogs.TearLogs();
        }


        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void NavigatetoBlog()
        {         
         BlogHomePage home = new BlogHomePage(this.driver);
         home.NavigateTo();
            Assert.IsTrue(home.Logo.Displayed);
        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void  GoInFirstArticleLoggedUserNo()
        {
          BlogHomePage home = new BlogHomePage(this.driver);
             home.NavigateTo();
            home.FirstArticle.Click();         
            Assert.IsTrue(home.FirstArticleTitle.Displayed);
        }

        [Test, Property("Priority", 2)]
        [Author("Nataliya Zh")]
        public void FirstArticleClickOnEditBtnLoggerUserNo()
        {
        //    BlogHomePage home = new BlogHomePage(this.driver);
        //    home.NavigateTo();
            home.FirstArticle.Click();
            if (home.LoginLink.Displayed)
            {
                home.FirstArticleEditButton.Click();
                //Assert href contains http://localhost:60634/Account/Login
                //not ready
                //Assert.IsTrue(home.)

            }
        }

        [Test, Property("Priority", 1)]
        [Author("Rozaliya Evtimova")]
        public void HoverOnLogo()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            Actions builder = new Actions(this.driver);
            builder.MoveToElement(home.Logo).Perform();
            home.HoverOnLogo("rgba(24, 188, 156, 1)");
        }

        [Test, Property("Priority", 1)]
        [Author("Rozaliya Evtimova")]
        public void HoverOnArticle()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            Actions builder = new Actions(this.driver);
            builder.MoveToElement(home.FirstArticle).Perform();
            home.HoverOnFirstArtilce("underline solid rgb(24, 188, 156)");
        }

        [Test, Property("Priority", 1)]
        [Author("Rozaliya Evtimova")]
        public void FirstArticleText()
        {
          BlogHomePage home = new BlogHomePage(this.driver);
        home.NavigateTo();
            home.FirstArticleText();
        }

        [Test, Property("Priority", 1)]
        [Author("Rozaliya Evtimova")]
        public void FirstArticleAutor()
        {
          BlogHomePage home = new BlogHomePage(this.driver);
         home.NavigateTo();
            home.FirstArticleAutor();
        }

        [Test, Property("Priority", 2)]
        [Author("Rozaliya Evtimova")]
        public void RegisterDisplayNoLogInUser()
        {
          
          BlogHomePage home = new BlogHomePage(this.driver);
          home.NavigateTo();
           home.RegisterLinkDisplayed();
           
        }

        [Test, Property("Priority", 2)]
        [Author("Rozaliya Evtimova")]
        public void LogInDisplayNoLogInUser()
        {
          BlogHomePage home = new BlogHomePage(this.driver);
         home.NavigateTo();
            home.LonInLinkDisplayed();
        }

        [Test, Property("Priority", 1)]
        [Author("Rozaliya Evtimova")]
        public void HoverOnRegisterLink()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            Actions builder = new Actions(this.driver);
            builder.MoveToElement(home.RegisterLink).Perform();
            home.HoverOnRegisterLink("rgba(24, 188, 156, 1)");
        }

        [Test, Property("Priority", 1)]
        [Author("Rozaliya Evtimova")]
        public void HoverOnLogInLink()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            Actions builder = new Actions(this.driver);
            builder.MoveToElement(home.LoginLink).Perform();
            home.HoverOnLogInLink("rgba(24, 188, 156, 1)");
        }

        [Test, Property("Priority", 2)]
        [Author("Rozaliya Evtimova")]
        public void ClickOnLoginLink()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            home.LoginLink.Click();
           
        }

        [Test, Property("Priority", 2)]
        [Author("Rozaliya Evtimova")]
        public void ClickOnRegisterLink()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            home.RegisterLink.Click();
            home.RegisterLinkClick();
        }

        [Test, Property("Priority", 2)]
        [Author("Rozaliya Evtimova")]
        public void LogInUserHelloElement()
        {

            BlogHomePage home = new BlogHomePage(this.driver);
            home.NavigateTo();
            home.LoginLink.Click();
            var user = AccessExcelData.GetTestData<HomePageLogInUserModel>("RegisterPageData.xlsx", "DataSet2", "ValidLogin2");
            home.FillLogOn(user);
            home.LogInHelloDiplay();
        }

    }


}
