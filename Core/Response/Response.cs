using Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Response
{
    public class Response<T> : IResponse
    {
        public T? Data { get; set; }
        public bool IsSuccess { get; set; }
        public int StatusCode { get; set; }
        public List<string>? Errors { get; set; }

        public static Response<T> Success(T data, int statusCode = 200)
            => new() { Data = data, IsSuccess = true, StatusCode = statusCode };

        public static Response<T> Success(int statusCode = 200)
            => new() { IsSuccess = true, StatusCode = statusCode };

        public static Response<T> Fail(string error, int statusCode = 400)
            => new() { IsSuccess = false, Errors = new List<string> { error }, StatusCode = statusCode };

        public static Response<T> Fail(List<string> errors, int statusCode = 400)
            => new() { IsSuccess = false, Errors = errors, StatusCode = statusCode };
    }
}
