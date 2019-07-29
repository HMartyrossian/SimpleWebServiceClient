namespace ConsoleApp1
{
	using System;
	using System.Collections.Generic;

	using WebServiceClientClasses;

	class Program
	{
		static void Main(string[] args)
		{
			try
			{
				var uri = args[0];
				var client = new AppRestClient(uri);

				var count = int.Parse(args[1]);
				var selection = client.SelectNYoungest(count);

				Visualize(selection);

				ReportErrors(client.Errors);
			}
			catch (Exception ex)
			{
				PrintExceptionMessage(ex);
			}
		}

		private static void Visualize(ISet<Person> selection)
		{
			var count = selection.Count;
			if (count > 0)
			{
				Console.Out.WriteLine("Selection returned {0} person(s):", count);
				foreach (var person in selection)
				{
					Console.Out.WriteLine(person.ToString());
				}
			}
		}

		private static void ReportErrors(IList<string> errors)
		{
			var count = errors.Count;
			if (errors.Count > 0)
			{
				Console.Out.WriteLine(string.Format("Detected {0} error(s):", count));
				foreach (var err in errors)
				{
					Console.Out.WriteLine(err);
				}

				Console.Out.WriteLine();
			}
		}

		private static void PrintExceptionMessage(Exception ex)
		{
			Console.Out.WriteLine("Application failed with an exception:");
			while (ex != null)
			{
				Console.Out.WriteLine(ex.Message);
				ex = ex.InnerException;
			}
		}
	}
}
