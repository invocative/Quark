namespace unit_test
{
    using Elementary.Quarks;
    using Sprache;
    using Xunit;

    public class FlavorTransformationTest
    {
        [Fact]
        public void NotCompatibleTest()
        {
            var first = new TopQuark();
            var invalid = new CharmQuark();

            Assert.Equal(0.0f, first.GetFlavorTransformationIndexAt(invalid));
            Assert.Equal(0.0f, first.GetStrengthsСorrelationAt(invalid));
        }
        [Fact]
        public void CompatibleTest()
        {
            var first = new UpQuark();
            var last = new DownQuark();
            const float Vud = 0.974f;

            Assert.Equal(Vud, first.GetFlavorTransformationIndexAt(last));
            Assert.Equal(1.0f, first.GetStrengthsСorrelationAt(last));
        }
        [Theory]
        [InlineData("u", "d", 0.974f)][InlineData("u", "s", 0.225f)][InlineData("u", "b", 0.003f)]
        [InlineData("c", "d", 0.225f)][InlineData("c", "s", 0.973f)][InlineData("c", "b", 0.041f)]
        [InlineData("t", "d", 0.009f)][InlineData("t", "s", 0.040f)][InlineData("t", "b", 0.999f)]
        public void FlavorIndexTest(string _f1_, string _f2_, float Vxx)
        {
            var f1 = Quark.privateToken.Parse(_f1_);
            var f2 = Quark.privateToken.Parse(_f2_);

            Assert.Equal(Vxx, f1.GetFlavorTransformationIndexAt(f2));
        }
    }
}