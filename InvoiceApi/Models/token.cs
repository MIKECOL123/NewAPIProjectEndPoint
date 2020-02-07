using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace InvoiceApi.Models
{
	public class Token
	{
		[Required]
		public string grant_type {get; set;}

		[Required]
		public string client_id { get; set; }

		
		public string client_secret { get; set; }

		[Required]
		public string username { get; set; }

		[Required]
		public string password { get; set; }

		
		public string scope { get; set; }
	}
}