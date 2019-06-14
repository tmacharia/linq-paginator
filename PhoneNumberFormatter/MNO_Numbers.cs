using PhoneNumberFormatter.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PhoneNumberFormatter
{
    /// <summary>
    /// Class to determine an <c>OperatorCode</c> based off
    /// a mobile number
    /// </summary>
    public class MNO_Numbers
    {
        #region Local Variables
        private readonly string[] _safaricomDictionary;
        private readonly string[] _airtelDictionary;
        private readonly string[] _telkomDictionary;
        private readonly string[] _equitelDictionary;
        #endregion

        /// <summary>
        /// contructor to initialize <c>MNO_Numbers</c> with a dictionary
        /// containing network operators and their supported number codes.
        /// </summary>
        public MNO_Numbers()
        {
            //include safaricom
            _safaricomDictionary = new string[]
            {
                "701","702","703","704","705","706","707","708",
                "710","711","712","713","714","715","716","717","718","719",
                "720","721","722","723","724","725","726","727","728","729",
                "740","741","742","743",
                "790","791","792","795","796","797","799"
            };

            //include airtel
            _airtelDictionary = new string[]
            {
                "730","731","732","733","734","735","736","737","738","739",
                "747",
                "750","751","752","753","754","755","756",
                "785","786","787","788","789"
            };

            //include telkom
            _telkomDictionary = new string[]
            {
                "770","771","772","773","774","775","776"
            };

            //include equitel
            _equitelDictionary = new string[]
            {
                "763","764","765"
            };
        }

        //get mobile network provider
        /// <summary>
        /// Analyzes a mobile number to determine the Mobile Network 
        /// Provider
        /// </summary>
        /// <param name="phoneNumber">A raw string of the phone number</param>
        /// <returns>
        /// <c>MNO</c> of the used <paramref name="phoneNumber"/>
        /// </returns>
        public MNO GetNumberMobileNetworkProvider(string phoneNumber)
        {
            IDictionary<PhoneNumberSection, string> tokens = PhoneNumberTokenizer.Tokenize(phoneNumber);

            if (tokens.Count > 0)
            {
                string operatorCode = tokens[PhoneNumberSection.OperatorCode];

                return GetMobileNetworkProvider(operatorCode);
            }
            else
            {
                throw new PhoneNumberException("Unable to break phone number into phone number section. Counter check mobile number and try again");
            }
        }
        /// <summary>
        /// Get mobile network operator based on a number's operator
        /// code only
        /// </summary>
        /// <param name="operatorCode">A raw string with only a phone
        /// number's operator code starting with 07XX or 7XX
        /// </param>
        /// <returns>Network provider for that specific operator
        /// code supplied
        /// </returns>
        public MNO GetMobileNetworkProvider(string operatorCode)
        {
            if (_safaricomDictionary.Contains(operatorCode))
                return MNO.Safaricom;
            else if (_airtelDictionary.Contains(operatorCode))
                return MNO.Airtel;
            else if (_telkomDictionary.Contains(operatorCode))
                return MNO.Telkom;
            else if (_equitelDictionary.Contains(operatorCode))
                return MNO.Equitel;
            else
            {
                throw new PhoneNumberException("Mobile operator code not found.");
            }
        }
    }
}
