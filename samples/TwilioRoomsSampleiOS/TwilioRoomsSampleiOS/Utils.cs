using System;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace TwilioRoomsSampleiOS
{
	public static class Utils
	{
#if DEBUG
		private const int TimeOut = 20;
#else
        private const int TimeOut = 30;
#endif

		public enum ContentType
		{
			Json,
			Xml
		}

		public static async Task<VideoToken> GetTokenAsync(string url)
		{
			return await GetObjectAsync<VideoToken>(url, ContentType.Json);
		}

		public static async Task<T> GetObjectAsync<T>(string url, ContentType type)
		{
			var json = await GetStringAsync(url, type);
			var converter = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
			var obj = JsonConvert.DeserializeObject<T>(json, converter);
			return obj;
		}

		public static async Task<string> GetStringAsync(string url, ContentType type)
		{
			string result;
			var headerValue = type == ContentType.Json ? "application/json" : "application/xml";

			using (var client = new HttpClient())
			{
				client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(headerValue));
				client.Timeout = TimeSpan.FromSeconds(TimeOut);
				var stream = await client.GetStreamAsync(url);
				result = await ReadStringAsync(stream);
			}

			return result;
		}

		private static async Task<string> ReadStringAsync(Stream stream)
		{
			var sb = new StringBuilder();
			int read;
			var buffer = new byte[0x1000];

			while ((read = await stream.ReadAsync(buffer, 0, buffer.Length)) != 0)
			{
				var text = Encoding.UTF8.GetString(buffer, 0, read);
				sb.Append(text);
			}

			return sb.ToString();
		}
	}
}