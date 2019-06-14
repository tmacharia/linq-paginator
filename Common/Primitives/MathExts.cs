namespace Common.Primitives
{
    public static class MathExts
    {
        
        /// <summary>
        /// Validates if an <see cref="int"/> has a value greater than 0.
        /// </summary>
        /// <param name="i">Value to check.</param>
        /// <returns>true or false</returns>
        public static bool IsPositive(this int i) => i > -1;
        /// <summary>
        /// Negates an <see cref="int"/> number by multiplying it by -1.
        /// </summary>
        /// <param name="i">Number to negate</param>
        /// <returns>
        ///     Equivalent value on the other side of 0 in a cartesian plane.
        /// </returns>
        public static int Negate(this int i) => i * -1;
        /// <summary>
        /// Negates a <see cref="decimal"/> number by multiplying it by -1.
        /// </summary>
        /// <param name="d">Number to negate</param>
        /// <returns>
        ///     Equivalent value on the other side of 0 in a cartesian plane.
        /// </returns>
        public static decimal Negate(this decimal d) => d * -1;
        /// <summary>
        /// Negates a <see cref="double"/> number by multiplying it by -1.
        /// </summary>
        /// <param name="d">Number to negate</param>
        /// <returns>
        ///     Equivalent value on the other side of 0 in a cartesian plane.
        /// </returns>
        public static double Negate(this double d) => d * -1;
    }
}