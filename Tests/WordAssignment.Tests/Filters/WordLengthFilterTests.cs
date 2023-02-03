using Word_Assignment.Filters;

namespace WordAssignment.Tests
{
    [TestClass]
    public class WordLengthFilterTests
    {
        [TestMethod]
        public void WordLengthFilter_DefaultLength_ExactLength()
        {
            //Arrange
            var sut = new WordLengthFilter();

            //Act
            var result = sut.Filter("123");

            //Assert
            Assert.IsFalse(result, "WordLength filter should return False when word is of the default min length");
        }

        [TestMethod]
        public void WordLengthFilter_DefaultLength_ShortLength()
        {
            //Arrange
            var sut = new WordLengthFilter();

            //Act
            var result = sut.Filter("yo");

            //Assert
            Assert.IsTrue(result, "WordLength filter should return True when word length is smaller than the default min length");
        }

        [TestMethod]
        public void WordLengthFilter_DefaultLength_LongLength()
        {
            //Arrange
            var sut = new WordLengthFilter();

            //Act
            var result = sut.Filter("Capricorn");

            //Assert
            Assert.IsFalse(result, "WordLength filter should return False when word length is greater than the default min length");
        }

        [TestMethod]
        public void WordLengthFilter_DefaultLength_EmptyString()
        {
            //Arrange
            var sut = new WordLengthFilter();


            //Act, Assert
            Assert.ThrowsException<ArgumentNullException>(() => sut.Filter(""), "WordLengthFilter should throw an exception when empty or null string is passed");
        }

        [TestMethod]
        public void WordLengthFilter_CustomLength_Exact()
        {
            //Arrange
            var sut = new WordLengthFilter(10);

            //Act
            var result = sut.Filter("Vacation22");

            //Assert
            Assert.IsFalse(result, "WordLength filter should return False when word length is equal to custom min length");
        }
    }
}