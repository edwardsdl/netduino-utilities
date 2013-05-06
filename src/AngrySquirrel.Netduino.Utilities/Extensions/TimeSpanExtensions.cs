using System;

namespace AngrySquirrel.Netduino.Utilities.Extensions
{
    /// <summary>
    /// Represents a set of extension methods for the <see cref="TimeSpan" /> class
    /// </summary>
    public static class TimeSpanExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Gets the total milliseconds represented by this time span
        /// </summary>
        /// <param name="timeSpan">
        /// A time span
        /// </param>
        /// <returns>
        /// The total milliseconds represented by this time span
        /// </returns>
        public static int TotalMilliseconds(this TimeSpan timeSpan)
        {
            return (int)(timeSpan.Ticks * 0.0001);
        }

        /// <summary>
        /// Gets the total seconds represented by this time span
        /// </summary>
        /// <param name="timeSpan">
        /// A time span
        /// </param>
        /// <returns>
        /// The total seconds represented by this time span
        /// </returns>
        public static int TotalSeconds(this TimeSpan timeSpan)
        {
            return (int)(timeSpan.Ticks * 1E-07);
        }

        #endregion
    }
}