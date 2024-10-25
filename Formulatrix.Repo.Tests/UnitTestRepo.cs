namespace Formulatrix.Repo.Tests
{
    public class UnitTestRepo
    {
        private const string JsonString = @"{
                ""nama"": ""Budi"",
                ""umur"": 30,
                ""kota"": ""Jakarta""
            }";

        private const string XmlString = @"<?xml version=""1.0"" encoding=""UTF-8""?>
            <books>
                <book id=""1"">
                    <title>The Great Gatsby</title>
                    <author>F. Scott Fitzgerald</author>
                    <year>1925</year>
                </book>
                <book id=""2"">
                    <title>To Kill a Mockingbird</title>
                    <author>Harper Lee</author>
                    <year>1960</year>
                </book>
            </books>";

        private readonly Repo _repo;

        public UnitTestRepo()
        {
            _repo = new Repo();
        }

        [Fact]
        public void RepoInit_ShouldReturnNotNull()
        {
            Assert.NotNull(_repo);
        }

        [Theory]
        [InlineData("A", JsonString, 1, "JSON")]
        [InlineData("B", XmlString, 2, "XML")]
        public void Register_And_Retrieve_ShouldReturnExpectedValue(string key, string data, int dataType, string expectedType)
        {
            _repo.Register(key, data, dataType);

            Assert.Equal(data, _repo.Retrieve(key));
            Assert.Equal(expectedType, _repo.GetType(key));
        }

        [Fact]
        public void Deregister_ShouldRemoveData()
        {
            _repo.Register("A", JsonString, 1);
            _repo.Deregister("A");

            Assert.Null(_repo.Retrieve("A"));
        }

        [Theory]
        [InlineData(@"{
                ""nama"": ""Budi"",
                ""umur"": 30,
                ""kota"": ""Jakarta"",
            }", 1, "Validation failed: Invalid JSON format")]
        [InlineData(@"<?xml version=""1.0"" encoding=""UTF-8""?>
            <books
                <book id=""1"">
                    <title>The Great Gatsby</title>
                    <author>F. Scott Fitzgerald</author>
                    <year>1925</year>
                </book>", 2, "Validation failed: Invalid XML format")]
        public void RegisterInvalidData_ShouldThrowArgumentException(string data, int dataType, string expectedMessage)
        {
            var exception = Assert.Throws<ArgumentException>(() => _repo.Register("A", data, dataType));
            Assert.Equal(expectedMessage, exception.Message);
        }

        [Fact]
        public void OverwriteExistingKey_ShouldThrowArgumentException()
        {
            _repo.Register("A", JsonString, 1);
            var exception = Assert.Throws<ArgumentException>(() => _repo.Register("A", XmlString, 2));
            Assert.Equal("Validation failed: The key already exists in the storage and was not overwritten.", exception.Message);
        }
    }
}
