namespace Test
{
    /// <summary>
    /// Represents a word and its associated frequency.
    /// </summary>
    public class WordFrequency : IWordFrequency
    {
        private string _word;
        private int _frequency;

        /// <summary>
        /// Gets or sets the word.
        /// </summary>
        public string Word
        {
            get => _word;
            set => _word = value;
        }

        /// <summary>
        /// Gets or sets the frequency count.
        /// </summary>
        public int Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }
    }
}
