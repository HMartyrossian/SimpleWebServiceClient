namespace WebServiceClientClasses
{
	using System.IO;
	using System.Runtime.Serialization;
	using System.Runtime.Serialization.Json;
	using System.Text;

#pragma warning disable CS0649

	[DataContract]
	public class Person
	{
		public string Name { get { return this.name; } }

		public int Age { get { return this.age; } }

		public string PhoneNumber { get { return this.phoneNumber; } }

		[DataMember(Name = "id")]
		private uint id;

		[DataMember(Name = "name")]
		private string name;

		[DataMember(Name = "age")]
		private int age;

		[DataMember(Name = "number")]
		private string phoneNumber;

		[DataMember(Name = "photo")]
		private string photo;

		[DataMember(Name = "bio")]
		private string bio;

		// Deserialize a JSON stream to a User object.  
		public static Person ReadToObject(string json)
		{
			var deserializedPerson = new Person();
			var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
			var ser = new DataContractJsonSerializer(deserializedPerson.GetType());
			deserializedPerson = ser.ReadObject(ms) as Person;
			ms.Close();

			return deserializedPerson;
		}

		public override string ToString()
		{
			var result = new StringBuilder();
			result.AppendLine(this.id.ToString());
			result.AppendLine(this.name);
			result.AppendLine(this.age.ToString());
			result.AppendLine(this.phoneNumber);
			result.AppendLine(this.photo);
			result.AppendLine(this.bio);
			result.AppendLine(string.Empty);

			return result.ToString();
		}
	}

#pragma warning restore CS0649
}
