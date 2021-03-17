using System;
using System.Collections.Generic;
using System.Text;

namespace PaymentDemoService.Util
{
    public class SimpleResult
    {
        public bool IsValid { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public object Data { get; set; }

        private SimpleResult()
        {

        }

        public static SimpleResult CreateInstanceOK(string message = "", object data = null)
        {
            return new SimpleResult()
            {
                IsValid = true,
                Message = message,
                Data = data
            };
        }

        public static SimpleResult CreateInstanceKO(string message, object data = null)
        {
            return new SimpleResult()
            {
                IsValid = true,
                Message = message,
                Data = data
            };
        }
    }
}
