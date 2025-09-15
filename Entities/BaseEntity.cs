﻿
using System.ComponentModel;
using System.Net;
using System.Security.Claims;

namespace Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
        public bool IsActive { get; set; } = true;
    }
}






