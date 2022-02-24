using SUS.MvcFramework.ViewEngine;
using System;
using System.IO;
using Xunit;

namespace SUS.MvcFramework.Test
{
    public class SusViewEngineTests
    {
        [Theory]
        [InlineData("CleanHtml")]
        [InlineData("Foreach")]
        [InlineData("IfElseFor")]
        [InlineData("ViewModel")]
        public void TestGetHtml(string fileName)
        {
            var viewModel = new TestViewModel
            {
                DateOfBirth = new DateTime(2019, 6, 1),
                Name = "Doggo Argentino",
                Price = 12345.67M,
            };

            IViewEngine viewEngine = new SusViewEngine();
            var view = File.ReadAllText($"ViewTest/{fileName}.html");
            var result = viewEngine.GetHtml(view, viewModel);
            var expectedResult = File.ReadAllText($"ViewTest/{fileName}.Result.html");
            Assert.Equal(expectedResult, result);     
        }

        public class TestViewModel
        {
            public decimal  Price { get; set; }
            public string Name { get; set; }
            public DateTime DateOfBirth { get; set; }
        }
    }
}
