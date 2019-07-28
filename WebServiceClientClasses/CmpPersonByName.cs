namespace WebServiceClientClasses
{
	using System.Collections.Generic;

	public class CmpPersonByName : IComparer<Person>
	{
		public int Compare(Person x, Person y)
		{
			return string.Compare(x.Name, y.Name);
		}
	}
}
