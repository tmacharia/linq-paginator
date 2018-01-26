using Caching;
using NUnit.Framework;
using Paginator.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class CachingEngineTests
    {
        private static ICachingEngine _engine;

        [TestCase]
        public void MemoryCacheInit()
        {
            _engine = new CachingEngine(CacheType.Memory);
            Assert.NotNull(_engine.CacheComponents);
        }
        [TestCase]
        public void DiskCacheInit()
        {
            _engine = new CachingEngine(CacheType.Disk);
            Assert.IsNotNull(_engine.CacheComponents);
        }

        #region Add Component to Cache Test Cases
        [TestCase]
        public void AddToDiskCache()
        {
            _engine = new CachingEngine(CacheType.Disk);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool res = _engine.Add(result);

            Assert.IsTrue(res);
            Assert.AreEqual(1, _engine.CacheComponents.Length);
        }
        [TestCase]
        public void AddToMemCache()
        {
            _engine = new CachingEngine(CacheType.Memory);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool res = _engine.Add(result);

            Assert.IsTrue(res);
            Assert.AreEqual(1, _engine.CacheComponents.Length);
        }
        #endregion


        #region Update Cache Component Test Cases
        [TestCase]
        public void UpdateDiskCache()
        {
            _engine = new CachingEngine(CacheType.Disk);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool addResult = _engine.Add(result);

            Assert.IsTrue(addResult);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now update
            result.ItemsPerPage = 15;
            result.Page = 2;
            result.TotalItems = 1500;

            bool updateResult = _engine.Update(result);

            Assert.IsTrue(updateResult);
            Assert.AreEqual(1, _engine.CacheComponents.Length);
            Assert.AreEqual(15, ((Result<Rate>)(_engine.CacheComponents[0].Result)).ItemsPerPage);
        }
        [TestCase]
        public void UpdateMemCache()
        {
            _engine = new CachingEngine(CacheType.Memory);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool addResult = _engine.Add(result);

            Assert.IsTrue(addResult);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now update
            result.ItemsPerPage = 15;
            result.Page = 2;
            result.TotalItems = 1500;

            bool updateResult = _engine.Update(result);

            Assert.IsTrue(updateResult);
            Assert.AreEqual(1, _engine.CacheComponents.Length);
            Assert.AreEqual(15, ((Result<Rate>)(_engine.CacheComponents[0].Result)).ItemsPerPage);
        }
        #endregion


        #region Get Cache Component Test Cases
        [TestCase]
        public void GetByTypeFromDisk()
        {
            _engine = new CachingEngine(CacheType.Disk);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool addResult = _engine.Add(result);

            Assert.IsTrue(addResult);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now get cache component
            var componentResult = _engine.Get<Rate>();

            Assert.NotNull(componentResult);
            Assert.AreEqual(result.ItemsPerPage, componentResult.ItemsPerPage);
            Assert.AreEqual(result.List.Count, componentResult.List.Count);
            Assert.AreEqual(result.Page, componentResult.Page);
            Assert.AreEqual(result.TotalItems, componentResult.TotalItems);
        }
        [Test]
        public void GetByTypeFromMem()
        {
            _engine = new CachingEngine(CacheType.Memory);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool addResult = _engine.Add(result);

            Assert.IsTrue(addResult);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now get cache component
            var componentResult = _engine.Get<Rate>();

            Assert.NotNull(componentResult);
            Assert.AreEqual(result.ItemsPerPage, componentResult.ItemsPerPage);
            Assert.AreEqual(result.List.Count, componentResult.List.Count);
            Assert.AreEqual(result.Page, componentResult.Page);
            Assert.AreEqual(result.TotalItems, componentResult.TotalItems);
        }
        #endregion


        #region Remove Cache Component Test Cases
        [TestCase]
        public void RemoveByTypeFromDisk()
        {
            _engine = new CachingEngine(CacheType.Disk);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool res = _engine.Add(result);

            Assert.IsTrue(res);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now Remove
            bool removeResult = _engine.Remove<Rate>();

            Assert.IsTrue(removeResult);
            Assert.AreEqual(0, _engine.CacheComponents.Length);
        }
        [TestCase]
        public void RemoveByTypeFromMemory()
        {
            _engine = new CachingEngine(CacheType.Memory);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool res = _engine.Add(result);

            Assert.IsTrue(res);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now Remove
            bool removeResult = _engine.Remove<Rate>();

            Assert.IsTrue(removeResult);
            Assert.AreEqual(0, _engine.CacheComponents.Length);
        }
        [TestCase]
        public void ClearCache()
        {
            _engine = new CachingEngine(CacheType.Disk);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool res = _engine.Add(result);

            Assert.IsTrue(res);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now clear cache
            bool clearResult = _engine.ClearCache();

            Assert.IsTrue(clearResult);
        }
        [TestCase]
        public void Dispose()
        {
            _engine = new CachingEngine(CacheType.Disk);

            Result<Rate> result = new Result<Rate>()
            {
                ItemsPerPage = 20,
                List = new List<Rate>(),
                Page = 1,
                TotalItems = 100,
                TotalPages = 5
            };

            bool res = _engine.Add(result);

            Assert.IsTrue(res);
            Assert.AreEqual(1, _engine.CacheComponents.Length);

            // Now dispose
            _engine.Dispose();
            
            Assert.IsNull(_engine.CacheComponents);
        }
        #endregion
    }
}
