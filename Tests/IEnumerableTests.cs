using NUnit.Framework;
using System.Collections.Generic;
using Paginator;
using System.Linq;
using System;
using Common;

namespace Tests
{
    [TestFixture]
    public class IEnumerableTests : TestBase
    {
        [Test, TestCaseSource(typeof(Seed), "List")]
        public void ParamsTest(ICollection<Rate> Rates)
        {
            // Arrange
            int perpage = 2;
            int pages = GetPages(Rates.Count, perpage);
            var result = Rates.Paginate(1, perpage);

            Assert.AreEqual(2, result.ItemsPerPage);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
            Assert.AreEqual(pages, result.TotalPages);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void Empty(ICollection<Rate> Rates)
        {
            int perpage = 10;
            int pages = GetPages(Rates.Count, perpage);
            var result = Rates.Page();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
            Assert.AreEqual(pages, result.TotalPages);
        }

        [Test, TestCaseSource(typeof(Seed), "NumStrings")]
        public void FuncTest(ICollection<string> nums)
        {
            int perpage = 5;
            
            var result = nums.Paged(x => x.Matches("0"), 2, perpage);
            int pages = GetPages(result.TotalItems, perpage);

            Assert.AreEqual(2, result.Page);
            Assert.AreEqual(5, result.ItemsPerPage);
            Assert.AreEqual(pages, result.TotalPages);
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void OrderByProperty(ICollection<Rate> Rates)
        {
            var result = Rates.ToPaginate(null, 1, 10, "Value", "desc");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
            Assert.Greater(result.Items.First().Value, result.Items.Last().Value);
            result.Items.ForEach(x =>
            {
                Console.WriteLine(x.Value);
            });
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void NullRequestTest(ICollection<Rate> list)
        {
            var result = list.ToPages(null);

            Assert.AreEqual(1, result.Page);
        }
    }
}