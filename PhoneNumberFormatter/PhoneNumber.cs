using Common;
using System.Collections.Generic;
using System.Globalization;

namespace PhoneNumberFormatter
{
    /// <summary>
    /// This class creates the structure a full mobile number 
    /// with all the parts:
    /// 
    /// <list type="bullet">
    /// <item>
    /// <term>Country Code</term>
    /// <description>The first part of a mobile number that
    /// identifies the country of origin for that number. Every 
    /// country in the world has a unique country code for all its 
    /// mobile numbers. e.g +254...
    /// </description>
    /// </item>
    /// <item>
    /// <term>Prefix</term>
    /// <description>The second part of a mobile number that
    /// identifies the mobile network operator. e.g 0721..,0738..
    /// </description>
    /// </item>
    /// <item>
    /// <term>Suffix/Actual Number</term>
    /// <description>The last part of a mobile number that normally
    /// identifies a user to a mobile operator.
    /// </description>
    /// </item>
    /// </list>
    /// </summary>
    public class PhoneNumber
    {
        /// <summary>
        /// First part of a phone number that tells the country of origin
        /// for that phone number
        /// </summary>
        public string CountryCode { get; set; }
        /// <summary>
        /// Second part of a phone number that identifies the mobile
        /// network provider
        /// </summary>
        public int Prefix { get; set; }
        /// <summary>
        /// Last part of a phone number that is the actual number of a 
        /// user after <c>CountryCode</c> and <c>Prefix</c>
        /// </summary>
        public string Suffix { get; set; }
        /// <summary>
        /// Identifies the mobile operator based on the phone number's 
        /// prefix
        /// </summary>
        public MNO MobileOperator { get; set; }
        /// <summary>
        /// Real phone number with all its constituent parts.
        /// </summary>
        public string Number
        {
            get
            {
                return (CountryCode + Prefix + Suffix).Trim('+');
            }
        }

        /// <summary>
        /// constructor to initialize <c>Phone Number</c> with a default
        /// <c>CountryCode</c>
        /// </summary>
        public PhoneNumber()
        {
            CountryCode = "+254";
        }
        /// <summary>
        /// constructor to initialize <c>PhoneNumber</c> based on a 
        /// supplied mobile number
        /// </summary>
        /// <param name="mobile">Unformatted mobile number</param>
        public PhoneNumber(string mobile)
        {
            Process(mobile);
        }

        /// <summary>
        /// constructor to initialize <c>PhoneNumber</c> based on a 
        /// supplied mobile number
        /// </summary>
        /// <param name="mobile">Unformatted mobile number</param>
        public PhoneNumber Process(string mobile)
        {
            IDictionary<PhoneNumberSection, string> tokens = PhoneNumberTokenizer.Tokenize(mobile);

            MobileOperator = new MNO_Numbers().GetMobileNetworkProvider(tokens[PhoneNumberSection.OperatorCode]);
            CountryCode = tokens[PhoneNumberSection.CountryCode];
            Prefix = int.Parse(tokens[PhoneNumberSection.OperatorCode], Constants.Culture);
            Suffix = tokens[PhoneNumberSection.RealNumber];

            return this;
        }
    }
}
