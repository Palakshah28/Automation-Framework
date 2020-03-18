using ContradoRegressionSuite.Config;
using ContradoRegressionSuite.Pages;
using NUnit.Framework;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using RelevantCodes.ExtentReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ContradoRegressionSuite.Global.CommonMethods;

namespace ContradoRegressionSuite.Global
{
    class Base
    {

        #region To access Path from resource file

        public static int Browser = Int32.Parse(FBResource.Browser);
        public static string ExcelPath = FBResource.ExcelPath;
        public static string ScreenshotPath = FBResource.ScreenShotPath;
        public static string ReportPath = FBResource.ReportPath;
        public static string ObjectpropertyPath = FBResource.ObjectProperyPath;

        #endregion

        #region reports
        public static ExtentTest test;
        public static ExtentReports extent;
        #endregion

        #region setup and tear down
        [SetUp]
        public void Inititalize()
        {

            switch (Browser)
            {
                case 1:
                    GlobalDefinitions.driver = new FirefoxDriver();
                    break;

                case 2:
                    var options = new ChromeOptions();
                    options.AddArguments("--disable-extensions --disable-extensions-file-access-check --disable-extensions-http-throttling --disable-infobars --enable-automation --start-maximized");
                    options.AddUserProfilePreference("credentials_enable_service", false);
                    options.AddUserProfilePreference("profile.password_manager_enabled", false);
                    GlobalDefinitions.driver = new ChromeDriver(options);
                    break;

            }

            //extent = new ExtentReports(ReportPath, false, DisplayOrder.OldestFirst);
            extent = new ExtentReports(ReportPath, true);
            extent.LoadConfig(FBResource.ReportXMLPath);
            
            


            //if (FBResource.IsLogin == "true")
            //{
            //    LoginPage loginobj = new LoginPage();
            //    loginobj.LoginSteps();
            //}
            //else
            //{
            //    Register obj = new Register();
            //    obj.RegisterwithValidData();
            //}

        }


        [TearDown]
        public void TearDown()
        {
            // Screenshot
            String img = SaveScreenShotClass.SaveScreenshot(GlobalDefinitions.driver, "Report");
           
            test.Log(LogStatus.Fail, "Snapshot below: " + test.AddScreenCapture(img));
            // end test. (Reports)
            extent.EndTest(test);
            // calling Flush writes everything to the log file (Reports)
            
            Thread.Sleep(3500);
            // Close the driver            
            GlobalDefinitions.driver.Close();
        }
        #endregion

        [OneTimeTearDown]
        public void ClassCleanup()
        {
            // Runs once after all tests in this class are executed. (Optional)
            // Not guaranteed that it executes instantly after all tests from the class.
            
            extent.Flush();
            extent.Close();
            //Global.CommonMethods.email_send();

        }


    }
}

