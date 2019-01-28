namespace QuarkParser.Quarks
{
    public class TopQuark : Quark
    {
        public TopQuark()
        {
            this.Type = QuarkType.t;
            this.Name = "Top Quark";
            this.Symbol = 't';
            this.EChange = "+(2/3)";
            // this.Mass = 0.
        }
    }
    public class BottomQuark : Quark
    {
        public BottomQuark(ElectricChange e)
        {
            this.Type = QuarkType.b;
            this.Name = "Bottom Quark";
            this.Symbol = 't';
            this.EChange = "-(1/3)";
            // this.Mass =
        }
    }
}
