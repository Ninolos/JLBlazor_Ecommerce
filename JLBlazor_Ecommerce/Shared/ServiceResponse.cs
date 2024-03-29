﻿using JLBlazor_Ecommerce.Shared.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JLBlazor_Ecommerce.Shared
{
    public class ServiceResponse<T>
    {
        public T? Data { get; set; }
        public Product? ProductData { get; set; }
        public bool Success { get; set; } = true;
        public string Message { get; set; } = string.Empty;
    }
}
