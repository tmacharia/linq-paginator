using NUnit.Framework;
using System.Collections.Generic;
using Paginator;
using System.Linq;
using System;

namespace Tests
{
    [TestFixture]
    public class IEnumerableTests
    {
        [Test, TestCaseSource(typeof(Seed), "List")]
        public void ParamsTest(ICollection<Rate> Rates)
        {
            var result = Rates.Paginate(1, 2);

            Assert.AreEqual(2, result.perpage);
            Assert.AreEqual(1, result.page);
            Assert.AreEqual(Rates.Count, result.total);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void Empty(ICollection<Rate> Rates)
        {
            var result = Rates.Paginate();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.page);
            Assert.AreEqual(Rates.Count, result.total);
        }

        [Test, TestCaseSource(typeof(Seed), "NumStrings")]
        public void FuncTest(ICollection<string> nums)
        {
            var result = nums.Paginate(x => x.Matches("0"), 2, 5);

            Assert.AreEqual(2, result.page);
            Assert.AreEqual(5, result.perpage);
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void OrderByProperty(ICollection<Rate> Rates)
        {
            var result = Rates.Paginate(null, 1, 10, "Value", "desc");

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.page);
            Assert.AreEqual(Rates.Count, result.total);
            Assert.Greater(result.items.First().Value, result.items.Last().Value);
            result.items.ForEach(x =>
            {
                Console.WriteLine(x.Value);
            });
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void NullRequestTest(ICollection<Rate> list)
        {
            var result = list.Paginate(null);

            Assert.AreEqual(1, result.page);
        }
    }
}
