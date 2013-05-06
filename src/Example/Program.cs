using System.Text;
using AngrySquirrel.Netduino.Utilities;
using AngrySquirrel.Netduino.Utilities.Extensions;
using Microsoft.SPOT;

namespace Example
{
    /// <summary>
    /// Represents an example project showing how to use the <see cref="AngrySquirrel.Netduino.Utilities" /> library
    /// </summary>
    public class Program
    {
        #region Public Methods and Operators

        /// <summary>
        /// Program entry point
        /// </summary>
        public static void Main()
        {
            const int value = 0x05F5E100;
            var bytes = ByteHelper.ToByteArray(value);
            bytes = ByteHelper.SwapEndianess(bytes);

            var stringBuilder = new StringBuilder();
            foreach (var @byte in bytes)
            {
                stringBuilder.Append(@byte.ToBitString());
            }

            Debug.Print(stringBuilder.ToString());
        }

        #endregion
    }
}