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
	* request the refresh token and  access token.
	* 
	* 
	* 
    * */
namespace InvoiceApi.Controllers
{
    public class TokenController : ApiController
    {
		/**
		 * get the request refresh token and  access token.
		 * @param Token token
		 * @return Json
		 * 
		 * */
		[HttpPost]
		[Route("getToken")]
		public IHttpActionResult GetToken(Token token)
		{
			
			if(!ModelState.IsValid)
			{// check the request.
				return Json(Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState).RequestMessage);
			}
				

			var values = new Dictionary<string, string>
			{
				{ "grant_type",  token.grant_type },
				{ "client_id", token.client_id },
				{ "username", token.username },
				{ "password", token.password },
				{ "client_secret", token.client_secret},
				{ "scope", token.scope}
			};

			try
			{
				var strUrl = ConfigurationManager.AppSettings["auth"].ToString();//request token url.

				Uri url = new Uri(strUrl);

				ApiConnect api = new ApiConnect();

				var res = api.PostApi(values, url);//requst the post method

				return Json(res);
			}
			catch (Exception e)
			{
				return Json(e.Message);
			}
		}
	}
}
