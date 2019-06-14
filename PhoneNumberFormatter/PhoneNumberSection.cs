namespace PhoneNumberFormatter
{
    /// <summary>
    /// An enumerations of the three sections composing a full
    /// phone number
    /// </summary>
    public enum PhoneNumberSection
    {
        /// <summary>
        /// Defines the country of origin for a particular phone number.
        /// In kenya, it is a 3 digit number or sometimes prefixed with
        /// a '+' character at the beginning.
        /// </summary>
        CountryCode,
        /// <summary>
        /// A 4 digit number that identifies the Mobile Network Operator
        /// </summary>
        OperatorCode,
        /// <summary>
        /// A 6 digit number which is the actual number of a user
        /// </summary>
        RealNumber
    }
}
