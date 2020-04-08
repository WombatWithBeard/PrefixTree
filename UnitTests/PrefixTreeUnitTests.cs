using Xunit;

namespace UnitTests
{
    public class PrefixTreeUnitTests
    {
        [Fact]
        public void GivenValidResult()
        {
            //Arrange
            var trie = new PrefixTree.Model.PrefixTree();
            trie.Add("мама", 10);
            trie.Add("машинка", 12);
            trie.Add("машиностроение", 12);
            trie.Add("макасины", 100);

            //Act
            var words = trie.GetAllWords("ма");


            //Assert
            Assert.NotEmpty(words);
            Assert.Equal(4, words.Count);
            Assert.Contains("машиностроение", words);
            Assert.Contains("машинка", words);
            Assert.Contains("мама", words);
            Assert.Contains("макасины", words);
        }
        
        [Fact]
        public void GivenInvalidResult()
        {
            //Arrange
            var trie = new PrefixTree.Model.PrefixTree();
            trie.Add("мама", 10);
            trie.Add("машинка", 12);
            trie.Add("машиностроение", 12);
            trie.Add("макасины", 100);

            //Act
            var words = trie.GetAllWords("па");


            //Assert
            Assert.Empty(words);
        }
    }
}