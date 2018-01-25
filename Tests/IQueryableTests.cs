using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using Paginator;
using Paginator.Models;
using Paginator.Exceptions;

namespace Tests
{
    [TestFixture]
    public class IQueryableTests
    {
        [Test, TestCaseSource(typeof(Seed), "List")]
        public void ParamsTest(ICollection<Rate> Rates)
        {
            var result = Rates.AsQueryable()
                              .ToPaged(1, 2);

            Assert.AreEqual(2, result.ItemsPerPage);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
            Assert.Greater(result.TotalPages,-1);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void Empty(ICollection<Rate> Rates)
        {
            var result = Rates.AsQueryable()
                              .ToPaged();

            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.Page);
            Assert.AreEqual(Rates.Count, result.TotalItems);
        }


        [Test, TestCaseSource(typeof(Seed), "List")]
        public void FuncTest(ICollection<Rate> Rates)
        {
            var result = Rates.AsQueryable()
                              .ToPaged(x => x.Value > 9, 2, 2);

            Assert.NotNull(result);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void RequestTest(ICollection<Rate> Rates)
        {
            Request request = new Request()
            {
                Page = 1,
                ItemsPerPage = 2
            };

            var result = Rates.AsQueryable()
                              .ToPaged(request);

            Assert.AreEqual(request.ItemsPerPage, result.ItemsPerPage);
            Assert.AreEqual(request.Page, result.Page);
            Assert.AreEqual(Rates.OfType<Rate>().Count(), result.TotalItems);
            Assert.Greater(result.TotalPages, -1);
        }

        [Test, TestCaseSource(typeof(Seed), "List")]
        public void InvalidValuesInRequest(ICollection<Rate> Rates)
        {
            Request request = new Request()
            {
                Page = -2,
                ItemsPerPage = -25
            };

            Assert.Catch<InvalidArgumentException>(() =>
            {
                Rates.AsQueryable().ToPaged(request);
            });
        }

        [Test, TestCaseSource(typeof(Seed),"List")]
        public void RequestWithFuncTest(ICollection<Rate> list)
        {
            int perpage = Seed.Random.Next();
            int total = Seed.TotalPages(list.Count,perpage);
            
            Request request = new Request()
            {
                Page = (total < 1) ? 1 : new Random().Next(1, Seed.TotalPages(list.Count, perpage)),
                ItemsPerPage = perpage
            };

            var result = list.AsQueryable()
                             .ToPaged(x => x.Value > 0, request);

            Assert.AreEqual(request.ItemsPerPage, result.ItemsPerPage);
            Assert.AreEqual(request.Page, result.Page);
            Assert.Greater(result.TotalItems, -1);
            Assert.Greater(result.TotalPages, -1);
        }

        [Test, TestCaseSource(typeof(Seed), "Empty")]
        public void EmptyTest(ICollection<Rate> list)
        {
            Request request = new Request()
            {
                Page = 1,
                ItemsPerPage = 2
            };

            var result = list.AsQueryable()
                             .ToPaged(request);
        }


        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void PagesTest(ICollection<Rate> list)
        {
            Request request = new Request()
            {
                Page = 6,
                ItemsPerPage = 10
            };

            var result = list.AsQueryable()
                             .ToPaged(request);

            Assert.AreEqual(6, result.TotalPages);
            Assert.AreEqual(3, result.List.Count);
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void WrongPageTest(ICollection<Rate> list)
        {
            Request request = new Request()
            {
                Page = 7,
                ItemsPerPage = 10
            };

            Assert.Catch(typeof(OutOfRangeException), () =>
             {
                 list.AsQueryable()
                     .ToPaged(request);
             });
        }

        [Test, TestCaseSource(typeof(Seed), "Pages")]
        public void NullRequestTest(ICollection<Rate> list)
        {
            var result = list.AsQueryable()
                             .ToPaged(null);

            Assert.AreEqual(1, result.Page);
        }

        [TestCase]
        public void NegativeReqTest()
        {
            Assert.Catch(typeof(InvalidArgumentException), () =>
            {
                Seed.Enumerable
                     .OfType<Rate>()
                     .AsQueryable<Rate>()
                     .ToPaged(-3, -15);
            });
        }
    }
}
