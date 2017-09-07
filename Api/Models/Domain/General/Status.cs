﻿using System;
namespace Api.Models.Domain.General
{
    public abstract class Status : DomainModel<int>
    {
        public string Code { get; set; }
        public string Description { get; set; }
        public string Name { get; set; }

        public Status()
        {
        }
    }
}
