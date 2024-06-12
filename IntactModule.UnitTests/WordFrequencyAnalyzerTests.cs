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
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_AdditionalPunctuation_ThrowsArgumentException()
        {
            var testString = "You're The sun shines over you're the lake you'RE";
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                analyzer.CalculateMostFrequentWords(testString, 2);
            });
            Assert.That(exception.Message, Is.EqualTo("Argument: (text) has invalid character: '\''."));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_MultiSentenceParagraph_ThrowsArgumentException()
        {
            var testString = "The sun shines over the lake. And the sun sets in the evening. Sun.";
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                analyzer.CalculateMostFrequentWords(testString, 2);
            });
            Assert.That(exception.Message, Is.EqualTo("Argument: (text) has invalid character: '.'."));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateHighestFrequency_Success()
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateHighestFrequency(testString);
            Assert.That(highestFrequency, Is.EqualTo(3));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_SingleOccurence_Success()
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateFrequencyForWord(testString, "over");
            Assert.That(highestFrequency, Is.EqualTo(1));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_HighestOccurence_Success()
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateFrequencyForWord(testString, "the");
            Assert.That(highestFrequency, Is.EqualTo(3));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_HighestOccurence_HandlesMixedCasing()
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateFrequencyForWord(testString, "ThE");
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