using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json.Linq;
using InvoiceApi.Models;
using System.Configuration;
/**
	*  Invoice controller
	*  public IHttpActionResult postInvoice(Transfer transfer);
	*  public IHttpActionResult getStatus(string clave);
    * */
namespace InvoiceApi.Controllers
{

    public class InvoiceController : ApiController
    {
		/**
		 * send the invoice.
		 * @param Transfer transfer
		 * @return Json
		 * 
		 * */

		[HttpPost]
		[Route("postInvoice")]
		public IHttpActionResult postInvoice(Transfer transfer)
		{
			
			

			if (!ModelState.IsValid)
			{
				return Json(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState).RequestMessage);
			}

			JObject jsonObject = new JObject
			{
				["clave"] = transfer.clave,
				["fecha"] = transfer.fecha,
				["emisor"] = new JObject
				{
					["tipoIdentification"] = transfer.tipoIdentification,
					["numeroIdentificacion"] = transfer.numeroIdentificacion,
				}

				["receptor"] = new JObject
				{
					["tipoIdentification"] = transfer.tipoIdentification,
					["numeroIdentificacion"] = transfer.numeroIdentificacion,
				}

				["comprobanteXml"] = transfer.comprobanteXml								
			};

			var values = JsonExtension.ToDictionary(jsonObject);
			Dictionary<string, string> value = values.ToDictionary(k => k.Key, k => k.Value == null ? "" : k.Value.ToString());
			

			var strUrl = ConfigurationManager.AppSettings["reception"].ToString();//reception url
			try {
				Uri url = new Uri(strUrl);

				ApiConnect api = new ApiConnect();

				var res = api.PostApi(value, url);

				return Json(res);
			}
			catch (Exception e)
			{
				return Json(e.Message);
			}
		}

		/**
		 * Get the invoice status.
		 * It uses verify the invoice of status.
		 * 
		 * @param Transfer transfer
		 * @return Json
		 * 
		 * */

		[HttpGet]
		[Route("getstatus")]
		public IHttpActionResult getStatus(string clave)
		{
			if (clave == null)// check the empty value.
				return Json(clave);

			var strUrl = ConfigurationManager.AppSettings["reception"].ToString()+"?clave="+clave;//reception url

			try
			{
				Uri url = new Uri(strUrl);
				ApiConnect api = new ApiConnect();

				var res = api.GetApi(url);//Requst the get method

				return Json(res);// if status is 200,  output json
			}
			catch (Exception e)
			{
				return Json(e.Message);
			}
		}
	}
}
