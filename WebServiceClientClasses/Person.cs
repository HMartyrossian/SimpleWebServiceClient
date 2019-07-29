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

		public string Name { get { return this.name; } }

		public int Age { get { return this.age; } }

		public string PhoneNumber { get { return this.phoneNumber; } }

		// Deserialize a JSON stream to a User object.  
		public static Person ReadToObject(string json)
		{
			Person deserializedPerson = null;
			using (var ms = new MemoryStream(Encoding.UTF8.GetBytes(json)))
			{
				var ser = new DataContractJsonSerializer(typeof(Person));
				deserializedPerson = ser.ReadObject(ms) as Person;
			}

			return deserializedPerson;
		}

		public override string ToString()
		{
			var result = new StringBuilder();
			result.AppendLine(string.Format("ID: {0}", this.id));
			result.AppendLine(string.Format("Name: {0}", this.name));
			result.AppendLine(string.Format("Age: {0}", this.age));
			result.AppendLine(string.Format("Phone number: {0}", this.phoneNumber));
			result.AppendLine(string.Format("Photo URL: {0}", this.photo));
			result.AppendLine(string.Format("Bio: {0}", this.bio));
			result.AppendLine(string.Empty);

			return result.ToString();
		}
	}

#pragma warning restore CS0649
}
