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

        [TestCase("You're The sun shines over you're the lake you'RE", "Argument: (text) has invalid character: '\''.")]
        [TestCase("The sun shines over the lake. And the sun sets in the evening. Sun.", "Argument: (text) has invalid character: '.'.")]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord_ThrowsArgumentException(string testString, string expectedOutputMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() =>
            {
                analyzer.CalculateMostFrequentWords(testString, 2);
            });
            Assert.That(exception.Message, Is.EqualTo(expectedOutputMessage));
        }

        [Test]
        public void WordFrequencyAnalyzer_CalculateHighestFrequency_Success()
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateHighestFrequency(testString);
            Assert.That(highestFrequency, Is.EqualTo(3));
        }

        [TestCase("over", 1)]
        [TestCase("the", 3)]
        [TestCase("ThE", 3)]
        public void WordFrequencyAnalyzer_CalculateFrequencyForWord(string wordUnderTest, int expectedFrequency)
        {
            var testString = "The sun shines over the lake thE";
            var highestFrequency = analyzer.CalculateFrequencyForWord(testString, wordUnderTest);
            Assert.That(highestFrequency, Is.EqualTo(expectedFrequency));
        }
    }
}