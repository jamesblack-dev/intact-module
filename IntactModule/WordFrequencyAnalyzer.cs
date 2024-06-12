using System.Text.RegularExpressions;

namespace Test
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateFrequencyForWord(string text, string word)
        {
            throw new NotImplementedException();
        }

        public int CalculateHighestFrequency(string text)
        {
            throw new NotImplementedException();
        }

        public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
        {
            var sortedWordFrequencyList = GenerateSorting(text);
            return sortedWordFrequencyList.GetRange(0, number).Select(i => new WordFrequency { Word = i.Key, Frequency = i.Value } as IWordFrequency).ToList();
        }

        private List<KeyValuePair<string, int>> GenerateSorting(string text)
        {
            var frequencyHashMap = new Dictionary<string, int>();
            // Get the collection of words, and lowercase for simplified comparisons
            var words = Regex.Matches(text, @"\w+").Select(m => m.Value.ToLower()).ToList();
            // Populate the word frequency hash map
            foreach (var word in words)
            {
                if (frequencyHashMap.ContainsKey(word))
                {
                    frequencyHashMap[word]++;
                }
                else
                {
                    frequencyHashMap.Add(word, 1);
                }
            }

            var sortedWordFrequencyList = frequencyHashMap.ToList();
            // Apply sorting
            sortedWordFrequencyList.Sort((item1, item2) =>
            {
                // If the comparing words have same frequency, favour alphabetical order
                if (item2.Value - item1.Value == 0)
                {
                    return string.Compare(item1.Key, item2.Key);
                }
                else
                {
                    return item2.Value - item1.Value;
                }
            });
            return sortedWordFrequencyList;
        }
    }
}
