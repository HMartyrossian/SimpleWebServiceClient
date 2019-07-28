namespace WebServiceClientClasses
{
	using System.Collections.Generic;

	public interface IAppRestClient
	{
		IList<string> Errors { get; }

		ISet<Person> SelectNYoungest(int numberOfPersons);
	}
}
