﻿using System.Text.Json;

namespace OrderIntegrationSystem.Common.Errors
{
    public class ErrorModel
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }


        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
