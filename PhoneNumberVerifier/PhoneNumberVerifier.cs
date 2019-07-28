namespace Verifiers
{
	using System.Text.RegularExpressions;

	public class PhoneNumberVerifier
	{
		protected static readonly string PHONENUMBERPATTERN = "^(\\([2-9][0-9]{2}\\)( ?|-)|[2-9][0-9]{2}( |-))[0-9]{3}-[0-9]{4}$";

		public static bool VerifyPhoneNumber(string phoneNumber)
		{
			return Regex.IsMatch(phoneNumber, PHONENUMBERPATTERN, RegexOptions.Compiled);
		}
	}
}
