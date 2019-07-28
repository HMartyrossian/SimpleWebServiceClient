using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Text;

namespace WebServiceClientClasses
{
#pragma warning disable CS0649

	[DataContract]
	internal class UserIds
	{
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

		[DataMember]
		public int[] result;

		[DataMember]
		public string token;
	}

#pragma warning restore CS0649
}
