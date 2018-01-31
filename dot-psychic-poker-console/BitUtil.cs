namespace dot_psychic_poker_console
{
    public static class BitUtil
    {
        /// <summary>
        ///     Simple function to test bits 
        /// </summary>
        /// <param name="value"></param>
        /// <param name="bit"></param>
        /// <returns></returns>
        public static bool IsBitSet(int value, int bit)
        {
            return (value & (1 << bit)) != 0;
        }
    }
}
