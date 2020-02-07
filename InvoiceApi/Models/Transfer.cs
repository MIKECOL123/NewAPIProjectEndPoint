using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
namespace InvoiceApi.Models
{
	public  class Transfer
	{
		[Required]
		public string clave { get; set; }

		[Required]
		public string fecha { get; set; }

		[Required]
		public string tipoIdentification { get; set; }

		[Required]

		public string numeroIdentificacion { get; set; }

		[Required]
		public string comprobanteXml { get; set; }

		
	}
}