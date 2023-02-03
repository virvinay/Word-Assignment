using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Assignment.Filters
{
    public class CharacterFilter : IWordFilter
    {
        private char _charToFilter;

        /// <summary>
        /// Initialise filter. 
        /// Default value for <paramref name="characterToFilter"/> is 't'.
        /// </summary>
        /// <param name="characterToFilter"></param>
        public CharacterFilter(char characterToFilter = 't')
        {
            _charToFilter = characterToFilter;

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

            return word.IndexOf(_charToFilter) >= 0;
        }
    }
}
