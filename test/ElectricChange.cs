namespace unit_test
{
    using Elementary.Primitives;
    using Xunit;
    public class ElectricChangeTest
    {
        [Fact]
        public void ParseTest()
        {
            Assert.Equal("+(1/2)\u212F", $"{(ElectricCharge)"+(1/2)"}");
            Assert.Equal("-(4/7)\u212F", $"{(ElectricCharge)"-(4/7)"}");
            Assert.Equal("-(4/7)\u212F", $"{(ElectricCharge)"-(4/7)\u212F"}");
        }
    }
}
