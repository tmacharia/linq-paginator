using System.ComponentModel;

namespace Common.Enums
{
    /// <summary>
    /// Represents HTTP verbs.
    /// </summary>
    public enum HttpVerb
    {
        /// <summary>
        /// GET request.
        /// </summary>
        [Description("GET Request")]
        GET,
        /// <summary>
        /// POST request.
        /// </summary>
        [Description("POST Request")]
        POST,
        /// <summary>
        /// PUT request.
        /// </summary>
        [Description("PUT Request")]
        PUT,
        /// <summary>
        /// DELETE Request.
        /// </summary>
        [Description("DELETE Request")]
        DELETE
    }
}