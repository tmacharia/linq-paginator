using NUnit.Framework;
using System.Collections.Generic;
using System.Linq;
using Paginator;

namespace Tests
{
    [TestFixture]
    public class IQueryableTests
    {
        [Test, TestCaseSource(typeof(Seed), "List")]
        public void ParamsTest(ICollection<Rate> Rates)
        {
            var result = Rates.AsQueryable()
                              .Paginate(1, 2);

            Assert.AreEqual(2, result.perpage);
            Assert.AreEqual(1, result.page);
            Assert.AreEqual(Rates.Count, result.total);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void Empty(ICollection<Rate> Rates)
        {
            var result = Rates.AsQueryable()
                              .Paginate();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.page);
            Assert.AreEqual(Rates.Count, result.total);
        }


        [Test, TestCaseSource(typeof(Seed), "List")]
        public void FuncTest(ICollection<Rate> Rates)
        {
            var result = Rates.AsQueryable()
                              .Paginate(x => x.Value > 9, 2, 2);

            Assert.NotNull(result);
            Assert.AreEqual(2, result.page);
            Assert.AreEqual(2, result.perpage);
            Assert.AreEqual(Rates.Count(x => x.Value > 9), result.total);
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void NullRequestTest(ICollection<Rate> list)
        {
            var result = list.AsQueryable()
                             .Paginate(null);

            Assert.AreEqual(1, result.page);
        }
    }
}
