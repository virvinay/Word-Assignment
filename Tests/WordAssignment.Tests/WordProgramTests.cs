using NSubstitute;
using System.Runtime.Intrinsics.X86;
using Word_Assignment.Filters;

namespace WordAssignment.Tests
{
    [TestClass]
    public class WordProgramTests
    {
        private readonly string _textWithPunctuation = "' thought Alice 'without pictures or conversation?'So she was considering in her own mind";
        private readonly string _textWithOutPunctuation = "herself before she found herself falling down a very ";


        [TestMethod]
        public void WordProgram_Constructor_Paramaters()
        {
            //ArgumentOutOfRangeException
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => new WordProgram(new List<IWordFilter>()));
        }

        [TestMethod]
        public void WordProgram_ApplyWordFilters_Paramaters()
        {
            var sut = new WordProgram(GetStubFilters());
            Assert.ThrowsException<ArgumentNullException>(() => sut.ApplyWordFilters(""));
        }

        [TestMethod]
        public void WordProgram_ApplyWordFilters_Text_WithPunctuation()
        {
            var wordLengthFilter = Substitute.For<IWordFilter>();
            var sut = new WordProgram(new List<IWordFilter> { wordLengthFilter });
            // thought Alice 'without pictures or conversation?'So she was considering in her own mind
            wordLengthFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, true, false, true, false, false, false, true, false, true, true);
            sut.ApplyWordFilters(_textWithPunctuation);

            wordLengthFilter.Received(14).Filter(Arg.Any<string>());
        }

        [TestMethod]
        public void WordProgram_ApplyWordFilters_Text_WithoutPunctuation()
        {
            var wordLengthFilter = Substitute.For<IWordFilter>();
            var sut = new WordProgram(new List<IWordFilter> { wordLengthFilter });
            //herself before she found herself falling down a very 
            wordLengthFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, false, false, false, true, false);

            var output = sut.ApplyWordFilters(_textWithOutPunctuation);

            wordLengthFilter.Received(9).Filter(Arg.Any<string>());

            Assert.AreEqual(output.Count, 8);
        }

        [TestMethod]
        public void WordProgram_ApplyWordFilters_Text_WithoutWhitespace()
        {
            var wordLengthFilter = Substitute.For<IWordFilter>();
            var sut = new WordProgram(new List<IWordFilter> { wordLengthFilter });
            //herself.before.she.found.herself.falling.down.a.very 
            wordLengthFilter
                .Filter(Arg.Any<string>())
                .Returns(false, false, false, false, false, false, false, true, false);

            var output = sut.ApplyWordFilters(_textWithOutPunctuation);

            wordLengthFilter.Received(9).Filter(Arg.Any<string>());

            Assert.AreEqual(output.Count, 8);
        }

        private List<IWordFilter> GetStubFilters()
        {
            return new List<IWordFilter>
            {
               Substitute.For<IWordFilter>(),
               Substitute.For<IWordFilter>(),
               Substitute.For<IWordFilter>()
            };
        }
    }
}