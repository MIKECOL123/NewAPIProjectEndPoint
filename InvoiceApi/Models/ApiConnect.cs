using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net.Http;
using Newtonsoft.Json.Linq;
/**
	* API connect 
	*   send the request
	* 
	* public JObject PostApi(Dictionary<string, string> values, Uri url) 
	* public JToken GetApi(Uri url)		
	*
	* */
namespace InvoiceApi.Models
{
	public class ApiConnect
	{
		private static readonly HttpClient client = new HttpClient();
		/**
		 * make the post request
		 * 
		 * @param Dictionary 
		 *		This is the request param.
		 * @param Uri
		 *		This is the request url.
		 *		
		 * @return JObject
		 * */

		public JObject PostApi(Dictionary<string, string> values, Uri url)
		{
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("fwefwefwe");
			var content = new FormUrlEncodedContent(values);

			var response = client.PostAsync(url, content).Result;
			
			var responseString = response.Content.ReadAsStringAsync().Result;
			JObject jObject = JObject.Parse(responseString);
			

			return jObject;
		}

		/**
		 * make the Get request
		 * 
		 * @param Dictionary 
		 *		This is the request param.
		 * @param Uri
		 *		This is the request url.
		 *		
		 * @return JObject
		 * 
		 * */
		public JToken GetApi(Uri url)
		{
			
			client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("fwefwefwe");

			var response = client.GetAsync(url).Result;
			var responseString = response.Content.ReadAsStringAsync().Result;
			JObject jObject = JObject.Parse(responseString);
			


			return jObject;
		}
	}
}