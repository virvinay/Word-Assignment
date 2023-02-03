using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Word_Assignment.Filters
{
    public interface IWordFilter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="word"></param>
        /// <returns><typeparamref  name="true"/> if the check found a match, <typeparamref  name="false"/> otherwise;   </returns>
        public bool Filter(string word);
    }
}
