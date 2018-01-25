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
        public void AddResultOnly()
        {

        }
        [TestCase]
        public void AddRequestnResult()
        {

        }
        #endregion


        #region Update Cache Component Test Cases
        [TestCase]
        public void UpdateResultOnly()
        {

        }
        [TestCase]
        public void UpdateRequestnResult()
        {

        }
        #endregion


        #region Get Cache Component Test Cases
        [TestCase]
        public void GetWithRequest()
        {

        }
        [TestCase]
        public void GetWithCacheId()
        {

        }
        #endregion


        #region Remove Cache Component Test Cases
        [TestCase]
        public void RemoveByType()
        {

        }
        [TestCase]
        public void RemoveByCacheId()
        {

        }
        [TestCase]
        public void RemoveByTypenId()
        {

        }
        [TestCase]
        public void ClearCache()
        {

        }
        #endregion
    }
}
