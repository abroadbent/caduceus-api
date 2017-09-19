using System;
using System.ComponentModel.DataAnnotations;

namespace Api.Models.Domain.General
{
    public struct State
    {
		[MinLength(3), MaxLength(3), Required]
		public string Code { get; set; }

		[MaxLength(100), Required]
		public string Name { get; set; }
    }
}
