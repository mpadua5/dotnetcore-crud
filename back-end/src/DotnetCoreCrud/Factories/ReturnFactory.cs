using System;
using System.Collections.Generic;

namespace DotnetCoreCrud.Factories
{
    public class ReturnFactory
    {
        public int Code { get; set; }
        public string Message { get; set; }

        public ReturnFactory() { }

        public ReturnFactory(int code, string message)
        {
            Code = code;
            Message = message;
        }
    }
}
