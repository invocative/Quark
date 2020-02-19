namespace unit_test
{
    using System.Linq;
    using Elementary.Primitives;
    using Sprache;
    using Xunit;

    public class QuarkTest
    {
        [Fact]
        public void ParseTest()
        {
            var list = Quark.Token.Parse("[u|u|-d]");
            Assert.Equal(3, list.Count);
            Assert.Equal("u +(2/3)ℯ 2.3 MeV/c²", list.First().ToString());
            Assert.Equal("d̄ +(1/3)ℯ 4.8 MeV/c²", list.Last().ToString());
            var list2 = Quark.Token.Parse("[-u]");
            Assert.Equal("ū -(2/3)ℯ 2.3 MeV/c²", list2.First().ToString());

        }
    }
}