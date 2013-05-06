namespace AngrySquirrel.Netduino.Utilities
{
    /// <summary>
    /// Represents possible ways the most significant byte of information is stored in memory
    /// </summary>
    public enum ByteOrder
    {
        /// <summary>
        /// The lack of an endianness
        /// </summary>
        None,

        /// <summary>
        /// The most significant byte is stored at the lowest byte address
        /// </summary>
        BigEndian,

        /// <summary>
        /// The most significant byte is stored at the highest byte address
        /// </summary>
        LittleEndian
    }
}