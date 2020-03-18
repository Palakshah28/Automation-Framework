using ContradoRegressionSuite.Global;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static ContradoRegressionSuite.Global.CommonMethods;
using static ContradoRegressionSuite.Global.GlobalDefinitions;

namespace ContradoRegressionSuite.Pages
{
    internal class SearchProduct
    {
        internal void SearchAProduct()
        {
         

            //Populate the Excel Sheet
            Global.CommonMethods.ExcelLib.PopulateInCollection(Global.Base.ExcelPath, "Search");

            //Navigate to the URL
            Global.GlobalDefinitions.driver.Navigate().GoToUrl(Global.CommonMethods.ExcelLib.ReadData(2, "InputValue"));

            //Delete cookies
            // Global.GlobalDefinitions.driver.Manage().Cookies.DeleteAllCookies();

            //Enter Product Name in Search Text
            Global.GlobalDefinitions.TextBox(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(3, "Locator"), Global.CommonMethods.ExcelLib.ReadData(3, "LocatorValue"), Global.CommonMethods.ExcelLib.ReadData(3, "InputValue"));
            Thread.Sleep(10000);
            

            //Click on Search Button
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(4, "Locator"), Global.CommonMethods.ExcelLib.ReadData(4, "LocatorValue"));
            Global.GlobalDefinitions.wait(14);

            //Click on Searched Product from the list
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(5, "Locator"), Global.CommonMethods.ExcelLib.ReadData(5, "LocatorValue"));
            Global.GlobalDefinitions.wait(4);

            //Click on "Add To Cart" button
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(6, "Locator"), Global.CommonMethods.ExcelLib.ReadData(6, "LocatorValue"));
            Global.GlobalDefinitions.wait(4);

            //Click on "Final Preview" button
            Global.GlobalDefinitions.ActionButton(Global.GlobalDefinitions.driver, Global.CommonMethods.ExcelLib.ReadData(7, "Locator"), Global.CommonMethods.ExcelLib.ReadData(7, "LocatorValue"));
            Global.GlobalDefinitions.wait(4);
        }
    }
}
