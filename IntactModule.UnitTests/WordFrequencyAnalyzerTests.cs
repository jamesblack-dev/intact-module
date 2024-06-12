using Test;

namespace IntactModule.UnitTests
{
    public class Tests
    {
        IWordFrequencyAnalyzer analyzer;
        [SetUp]
        public void Setup()
        {
            analyzer = new WordFrequencyAnalyzer();
        }
        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_Success()
        {
            var testString = "The dog is the dog";
            var mostFrequentWords = analyzer.CalculateMostFrequentWords(testString, 2);
            Assert.That(mostFrequentWords.Count, Is.EqualTo(2));
            Assert.IsTrue(string.Compare("dog", mostFrequentWords[0].Word, true) == 0);
            Assert.IsTrue(string.Compare("the", mostFrequentWords[1].Word, true) == 0);
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_Success2()
        {
            // Doesn't handle apostrophes
            var testString = "The dog is the dog you're";
            var mostFrequentWords = analyzer.CalculateMostFrequentWords(testString, 2);
            Assert.That(mostFrequentWords.Count, Is.EqualTo(2));
            Assert.IsTrue(string.Compare("dog", mostFrequentWords[0].Word, true) == 0);
            Assert.IsTrue(string.Compare("the", mostFrequentWords[1].Word, true) == 0);
        }

        [Test]
        [Ignore("Framework testing, don't include in CI")]
        public void StringCompareTest()
        {
            Assert.Pass();
            var s1 = "thE";
            var s2 = "The";
            Assert.IsTrue(string.Compare(s1, s2, true) == 0);
        }
    }
}