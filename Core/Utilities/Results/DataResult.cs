using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        public DataResult(string message,bool success,T data):base(success,message)
        {
            Data = data;
        }
        public DataResult(bool success, T data) : base(success)
        {
            Data = data;
        }
        public T Data { get; }
    }
}
