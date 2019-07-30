namespace WebServiceClientClasses
{
	using System.Collections.Generic;
	using System.Linq;

	public interface IAppRestClient
	{
		IList<string> Errors { get; }

		IOrderedEnumerable<Person> SelectNYoungest(int numberOfPersons);
	}
}
