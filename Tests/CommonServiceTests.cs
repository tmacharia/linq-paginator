using Caching;
using NUnit.Framework;
using Paginator.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Tests
{
    [TestFixture]
    public class CommonServiceTests
    {
        private static ICommonService _service;

        [TestCase]
        public void Constructor()
        {
            _service = new CommonService();
        }

        [TestCase]
        public void Initialization()
        {
            bool result = _service.Initialize();

            Assert.IsTrue(result);
        }

        [TestCase]
        public void FileNotFoundException()
        {
            Assert.Catch<System.IO.FileNotFoundException>(() =>
            {
                _service.Read("settings");
            });
        }

        [TestCase]
        public void ReadFilenSerialize()
        {
            var rate = _service.Read<Rate>("rates");

            Assert.NotNull(rate);
        }
        [TestCase]
        public void ReadFileString()
        {
            var rates = _service.Read("rates");

            Assert.NotNull(rates);
        }

        [TestCase]
        public void NullFileNameOnRead()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                _service.Read(null);
            });
            Assert.Catch<ArgumentNullException>(() =>
            {
                _service.Read<Rate>(null);
            });
        }
        [TestCase]
        public void EntityNullOnWrite()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                _service.Write<Rate>(null, "fg");
            });
        }
        [TestCase]
        public void FilenameNullInEntityOnWrite()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                _service.Write<Rate>(new Rate(), null);
            });
        }
        [TestCase]
        public void NullFileNameOnWrite()
        {
            Assert.Catch<ArgumentNullException>(() =>
            {
                _service.Write(null, null);
            });
        }

        [TestCase]
        public void WriteTextToFile()
        {
            bool result = _service.Write("values", "23,45,589,289,and the rest are B.S");

            Assert.IsTrue(result);
        }

        [TestCase]
        public void SerializeAndWriteToFile()
        {
            Rate rate = new Rate()
            {
                Value = new Random().Next()
            };

            bool result = _service.Write(rate, "rates");

            Assert.IsTrue(result);
        }

        [TestCase]
        public void WriteCollectionToFile()
        {
            List<Rate> list = new List<Rate>()
            {
                new Rate(){Value=Seed.Random.Next()},
                new Rate(){Value=Seed.Random.Next()},
                new Rate(){Value=Seed.Random.Next()},
                new Rate(){Value=Seed.Random.Next()},
                new Rate(){Value=Seed.Random.Next()}
            };

            bool result = _service.Write(list, "rates_list");

            Assert.IsTrue(result);
        }

        [TestCase]
        public void StringToStream()
        {
            string s = "Pitbull - Options ft. Stephen Marley";

            var res = _service.StringToStream(s);

            Assert.NotNull(res);
        }

        [TestCase]
        public void ReadFileAsStream()
        {
            var res = _service.ReadAsStream("rates");

            Assert.NotNull(res);
            Assert.Greater(res.Length, 0);
        }

        [TestCase]
        public void StreamToString()
        {
            string s = "Pitbull - Options ft. Stephen Marley";

            var res = _service.StringToStream(s);
            string result = _service.StreamToString(res);

            Assert.AreEqual(s, result);
        }
    }
}
