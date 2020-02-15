namespace Elementary.Quarks
{
    using eV.Measure;

    public class TopQuark : Quark
    {
        public TopQuark(bool isAnti = false) : base(isAnti)
        {
            this.Type = QuarkType.t;
            this.Name = "Top Quark";
            this.InternalChar = "t";
            this.InternalAntiChar = "t\u0304";
            this.EChange = "+(2/3)";
            this.Mass = new Energy(173.1, Energy.GigaElectronVolt);
            this.weakType = QuarkWeakType.Up;
        }
    }
    public class BottomQuark : Quark
    {
        public BottomQuark(bool isAnti = false) : base(isAnti)
        {
            this.Type = QuarkType.b;
            this.Name = "Beauty Quark";
            this.InternalChar = "b";
            this.InternalAntiChar = "b\u0304";
            this.EChange = "-(1/3)";
            this.Mass = new Energy(4.67, Energy.GigaElectronVolt);
            this.weakType = QuarkWeakType.Down;
        }
    }
    public class UpQuark : Quark
    {
        public UpQuark(bool isAnti = false) : base(isAnti)
        {
            this.Type = QuarkType.u;
            this.Name = "Up Quark";
            this.InternalChar = "u";
            this.InternalAntiChar = "u\u0304";
            this.EChange = "+(2/3)";
            this.Mass = new Energy(2.01, Energy.MegaElectronVolt);
            this.weakType = QuarkWeakType.Up;
        }
    }

    public class DownQuark : Quark
    {
        public DownQuark(bool isAnti = false) : base(isAnti)
        {
            this.Type = QuarkType.d;
            this.Name = "Down Quark";
            this.InternalChar = "d";
            this.InternalAntiChar = "d\u0304";
            this.EChange = "-(1/3)";
            this.Mass = new Energy(4.79, Energy.MegaElectronVolt);
            this.weakType = QuarkWeakType.Down;
        }
    }

    public class StrangeQuark : Quark
    {
        public StrangeQuark(bool isAnti = false) : base(isAnti)
        {
            this.Type = QuarkType.s;
            this.Name = "Strange Quark";
            this.InternalChar = "s";
            this.InternalAntiChar = "s\u0304";
            this.EChange = "-(1/3)";
            this.Mass = new Energy(4.79, Energy.MegaElectronVolt);
            this.weakType = QuarkWeakType.Down;
        }
    }

    public class CharmQuark : Quark
    {
        public CharmQuark(bool isAnti = false) : base(isAnti)
        {
            this.Type = QuarkType.c;
            this.Name = "Charm Quark";
            this.InternalChar = "c";
            this.InternalAntiChar = "c\u0304";
            this.EChange = "+(2/3)";
            this.Mass = new Energy(1.25, Energy.GigaElectronVolt);
            this.weakType = QuarkWeakType.Up;
        }
    }
}
