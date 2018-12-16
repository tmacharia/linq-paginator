using System;
using System.Collections.Generic;

namespace Common
{
    public class Result<T>
    {
        public Result()
        {
            Errors = new List<Exception>();
        }
        public bool IsSuccess
        {
            get
            {
                return Errors.Count < 1;
            }
        }
        public string Message { get; set; }
        public T Model { get; set; }
        public List<Exception> Errors { get; set; }
    }
}
