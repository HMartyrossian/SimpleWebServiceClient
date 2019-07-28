namespace WebServiceClientClasses
{
	using System.Collections.Generic;

	public class CmpPersonByAge : IComparer<Person>
	{
		public int Compare(Person x, Person y)
		{
			int result = x.Age - y.Age;

			// In case of equal age, person with "smaller" name wins:
			if (result == 0)
			{
				result = string.Compare(x.Name, y.Name);
			}

			return result;
		}
	}
}
