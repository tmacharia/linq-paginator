namespace PhoneNumberFormatter
{
    /// <summary>
    /// Performs all necessary analysis on a phone number to determine
    /// whether its valid and further formats its into a standard
    /// phone number object
    /// </summary>
    public interface IPhoneNumberFormatter
    {
        /// <summary>
        /// Breaks down a phone number and build a <c>PhoneNumber</c>
        /// object that represents it.
        /// </summary>
        /// <param name="phoneNumber">A raw string of any phone number
        /// in the supported countries.
        /// </param>
        /// <returns>A phone number object </returns>
        PhoneNumber Format(string phoneNumber);
        /// <summary>
        /// Checks if a phone number is valid or not
        /// </summary>
        /// <param name="phoneNumber">Raw phone number string</param>
        /// <returns>A result of <paramref name="phoneNumber"/> analysis
        /// stating whether the number of valid or not.
        /// </returns>
        bool IsValid(string phoneNumber);
        /// <summary>
        /// Checks the service or <c>MNO</c> of <paramref name="phoneNumber"/>
        /// </summary>
        /// <param name="phoneNumber">Raw string of a phone number to 
        /// process
        /// </param>
        /// <returns>The Mobile Network Operator for <paramref name="phoneNumber"/>
        /// </returns>
        MNO GetProvider(string phoneNumber);
    }
}
