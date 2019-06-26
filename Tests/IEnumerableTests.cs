using NUnit.Framework;
using System.Collections.Generic;
using Paginator;
using System.Linq;
using System;
using Common;

namespace Tests
{
    [TestFixture]
    public class IEnumerableTests
    {
        [Test, TestCaseSource(typeof(Seed), "List")]
        public void ParamsTest(ICollection<Rate> Rates)
        {
            var result = Rates.Paginate(1, 2);

            Assert.AreEqual(2, result.ItemsPerPage);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void Empty(ICollection<Rate> Rates)
        {
            var result = Rates.Paginate();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
        }

        [Test, TestCaseSource(typeof(Seed), "NumStrings")]
        public void FuncTest(ICollection<string> nums)
        {
            var result = nums.Paginate(x => x.Matches("0"), 2, 5);

            Assert.AreEqual(2, result.Page);
            Assert.AreEqual(5, result.ItemsPerPage);
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void OrderByProperty(ICollection<Rate> Rates)
        {
            var result = Rates.Paginate(null, 1, 10, "Value", "desc");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
            Assert.Greater(result.List.First().Value, result.List.Last().Value);
            result.List.ForEach(x =>
            {
                Console.WriteLine(x.Value);
            });
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void NullRequestTest(ICollection<Rate> list)
        {
            var result = list.Paginate(null);

            Assert.AreEqual(1, result.Page);
        }
    }
}