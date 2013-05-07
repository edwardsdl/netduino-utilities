using System;

namespace AngrySquirrel.Netduino.Utilities
{
    /// <summary>
    /// Represents a set of methods for manipulating bytes and byte arrays
    /// </summary>
    public static class ByteHelper
    {
        #region Public Methods and Operators

        /// <summary>
        /// Swaps the endianess of the given byte array
        /// </summary>
        /// <param name="bytes">
        /// They byte array to reverse
        /// </param>
        /// <returns>
        /// The given byte array in reverse
        /// </returns>
        public static byte[] SwapEndianess(byte[] bytes)
        {
            var reversedBytes = new byte[bytes.Length];

            for (var i = 0; i < bytes.Length; i++)
            {
                reversedBytes[i] = bytes[bytes.Length - 1 - i];
            }

            return reversedBytes;
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
        public static byte[] ToByteArray(int value, ByteOrder byteOrder = ByteOrder.LittleEndian)
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
                : SwapEndianess(bytes);
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
        public static byte[] ToByteArray(long value, ByteOrder byteOrder = ByteOrder.LittleEndian)
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
                : SwapEndianess(bytes);
        }

        /// <summary>
        /// Converts the byte array to an integer
        /// </summary>
        /// <param name="bytes">
        /// The byte array to convert to an integer
        /// </param>
        /// <param name="startIndex">
        /// The index in the array specifying the first of four bytes which will be converted into an unsigned integer
        /// </param>
        /// <param name="byteOrder">
        /// A value indicating where the most significant byte is placed in the given array
        /// </param>
        /// <returns>
        /// The byte array converted to an integer
        /// </returns>
        public static int ToInt32(byte[] bytes, int startIndex = 0, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            if (bytes.Length - startIndex < 4)
            {
                throw new ArgumentOutOfRangeException("startIndex", "The start index must be proceeded by at least 4 bytes.");
            }

            if (startIndex < 0)
            {
                throw new ArgumentOutOfRangeException("startIndex", "The start index must be greater than 0.");
            }

            bytes = new[] { bytes[startIndex], bytes[startIndex + 1], bytes[startIndex + 2], bytes[startIndex + 3] };

            if (byteOrder == ByteOrder.BigEndian)
            {
                bytes = SwapEndianess(bytes);
            }

            return bytes[0] | bytes[1] << 8 | bytes[2] << 16 | bytes[3] << 24;
        }

        /// <summary>
        /// Converts the byte array to an unsigned integer
        /// </summary>
        /// <param name="bytes">
        /// The byte array to convert to an unsigned integer
        /// </param>
        /// <param name="startIndex">
        /// The index in the array specifying the first of four bytes which will be converted into an unsigned integer
        /// </param>
        /// <param name="byteOrder">
        /// A value indicating where the most significant byte is placed in the given array
        /// </param>
        /// <returns>
        /// The byte array converted to an unsigned integer
        /// </returns>
        public static uint ToUInt32(byte[] bytes, int startIndex = 0, ByteOrder byteOrder = ByteOrder.LittleEndian)
        {
            return (uint)ToInt32(bytes, startIndex, byteOrder);
        }

        #endregion
    }
}