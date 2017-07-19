using System.Collections.Generic;
using System.Linq;

namespace Counting
{
    public class CountingWords
    {
        public Dictionary<string, int> CountWordPhraseFrequency(string[] phrases)
        {
            var splitedPhrases = phrases.Select(w => w.Split(' '));

            var words = splitedPhrases.SelectMany(w => w).ToList();
            
            List<string> listFragment = ExtractFragments(splitedPhrases);

            words.AddRange(listFragment);

            Dictionary<string, int> wordsCountFrequency = ComputeWordPhraseFrequencyDistribution(words);

            return wordsCountFrequency;
        }

        private static List<string> ExtractFragments(IEnumerable<string[]> splitedPhrases)
        {
            var listFragment = new List<string>();

            foreach (var phrase in splitedPhrases)
            {
                for (int i = 0; i < phrase.Count(); i++)
                {
                    var firstPart = phrase[i];
                    var secondPart = string.Empty;

                    for (int j = i + 1; j < phrase.Count(); j++)
                    {
                        secondPart = string.IsNullOrEmpty(secondPart) ? phrase[j] : string.Join(" ", secondPart, phrase[j]);

                        listFragment.Add(string.Join(" ", firstPart, secondPart));
                    }
                }
            }

            return listFragment;
        }

        private static Dictionary<string, int> ComputeWordPhraseFrequencyDistribution(List<string> words)
        {
            words.Sort();
            var wordsCount = new Dictionary<string, int>();
            var lastCountedWord = string.Empty;
            foreach (var word in words)
            {
                if (word == lastCountedWord)
                    wordsCount[word]++;
                else
                    wordsCount.Add(word, 1);

                lastCountedWord = word;
            }

            return wordsCount;
        }
    }
}
