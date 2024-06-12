namespace Test
{
    internal class WordFrequency : IWordFrequency
    {
        private string _word;
        private int _frequency;

        public string Word
        {
            get => _word;
            set => _word = value;
        }
        public int Frequency
        {
            get => _frequency;
            set => _frequency = value;
        }
    }
}
