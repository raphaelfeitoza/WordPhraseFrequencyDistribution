using Counting;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CountingTest
{
    [TestClass]
    public class CountingWordsTest
    {
        private readonly string[] _phrases = new[] { "One Two Three", "Two Three Four", "Three Four Five" };

        [TestMethod]
        public void CountWordPhraseFrequency_OnlyWordCounts_WordsCounts()
        {          
            var counter = new CountingWords();
            var wordFrequency =  counter.CountWordPhraseFrequency(_phrases);

            Assert.AreEqual(1, wordFrequency["One"]);

            Assert.AreEqual(2, wordFrequency["Two"]);

            Assert.AreEqual(3, wordFrequency["Three"]);

            Assert.AreEqual(2, wordFrequency["Four"]);

            Assert.AreEqual(1, wordFrequency["Five"]);
        }

        [TestMethod]
        public void CountWordPhraseFrequency_FragmentsCount_FrequenciesCounts()
        {
            var counter = new CountingWords();
            var wordFrequency = counter.CountWordPhraseFrequency(_phrases);

            Assert.AreEqual(1, wordFrequency["One Two"]);

            Assert.AreEqual(2, wordFrequency["Two Three"]);

            Assert.AreEqual(2, wordFrequency["Three Four"]);

            Assert.AreEqual(1, wordFrequency["Four Five"]);

            Assert.AreEqual(1, wordFrequency["One Two Three"]);

            Assert.AreEqual(1, wordFrequency["Two Three Four"]);

            Assert.AreEqual(1, wordFrequency["Three Four Five"]);
        }

    }
}
