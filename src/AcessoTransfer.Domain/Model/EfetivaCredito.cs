﻿using System;
using System.Collections.Generic;
using System.Text;

namespace AcessoTransfer.Domain.Model
{
    public class EfetivaCredito
    {
        public string AccountNumber { get; set; }
        public decimal Value { get; set; }
        public string Type { get; set; }
    }
}
