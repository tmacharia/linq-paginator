using System;
using System.Collections.Generic;
using System.Text;

namespace PhoneNumberFormatter
{
    /// <summary>
    /// Mobile Network Operators(MNO) in Kenya as registered
    /// by The Communications Authority in Kenya(CAK)
    /// </summary>
    public enum MNO
    {
        /// <summary>
        /// For safaricom based numbers.
        /// <example>
        /// Safaricom numbers prefix examples
        /// 070X;
        /// 071X;
        /// 072X;
        /// 079X;
        /// </example>
        /// </summary>
        Safaricom,
        /// <summary>
        /// For Airtel based numbers.
        /// <example>
        /// Airtel numbers prefix examples
        /// 073X;
        /// 075X;
        /// 078X;
        /// </example>
        /// </summary>
        Airtel,
        /// <summary>
        /// For Telkom based numbers.
        /// <example>
        /// Telkom numbers prefix examples
        /// 076X;
        /// </example>
        /// </summary>
        Telkom,
        /// <summary>
        /// For equitel based numbers
        /// <example>
        /// Equitel numbers prefix examples
        /// 076X;
        /// </example>
        /// </summary>
        Equitel
    }
}
