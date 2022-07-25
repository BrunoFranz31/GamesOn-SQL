using System;
using System;
using System.Collections.Generic;
using MySqlConnector;
using Microsoft.AspNetCore.Http;

namespace TENTATIVA2.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
