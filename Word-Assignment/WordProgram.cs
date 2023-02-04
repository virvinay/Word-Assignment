using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using Word_Assignment.Filters;

namespace WordAssignment
{
    public class WordProgram
    {
        private readonly List<IWordFilter> _filters;

        /// <summary>
        /// Initialise Word Program.
        /// </summary>
        /// <param name="filters">List of IWordFilters.</param>
        /// <exception cref="ArgumentNullException">filters are null</exception>
        /// <exception cref="ArgumentOutOfRangeException">no filters provided</exception>
        public WordProgram(List<IWordFilter> filters)
        {
            if (filters == null)
            {
                throw new ArgumentNullException("Word filters null.");
            }

            if (filters.Count == 0)
            {
                throw new ArgumentOutOfRangeException("Word filters not provided");
            }

            _filters = filters;
        }

        /// <summary>
        /// Applies the Word filters on the provided text.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>List of words remaining after filters are applied</returns>
        /// <exception cref="ArgumentNullException">Text to process is empty or null</exception>
        public List<string> ApplyWordFilters(string text)
        {
            //to hold remaining words after filters are applied to the provided text.
            var results = new List<string>();

            if (string.IsNullOrEmpty(text))
            {
                throw new ArgumentNullException("text to process is null or empty.");
            }

            //select all special chars from text to split.
            //Using whitespace as a character to split could do,
            //however the text file isnt perfectly formatted (e.g. "conversation?'So")
            var specialChars = text.Where(c => char.IsPunctuation(c) || c == ' ');

            // split the text in to an array using puncuations as split character. Iterate over the words.
            foreach (var word in text.Split(specialChars.Distinct().ToArray()))
            {
                //ignore if word is null or empty.
                if (string.IsNullOrEmpty(word))
                    continue;

                //var word = String.Concat(item.Where(c => char.IsAsciiLetterOrDigit(c)));

                // If item did not get filtered out by any of the filters, add to the remaining words list.
                if (_filters.TrueForAll(f => f.Filter(word) == false))
                {
                    //incrementally add remaining words after filters are applied.
                    results.Add(word);
                }
            }
            return results;
        }
    }
}
