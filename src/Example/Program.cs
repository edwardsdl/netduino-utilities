using System.Text;
using AngrySquirrel.Netduino.Utilities;
using Microsoft.SPOT;

namespace Example
{
    /// <summary>
    /// Represents an example project showing how to use the <see cref="AngrySquirrel.Netduino.Utilities" /> library
    /// </summary>
    public class Program
    {
        /// <summary>
        /// Program entry point
        /// </summary>
        public static void Main()
        {
            var bytes = BitHelper.ToByteArray(1000, ByteOrder.LittleEndian);

            var stringBuilder = new StringBuilder();
            foreach (var @byte in bytes)
            {
                stringBuilder.Append(BitHelper.ToBitString(@byte));
            }

            Debug.Print(stringBuilder.ToString());
        }
    }
}