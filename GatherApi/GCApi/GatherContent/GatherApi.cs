using Newtonsoft.Json.Linq;
using System;
using System.IO;
using System.Net;
using System.Reflection;
using System.Text;
using System.Web.Script.Serialization;

namespace GCApi.GatherContent
{
	internal enum GatherMethods
	{
		[StringValue("get_me")]
		Users_GetMe,
		[StringValue("get_users")]
		Users_GetUsers,
		[StringValue("get_user")]
		Users_GetUser,
		[StringValue("get_my_company")]
		Companies_GetMyCompany,
		[StringValue("get_companies")]
		Companies_GetCompanies,
		[StringValue("get_company")]
		Companies_GetCompany,
		[StringValue("get_projects")]
		Projects_GetProjects,
		[StringValue("get_project")]
		Projects_GetProject,
		[StringValue("get_projects_by_company")]
		Projects_GetProjectsByCompany,
		[StringValue("get_pages")]
		Pages_GetPages,
		[StringValue("get_page")]
		Pages_GetPage,
		[StringValue("get_pages_by_project")]
		Pages_GetPagesByProject,
		[StringValue("get_files")]
		Files_GetFiles,
		[StringValue("get_file")]
		Files_GetFile,
		[StringValue("get_files_by_project")]
		Files_GetFilesByProject,
		[StringValue("get_files_by_page")]
		Files_GetFilesByPage,
        [StringValue("get_custom_states")]
        Custom_GetCustomStates,
        [StringValue("get_custom_state")]
        Custom_GetCustomState,
        [StringValue("get_custom_states_by_project")]
        Custom_GetCustomStatesByProject
	}
	public class GatherApi
	{
		private const string _ApiUrl = "https://{0}.gathercontent.com/api/0.2.1/";
		private const string _requestMethod = "POST";
		private const string _requestType = "application/x-www-form-urlencoded";

		private string _ApiKey = "";
		private string _ApiPassword = "x";
		private string _ApiAccount = "";
		private CredentialCache _CredentialCache = new CredentialCache();
		public GatherApi(string ApiAccount, string ApiKey)
		{
			#region Set User Data
			_ApiAccount = ApiAccount;
			_ApiKey = ApiKey;
			_CredentialCache.Add(new Uri(string.Format(_ApiUrl, _ApiAccount)), "Digest", new NetworkCredential(_ApiKey, _ApiPassword));
			#endregion
			#region Verify User Credentials
			WebRequest request = HttpWebRequest.Create(new Uri(String.Format(_ApiUrl + "{1}", _ApiAccount, "get_me")));
			request.Credentials = _CredentialCache;
			request.Method = _requestMethod;
			request.ContentType = _requestType;
			request.PreAuthenticate = true;

			//Get Response
			try
			{
				var response = request.GetResponse();
				var stream = response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);

				JObject result = JObject.Parse(reader.ReadToEnd());
				if (result == null || !result["success"].Value<Boolean>())
					throw new RequestErrorException();
			}
			catch (Exception e)
			{
				throw e;
			}
			#endregion
		}

		#region APIMethods

		internal string GetDataString(GatherMethods method, string ID = "")
		{
			WebRequest request = HttpWebRequest.Create(new Uri(String.Format(_ApiUrl + "{1}", _ApiAccount, GetStringValue(method))));
			request.Credentials = _CredentialCache;
			request.Method = "POST";
			request.ContentType = "application/x-www-form-urlencoded";
			request.PreAuthenticate = true;
			String Params = "";
			try
			{
				if (!String.IsNullOrWhiteSpace(ID))
				{
					Params = string.Format("id={0}", ID);
					ASCIIEncoding encoding = new ASCIIEncoding();
					byte[] data = encoding.GetBytes(Params);
					var requestStream = request.GetRequestStream();
					requestStream.Write(data, 0, data.Length);
					requestStream.Close();
				}

				var response = request.GetResponse();
				var stream = response.GetResponseStream();
				StreamReader reader = new StreamReader(stream);
				string resultString = reader.ReadToEnd();
				//Read response to screen

				JObject result = JObject.Parse(resultString);
				if (result == null || !result["success"].Value<Boolean>())
					throw new RequestErrorException();
				return resultString;
			}
			catch (Exception e)
			{
				throw e;
			}
		}
		internal JObject GetDataJson(GatherMethods method, string ID = "")
		{
			JObject obj = new JObject();
			return JObject.Parse(GetDataString(method, ID));
		}
		#endregion
		private string JsonFailed(Exception e)
		{
			JavaScriptSerializer json = new JavaScriptSerializer();
			return json.Serialize(new FailedError(e));
		}
		private string GetStringValue(Enum value)
		{
			string output = null;
			Type type = value.GetType();


			//Look for our 'StringValueAttribute' 
			//in the field's custom attributes
			FieldInfo fi = type.GetField(value.ToString());
			StringValueAttribute[] attrs =
			   fi.GetCustomAttributes(typeof(StringValueAttribute),
									   false) as StringValueAttribute[];
			if (attrs.Length > 0)
			{
				output = attrs[0].Value;
			}

			return output;
		}
	}
	class FailedError
	{
		public string success = "failed";
		public string message;
		public FailedError(Exception e)
		{
			message = e.Message;
		}
	}
	class RequestErrorException : Exception
	{
		public override string Message
		{
			get
			{
				return "The server returned back the request was unsucessful";
			}
		}
	}
	class StringValueAttribute : System.Attribute
	{

		private string _value;

		public StringValueAttribute(string value)
		{
			_value = value;
		}

		public string Value
		{
			get { return _value; }
		}

	}
}