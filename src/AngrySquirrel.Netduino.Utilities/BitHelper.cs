using System.Text;

namespace AngrySquirrel.Netduino.Utilities
{
    /// <summary>
    /// Represents a set of methods for
    /// </summary>
    public static class BitHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Converts the given value to an array of bytes
        /// </summary>
        /// <param name="value">
        /// The value to convert to an array of bytes
        /// </param>
        /// <param name="byteOrder">
        /// A value indicating where the most significant byte should be placed in the array
        /// </param>
        /// <returns>
        /// The given value converted to an array of bytes
        /// </returns>
        public static byte[] ToByteArray(int value, ByteOrder byteOrder)
        {
            var bytes = new[]
                {
                    (byte)(value & 0xFF), 
                    (byte)((value >> 8) & 0xFF), 
                    (byte)((value >> 16) & 0xFF), 
                    (byte)((value >> 24) & 0xFF)
                };

            return byteOrder == ByteOrder.LittleEndian
                       ? bytes
                       : Reverse(bytes);
        }

        /// <summary>
        /// Converts the given value to an array of bytes
        /// </summary>
        /// <param name="value">
        /// The value to convert to an array of bytes
        /// </param>
        /// <param name="byteOrder">
        /// A value indicating where the most significant byte should be placed in the array
        /// </param>
        /// <returns>
        /// The given value converted to an array of bytes
        /// </returns>
        public static byte[] ToByteArray(long value, ByteOrder byteOrder)
        {
            var bytes = new[]
                {
                    (byte)(value & 0xFF), 
                    (byte)((value >> 8) & 0xFF), 
                    (byte)((value >> 16) & 0xFF), 
                    (byte)((value >> 24) & 0xFF), 
                    (byte)((value >> 32) & 0xFF), 
                    (byte)((value >> 40) & 0xFF), 
                    (byte)((value >> 48) & 0xFF), 
                    (byte)((value >> 56) & 0xFF)
                };

            return byteOrder == ByteOrder.LittleEndian
                       ? bytes
                       : Reverse(bytes);
        }

        /// <summary>
        /// Converts the given byte to a bit string
        /// </summary>
        /// <param name="value">
        /// The byte to convert to a bit string
        /// </param>
        /// <returns>
        /// A bit string representing the given byte
        /// </returns>
        public static string ToBitString(byte value)
        {
            var stringBuilder = new StringBuilder();
            for (var i = 0; i < 8; i++)
            {
                stringBuilder.Insert(0, ((value >> i) & 0x01).ToString(), 1);
            }

            return stringBuilder.ToString();
        }

        #endregion

        #region Methods

        /// <summary>
        /// Reverses the given byte array
        /// </summary>
        /// <param name="bytes">
        /// They byte array to reverse
        /// </param>
        /// <returns>
        /// The given byte array in reverse
        /// </returns>
        private static byte[] Reverse(byte[] bytes)
        {
            var reversedBytes = new byte[bytes.Length];

            for (var i = 1; i < bytes.Length; i++)
            {
                reversedBytes[i - 1] = bytes[bytes.Length - i];
            }

            return reversedBytes;
        }

        #endregion
    }
}