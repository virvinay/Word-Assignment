using Word_Assignment.Filters;

namespace WordAssignment.Tests
{
    [TestClass]
    public class CharacterFilterTests
    {
        [TestMethod]
        public void CharacterFilter_Default_Lowercase_Match()
        {
            //Arrange
            var sut = new CharacterFilter();
            
            //Act
            var result = sut.Filter("cat");

            //Assert
            Assert.IsTrue(result, "CharacterFilter should filter words with default character(t)");
        }

        [TestMethod]
        public void CharacterFilter_Default_UpperCase_NoMatch()
        {
            //Arrange
            var sut = new CharacterFilter();

            //Act
            var result = sut.Filter("CATTTTT");

            //Assert
            Assert.IsFalse(result, "CharacterFilter should not filter words with upper case default character(t)");
        }

        [TestMethod]
        public void CharacterFilter_NonDefaultCharacter_UpperCase_Match()
        {
            //Arrange
            var sut = new CharacterFilter('P');

            //Act
            var result = sut.Filter("Parrot");

            //Assert
            Assert.IsTrue(result, "Character filer should match on non-default Uppercase character.");
        }

        [TestMethod]
        public void CharacterFilter_NonDefaultCharacter_Lowercase_Match()
        {
            //Arrange
            var sut = new CharacterFilter('p');

            //Act
            var result = sut.Filter("seperate");

            //Assert
            Assert.IsTrue(result, "Character filer should match on non-default Lowercase character.");
        }

        [TestMethod]
        public void CharacterFilter_NoMatch()
        {
            //Arrange
            var sut = new CharacterFilter();

            //Act
            var result = sut.Filter("yahoo");

            //Assert
            Assert.IsFalse(result, "CharacterFilter should not match when filtercharacter is not found.");
        }
    }
}