namespace WebServiceClientClasses
{
	using System.IO;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Json;
	using System.Text;

#pragma warning disable CS0649

	[DataContract]
	internal class UserIds
	{
		[DataMember(Name = "result")]
		private int[] result;

		[DataMember(Name = "token")]
		private string token;

		public int[] Result { get { return this.result; } }

		public string Token { get { return this.token; } }

		// Deserialize a JSON stream to a User object.  
		public static UserIds ReadToObject(string json)
		{
			UserIds deserializedUserIds = null;

			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
			{
				var ser = new DataContractJsonSerializer(typeof(UserIds));
				deserializedUserIds = ser.ReadObject(ms) as UserIds;
			}

			return deserializedUserIds;
		}
	}

#pragma warning restore CS0649
}
