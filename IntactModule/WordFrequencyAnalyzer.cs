using System.Text.RegularExpressions;

namespace IntactModule
{
    public class WordFrequencyAnalyzer : IWordFrequencyAnalyzer
    {
        public int CalculateFrequencyForWord(string text, string word)
        {
            var sortedWordFrequencyList = GenerateSorting(text);
            var wordFrequency = sortedWordFrequencyList.First((pair) => string.Compare(pair.Word, word, true) == 0);
            return wordFrequency.Frequency;
        }

        public int CalculateHighestFrequency(string text)
        {
            var sortedWordFrequencyList = GenerateSorting(text);
            return sortedWordFrequencyList.First().Frequency;
        }

        public IList<IWordFrequency> CalculateMostFrequentWords(string text, int number)
        {
            var sortedWordFrequencyList = GenerateSorting(text).ToList();
            return sortedWordFrequencyList.GetRange(0, number);
        }

        private IOrderedEnumerable<IWordFrequency> GenerateSorting(string text)
        {
            var invalidCharacterMatches = Regex.Matches(text, "[^a-zA-Z\\s]");
            if(invalidCharacterMatches.Count > 0)
            {
                throw new ArgumentException($"Argument: ({nameof(text)}) has invalid character: '{invalidCharacterMatches.First().Value}'.");
            }

            var frequencyHashMap2 = new List<IWordFrequency>();
            // Get the collection of words, and lowercase for simplified comparisons
            var words = Regex.Matches(text, @"\w+").Select(m => m.Value.ToLower()).ToList();
            // Populate the word frequency hash map
            foreach (var word in words)
            {
                var entry = frequencyHashMap2.FirstOrDefault((freq) => string.Compare(freq.Word, word, StringComparison.OrdinalIgnoreCase) == 0);
                if (entry != null)
                {
                    entry.Frequency++;
                }
                else
                {
                    frequencyHashMap2.Add(new WordFrequency { Word = word, Frequency = 1 });
                }
            }

            frequencyHashMap2.OrderBy(freq => freq.Frequency).ThenBy(freq => freq.Word);

            // Apply sorting
            var sortedWordFrequencyList = frequencyHashMap2.OrderByDescending(freq => freq.Frequency).ThenBy(freq => freq.Word);

            return sortedWordFrequencyList;
        }
    }
}
