using Common;
using System;
using System.Globalization;

namespace PhoneNumberFormatter
{
    /// <summary>
    /// Implements <c>IPhoneNumberFormatter</c> interface
    /// </summary>
    public class PhoneNumberFormatter : IPhoneNumberFormatter
    {
        #region Local Variables
        private readonly MNO_Numbers _mNO_Numbers;
        #endregion

        /// <summary>
        /// Constructor
        /// </summary>
        public PhoneNumberFormatter()
        {
            _mNO_Numbers = new MNO_Numbers();
        }

        /// <summary>
        /// Formats a raw phone number
        /// </summary>
        /// <param name="phoneNumber">Raw mobile number string</param>
        /// <returns>A full phone number object</returns>
        public PhoneNumber Format(string phoneNumber)
        {
            PhoneNumber phone = new PhoneNumber();

            try
            {
                phone.Process(phoneNumber);

                phone.MobileOperator = _mNO_Numbers.GetMobileNetworkProvider(phone.Prefix.ToString(Constants.Culture));
            }
            catch (Exception)
            {
                
            }

            return phone;
        }
        /// <summary>
        /// Get the service provider for a particular <paramref name="phoneNumber"/>
        /// </summary>
        /// <param name="phoneNumber">Raw mobile number string</param>
        /// <returns>A mobile network operator based on <paramref name="phoneNumber"/></returns>
        public MNO GetProvider(string phoneNumber)
        {
            if (!string.IsNullOrWhiteSpace(phoneNumber))
            {
                return _mNO_Numbers.GetNumberMobileNetworkProvider(phoneNumber);
            }
            else
            {
                throw new ArgumentNullException(nameof(phoneNumber));
            }
        }
        /// <summary>
        /// Checks if a phone number is valid or not
        /// </summary>
        /// <param name="phoneNumber">Raw mobile number string</param>
        /// <returns>A boolean representing the result of analysis.</returns>
        public bool IsValid(string phoneNumber)
        {
            return PhoneNumberTokenizer.isValid(phoneNumber);
        }
    }
}
