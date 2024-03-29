﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApp.MODELS.Responses.HealthCheck
{
    public class IndividualHealthCheckResponse
    {
        public string Status { get; set; } = string.Empty;

        public string? Component { get; set; }   

        public string? Description { get; set;}
    }
}

