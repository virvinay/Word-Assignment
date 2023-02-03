using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Assignment.Filters
{
    public class WordLengthFilter : IWordFilter

    {
        private int _minWordLength;

        /// <summary>
        /// Initilise the Word Length Filter. Also specify minimum length for the word.
        /// </summary>
        /// <param name="mimWordLength">Defaults to 3.</param>
        public WordLengthFilter(int minWordLength = 3)
        {
            if (minWordLength <= 0)
                throw new ArgumentNullException(nameof(minWordLength), $"Param: {nameof(minWordLength)} should be greater than zero.");

            _minWordLength = minWordLength;

        }

        /// <inheritdoc/>
        /// <exception cref="ArgumentNullException">
        /// <paramref name="word"/> is <see langword="null" />
        /// </exception>
        public bool Filter(string word)
        {
            if (string.IsNullOrEmpty(word))
            {
                throw new ArgumentNullException(nameof(word), $"Param: {nameof(word)} is null.");
            }
            return word.Length < _minWordLength;
        }
    }
}
