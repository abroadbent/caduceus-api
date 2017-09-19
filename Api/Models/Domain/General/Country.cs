using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.General
{
    public struct Country
    {
		[MinLength(3), MaxLength(3), Required]
		public string Code { get; set; }

		[MaxLength(100), Required]
		public string Name { get; set; }
    }
}
