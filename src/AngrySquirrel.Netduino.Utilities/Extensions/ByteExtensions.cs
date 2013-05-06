using System.Text;

namespace AngrySquirrel.Netduino.Utilities.Extensions
{
    /// <summary>
    /// Represents a set of extension methods for the <see cref="byte" /> class
    /// </summary>
    public static class ByteExtensions
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts the given byte to a bit string
        /// </summary>
        /// <param name="value">
        /// The byte to convert to a bit string
        /// </param>
        /// <returns>
        /// A bit string representing the given byte
        /// </returns>
        public static string ToBitString(this byte value)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < 8; i++)
            {
                stringBuilder.Insert(0, ((value >> i) & 0x01).ToString(), 1);
            }

            return stringBuilder.ToString();
        }

        #endregion
    }
}