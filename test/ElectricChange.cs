namespace unit_test
{
    using System;
    using Xunit;
    using QuarkParser;
    public class ElectricChangeTest
    {
        [Fact]
        public void ParseTest()
        {
            Assert.Equal("+(1/2)\u212F", $"{(ElectricChange)"+(1/2)"}");
            Assert.Equal("-(4/7)\u212F", $"{(ElectricChange)"-(4/7)"}");
        }
    }
}
