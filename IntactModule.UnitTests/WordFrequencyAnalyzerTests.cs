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
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_SimpleSentence_Success()
        {
            var testString = "The sun shines over the lake";
            var mostFrequentWords = analyzer.CalculateMostFrequentWords(testString, 2);
            Assert.That(mostFrequentWords.Count, Is.EqualTo(2));
            Assert.IsTrue(string.Compare("the", mostFrequentWords[0].Word, true) == 0);
            Assert.IsTrue(string.Compare("lake", mostFrequentWords[1].Word, true) == 0);
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_AdditionalPunctuation_Success()
        {
            // Doesn't handle apostrophes
            var testString = "You're The sun shines over you're the lake you'RE";
            var mostFrequentWords = analyzer.CalculateMostFrequentWords(testString, 2);
            Assert.That(mostFrequentWords.Count, Is.EqualTo(2));
            Assert.IsTrue(string.Compare("re", mostFrequentWords[0].Word, true) == 0);
            Assert.IsTrue(string.Compare("you", mostFrequentWords[1].Word, true) == 0);
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_MultiSentenceParagraph_Success()
        {
            var testString = "The sun shines over the lake. And the sun sets in the evening. Sun.";
            var mostFrequentWords = analyzer.CalculateMostFrequentWords(testString, 2);
            Assert.That(mostFrequentWords.Count, Is.EqualTo(2));
            Assert.IsTrue(string.Compare("the", mostFrequentWords[0].Word, true) == 0);
            Assert.IsTrue(string.Compare("sun", mostFrequentWords[1].Word, true) == 0);
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateHighestFrequency_Success()
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateHighestFrequency(testString);
            Assert.That(highestFrequency, Is.EqualTo(3));
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