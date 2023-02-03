using Word_Assignment.Filters;

namespace WordAssignment.Tests
{
    [TestClass]
    public class VowelPositionFilterTests
    {
        [TestMethod]
        public void VowelPositionFilter_EvenWordLength_VowelsInMiddle()
        {
            var sut = new VowelPositionFilter();

            var result = sut.Filter("peeped"); //ep

            Assert.IsTrue(result, "VowelPositionFilter should return True when Vowel is found  in middle of word with even length");
        }

        [TestMethod]
        public void VowelPositionFilter_OddWordLength_VowelsInMiddle()
        {
            var sut = new VowelPositionFilter();

            var result = sut.Filter("Alice"); //i

            Assert.IsTrue(result, "VowelPositionFilter should return True when Vowel is found  in middle of word with odd length");
        }

        [TestMethod]
        public void VowelPositionFilter_EvenWordLength_VowelsNotInMiddle()
        {
            var sut = new VowelPositionFilter();

            var result = sut.Filter("rather"); //th

            Assert.IsFalse(result, "VowelPositionFilter should return False when Vowel is found although not in middle");
        }

        [TestMethod]
        public void VowelPositionFilter_OddWordLength_VowelsNotInMiddle()
        {
            var sut = new VowelPositionFilter();

            var result = sut.Filter("the"); //h

            Assert.IsFalse(result, "VowelPositionFilter should return False when Vowel is found although not in middle");
        }

        [TestMethod]
        public void VowelPositionFilter_EvenWordLength_NoVowels()
        {
            var sut = new VowelPositionFilter();

            var result = sut.Filter("hymn"); //no vowels

            Assert.IsFalse(result, "VowelPositionFilter should return False when Vowel word has no vowels");
        }

        [TestMethod]
        public void VowelPositionFilter_WordEmptyOrNull()
        {
            //Arrange
            var sut = new VowelPositionFilter(Position.Centre);

            //Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Filter(""), "VowelPositionFilter should throw an errror when word to filter is null or empty");
        }

        [TestMethod]
        public void VowelPositionFilter_NonCenter_VowelFilter()
        {
            //Arrange
            var sut = new VowelPositionFilter(Position.Left);

            //Act, Assert
            Assert.ThrowsException<NotImplementedException>(() => sut.Filter("whatever"), "VowelPositionFilter currently only supports Center Vowel search");
        }
    }
}