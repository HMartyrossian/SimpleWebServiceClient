namespace WebServiceClientClasses
{
	using System;

	public class InvalidListResponceException : ApplicationException
	{
		public InvalidListResponceException(string token) : base(FormatExceptionMessage(token))
		{
		}

		public InvalidListResponceException(string token, Exception ex) : base(FormatExceptionMessage(token), ex)
		{
		}

		protected static string FormatExceptionMessage(string token)
		{
			if (string.IsNullOrWhiteSpace(token))
			{
				token = string.Empty;
			}

			return string.Format("Invalid response from method '/list' for the token: '{0}'.", token);
		}
	}
}
