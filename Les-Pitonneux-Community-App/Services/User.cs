using System;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Net;
using System.IO;
using Xamarin.Forms;
using System.Diagnostics;

namespace LesPitonneuxCommunityApp
{
	public class User
	{
		public static bool IsLoggedIn
		{
			get { return !string.IsNullOrWhiteSpace(_Token); }
		}

		//Token returned during authentication
		static string _Token;

		public static string Token
		{
			get { return _Token; }
		}

		public static void SaveUserToken(string token)
		{
			_Token = token;
		}

		//JSon
		static string _UserJson;

		public static string UserJson
		{
			get { return _UserJson; }
		}

		public static void SaveUserJson(string json)
		{
			_UserJson = json;
		}

		public class userfacebook
		{
			public string name { get; set; }
			public picture picture { get; set; }
			public string id { get; set; }
		}

		public class usergoogle
		{
			public string name { get; set; }
			public picture picture { get; set; }
			public string id { get; set; }
		}

		public class picture
		{
			public data data { get; set; }
		}

		public class data
		{
			public bool is_silhouette { get; set; }
			public string url { get; set; }
		}

		public static UserModel CadastroUsuarioSocial()
		{
			var UserMOD = new UserModel();

			if (UserJson != null)
			{
				try
				{
					userfacebook x = JsonConvert.DeserializeObject<userfacebook>(UserJson);
					UserMOD.Name = x.name;
					//UserMOD.SocialId = x.id;
					UserMOD.Token = _Token;
					UserMOD.Url = x.picture.data.url;
				}
				catch (Exception ex)
				{
					var u = "";
				}
			}

			return UserMOD;
		}
	}
}
