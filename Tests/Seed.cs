using Paginator.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Tests
{
    public static class Seed
    {
        private static Random _rand;
        private static CustomRandom _random;

        private static Random Rand
        {
            get
            {
                if (_rand != null)
                    return _rand;
                else
                {
                    _rand = new Random();
                    return _rand;
                }
            }
        }
        public static CustomRandom Random
        {
            get
            {
                if (_random != null)
                    return _random;
                else
                {
                    _random = new CustomRandom();
                    return _random;
                }
            }
        }
        private static IEnumerable List
        {
            get
            {
                yield return new List<Rate>(GenRandomRates(9));
                yield return new List<Rate>(GenRandomRates(50));
                //yield return new List<Rate>(GenRandomRates(250));
                //yield return new List<Rate>(GenRandomRates(537));
                //yield return new List<Rate>(GenRandomRates(750));
                //yield return new List<Rate>(GenRandomRates(1000));

                //yield return new List<Rate>(GenRandomRates(5000));
                //yield return new List<Rate>(GenRandomRates(2320500));
                //yield return new List<Rate>(GenRandomRates(20000));
                //yield return new List<Rate>(GenRandomRates(50000));
                //yield return new List<Rate>(GenRandomRates(100000));

                //yield return new List<Rate>(GenRandomRates(1000000));
                ///yield return new List<Rate>(GenRandomRates(5000037));
                //yield return new List<Rate>(GenRandomRates(10000000));
                //yield return new List<Rate>(GenRandomRates(15000000));
                //yield return new List<Rate>(GenRandomRates(20000000));
            }
        }
        public static IEnumerable Queryable
        {
            get
            {
                yield return List.AsQueryable();
            }
        }
        public static IEnumerable Enumerable => List;

        public static IEnumerable Pages
        {
            get
            {
                yield return new List<Rate>(GenRandomRates(53));
            }
        }
        public static IEnumerable Empty
        {
            get
            {
                yield return new List<Rate>(GenRandomRates(0));
            }
        }
        public static IEnumerable Null
        {
            get
            {
                yield return null;
            }
        }

        private static Rate[] GenRandomRates(int count)
        {
            List<Rate> list = new List<Rate>(count);

            for (int i = 0; i < count; i++)
            {
                Rate rate = new Rate()
                {
                    Value = Rand.Next(1, 100)
                };
                list.Add(rate);
            }

            return list.ToArray();
        }
        public static void Log(Rate[] rates)
        {
            if (rates == null)
                Console.WriteLine("Empty rates.");
            else
            {
                for (int i = 0; i < rates.Length; i++)
                {
                    Console.WriteLine("{0} --> {1}", i + 1, rates[i].Value);
                }
            }
        }
        public static int TotalPages(int total, int perpage)
        {
            int n = (int)(total / perpage);
            
            if ((total % perpage) > 0)
                n++;

            return n;
        }
    }
}
