using jim.hex.common.Extensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace jim.hex.common.test.Extensions
{
    public class EnumerableExtensionsTest
    {
        [Fact]

        public void WhenInvoqueHasContent_ListIsNull_ReturnFalse()
        {
            List<int> list = null;

            Assert.False(list.HasContent(),"Must return false when an list is null and invoque the method HasContent");
           
        }

        [Fact]
        public void WhenInvoqueHasContent_ListHasElements_ReturnTrue()
        {
            List<int> list = new List<int>() { 0 };

            Assert.True(list.HasContent(), "Must return true when an list contain elements and invoque the method HasContent");

        }

        [Fact]
        public void WhenInvoqueHasContent_ListIsEmpty_ReturnFalse()
        {
            List<int> list = new List<int>();

            Assert.False(list.HasContent(), "Must return false when an list is empty and invoque the method HasContent");

        }

        [Fact]
        public void WhenInvoqueNotHasContent_ListIsNull_ReturnTrue()
        {
            List<int> list = null;

            Assert.True(list.NotHasContent(), "Must return true when an list is null and invoque the method NoHasContent");

        }


        [Fact]
        public void WhenInvoqueNotHasContent_ListIsEmpty_ReturnTrue()
        {
            List<int> list = null;

            Assert.True(list.NotHasContent(), "Must return true when an list is empty and invoque the method NoHasContent");

        }

        [Fact]
        public void WhenInvoqueNotHasContent_ListContainsElements_ReturnFalse()
        {
            List<int> list = new List<int>() { 0};

            Assert.False(list.NotHasContent(), "Must return false when an list contains elements and invoque the method NoHasContent");

        }
    }
}
