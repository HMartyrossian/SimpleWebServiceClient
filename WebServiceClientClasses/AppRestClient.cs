﻿namespace WebServiceClientClasses
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	using RestSharp;

	using Verifiers;

	public class AppRestClient : IAppRestClient
	{
		protected static readonly string LIST = "list";
		protected static readonly string LISTWITHTOKEN = "list?token=";
		protected static readonly string DETAIL = "detail/";

		protected IRestClient restClient;

		protected SortedSet<Person> people = new SortedSet<Person>(new CmpPersonByAge());

		protected List<string> errors = new List<string>();

		public AppRestClient(string uri)
		{
			this.restClient = new RestClient(uri);
		}

		public virtual IList<string> Errors
		{
			get
			{
				return this.errors;
			}
		}

		public virtual IOrderedEnumerable<Person> SelectNYoungest(int count)
		{
			// Have to clear errors:
			this.errors.Clear();

			this.PullPeopleData();

			return people.Take(count).OrderBy(p => p.Name);
		}

		protected void PullPeopleData()
		{
			// Have to clear previous data pull first:
			this.people.Clear();

			string token = string.Empty;

			try
			{
				do
				{
					var endPoint = string.IsNullOrEmpty(token) ? LIST : LISTWITHTOKEN + token;
					var request = new RestRequest(endPoint, Method.POST, DataFormat.Json);
					var response = this.restClient.Get(request);
					var userIds = UserIds.ReadToObject(response.Content);

					this.GetPeopleData(userIds.Result);

					token = userIds.Token;
				}
				while (!string.IsNullOrEmpty(token));
			}
			catch (Exception ex)
			{
				// Report fatal error here:
				throw new InvalidListResponceException(token, ex);
			}
		}

		protected void GetPeopleData(int[] ids)
		{
			foreach (var id in ids)
			{
				var endPoint = DETAIL + id.ToString();
				var request = new RestRequest(endPoint, Method.POST, DataFormat.Json);
				var response = this.restClient.Get(request);

				try
				{
					var person = Person.ReadToObject(response.Content);
					if (PhoneNumberVerifier.VerifyPhoneNumber(person.PhoneNumber))
					{
						// This person has a valid US phone number. Have to add him to the list of candidates:
						this.people.Add(person);
					}
					else
					{
						// Have to report that this person doesn't have a valid US phone number:
						this.errors.Add(string.Format("Person with Id: '{0}' has a non US phone number: '{1}'", id, person.PhoneNumber));
					}
				}
				catch (Exception)
				{
					// Record non-fatal error here:
					this.errors.Add(string.Format("Record with Id: '{0}' is missing", id));
				}
			}
		}
	}
}
