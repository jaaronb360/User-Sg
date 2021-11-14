using Microsoft.VisualStudio.TestTools.UnitTesting;
using AaronBriones.User.Interfaces;
using AaronBriones.User.Services;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;

namespace AaronBriones.User.UTests
{
    [TestClass]
    public class ArrayCalcTests
    {
        private readonly IProductService _productService;

        public ArrayCalcTests()
        {
            var service = new ServiceCollection();
            service.AddScoped<IProductService, ProductService>();

            var serviceProvider = service.BuildServiceProvider();

            _productService = serviceProvider.GetService<IProductService>();
        }

        [TestMethod]
        public void Sort_Array_Reverse()
        {
            var input = new int[] { 13, 5, 1, 2, 9 };
            var result = _productService.Reverse(input);

            Assert.IsTrue(Enumerable.SequenceEqual(input.Reverse(), result));
        }

        [TestMethod]
        public void Sort_Array_Remove()
        {
            var input = new int[] { 13, 5, 1, 2, 9 };
            var position = 2;

            var result = _productService.Remove(position, input);

            var removed = input.ToList();
            removed.RemoveAt(position -1);


            Assert.IsTrue(Enumerable.SequenceEqual(result, removed));


        }
    }
}
