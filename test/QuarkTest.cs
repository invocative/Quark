namespace unit_test
{
    using System.Linq;
    using Elementary.Quarks;
    using Sprache;
    using Xunit;

    public class QuarkTest
    {
        [Fact]
        public void ParseTest()
        {
            var list = Quark.Token.Parse("[u|u|-d]");
            Assert.Equal(3, list.Count);
            Assert.Equal("u +(2/3)\u212F 2.01 MeV", list.First().ToString());
            Assert.Equal("d̄ -(1/3)\u212F 4.79 MeV", list.Last().ToString());
            var list2 = Quark.Token.Parse("[-u]");
            Assert.Equal("ū +(2/3)ℯ 2.01 MeV", list2.First().ToString());

        }
    }
}