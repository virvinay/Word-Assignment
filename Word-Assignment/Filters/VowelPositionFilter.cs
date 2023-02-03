using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Assignment.Filters
{
    public class VowelPositionFilter : IWordFilter
    {
        private readonly List<char> _vowelsList;
        private readonly Position _position;

        /// <summary>
        /// Initilise the Vowel Filter. Also specify position for vowel search.
        /// </summary>
        /// <param name="position">Defaults to Centre. Other position are currently not Implemented</param>
        public VowelPositionFilter(Position position = Position.Centre)
        {
            _position = position;

            _vowelsList = new List<char>
        {
                'a','e','i','o','u'
        };
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

            //Check if there are vowels in the string
            if (word.ToLower().IndexOfAny(_vowelsList.ToArray()) >= 0)
            {
                switch (_position)
                {
                    case Position.Centre:
                        var length = word.Length;
                        //If Length is a even number, select a the centre 2 characters; otherwise select 1 centre character.
                        var middlechars = (length % 2 != 0) ? word.Substring(length / 2, 1) : word.Substring((length / 2) - 1, 2);

                        // Check if any of the middlechars contain a vowel.
                        return middlechars.ToLower().IndexOfAny(_vowelsList.ToArray()) >= 0;

                    default:
                        throw new NotImplementedException("Only Position.Centre  capabiltiy for Vowels Filter currently supported");
                }
            }
            return false;
        }
    }
}
