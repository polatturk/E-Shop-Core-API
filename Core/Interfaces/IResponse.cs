using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IResponse
    {
        bool IsSuccess { get; set; }
        int StatusCode { get; set; }
        List<string>? Errors { get; set; }
    }
}
