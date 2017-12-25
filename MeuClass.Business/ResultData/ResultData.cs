using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeuClass.Business.ResultData
{
    public class ResultData<T>
    {
        public static ResultData<T> Instance = new ResultData<T>();

        public ResultData<T> Fill(bool success,string message)
        {
            Success = success;
            Message = message;
            return this;
        }

        public ResultData<T> Fill(bool success,T data)
        {
            Success = success;
            Data = data;
            return this;
        }
        public ResultData<T> Fill(bool success, T data,string message)
        {
            Success = success;
            Data = data;
            Message = message;
            return this;
        }

        public bool Success { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }

    }
}
