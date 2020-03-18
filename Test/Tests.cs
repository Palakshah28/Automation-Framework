using ContradoRegressionSuite.Pages;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContradoRegressionSuite
{
    public class Tests
    {

        [TestFixture]
        [Category("ContradoRegressionSuite")]
        class Contrado : Global.Base
        {
            ////TestCase1
            //[Test, Description("Test to Search for a fb member name")]
            //public void SearchName()
            //{
            //    //Start the reports
            //    test = extent.StartTest("ContradoRegressionSuite page navigation");

            //    //Create a Class and Method
            //    FBHomePage obj = new FBHomePage();
            //    obj.SearchAName();

            //}
            //TestCase2
            [Test, Description("Test to Search for a fb member name")]
            public void SwatchPack()
            {
                //Start the reports
                test = extent.StartTest("Swatch Pack Scenario");

                //Create a Class and Method
                SearchProduct obj1 = new SearchProduct();
                obj1.SearchAProduct();
            }
            
        }
    }
}
