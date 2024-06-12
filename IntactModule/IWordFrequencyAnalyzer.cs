namespace IntactModule
{
    public interface IWordFrequencyAnalyzer
    {
        /// <summary>
        /// Which word appears the most in the string
        /// </summary>
        /// <param name="text">The string of string you are testing against</param>
        /// <returns>How often the most frequent word appeared</returns>
        int CalculateHighestFrequency(string text);
        /// <summary>
        /// How often does a certain word appear in a string
        /// </summary>
        /// <param name="text">The string of string you are testing against</param>
        /// <param name="word">The word you wish toe count the frequency of</param>
        /// <returns>How often the word provided was found in the text provided</returns>
        int CalculateFrequencyForWord(string text, string word);
        /// <summary>
        /// The most frequent words, return amount defined by the number parameter
        /// </summary>
        /// <param name="text">The string of string you are testing against</param>
        /// <param name="number">How many words you wish to return</param>
        /// <returns>A list of the implementation of the IWordFrequency interface of the top most common words</returns>
        IList<IWordFrequency> CalculateMostFrequentWords(string text, int number);
    }
}