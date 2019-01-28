namespace unit_test
{
    using QuarkParser;
    using Sprache;
    using Xunit;

    public class QuarkTest
    {
        [Fact]
        public void ParseTest()
        {
            var list = Quark.Token.Parse("[u|u|d]");
            Assert.Equal(3, list.Count);
            Assert.Equal("u +(2/3)\u212F 2.01 MeV", list[0].ToString());
        }
    }
}