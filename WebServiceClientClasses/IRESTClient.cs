namespace WebServiceClientClasses
{
	using System.Collections.Generic;

	public interface IRESTClient
	{
		IList<string> Errors { get; }

		ISet<Person> SelectNYoungest(int numberOfPersons);
	}
}
