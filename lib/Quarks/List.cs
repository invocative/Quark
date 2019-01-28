namespace Elementary.Quarks
{
    using eV.Measure;

    public class TopQuark : Quark
    {
        public TopQuark()
        {
            this.Type = QuarkType.t;
            this.Name = "Top Quark";
            this.Symbol = 't';
            this.EChange = "+(2/3)";
            this.Mass = new Energy(173.1, Energy.GigaElectronVolt);
        }
    }
    public class BottomQuark : Quark
    {
        public BottomQuark()
        {
            this.Type = QuarkType.b;
            this.Name = "Beauty Quark";
            this.Symbol = 'b';
            this.EChange = "-(1/3)";
            this.Mass = new Energy(4.67, Energy.GigaElectronVolt);
        }
    }
    public class UpQuark : Quark
    {
        public UpQuark()
        {
            this.Type = QuarkType.u;
            this.Name = "Up Quark";
            this.Symbol = 'u';
            this.EChange = "+(2/3)";
            this.Mass = new Energy(2.01, Energy.MegaElectronVolt);
        }
    }

    public class DownQuark : Quark
    {
        public DownQuark()
        {
            this.Type = QuarkType.d;
            this.Name = "Down Quark";
            this.Symbol = 'd';
            this.EChange = "-(1/3)";
            this.Mass = new Energy(4.79, Energy.MegaElectronVolt);
        }
    }

    public class StrangeQuark : Quark
    {
        public StrangeQuark()
        {
            this.Type = QuarkType.s;
            this.Name = "Strange Quark";
            this.Symbol = 's';
            this.EChange = "-(1/3)";
            this.Mass = new Energy(4.79, Energy.MegaElectronVolt);
        }
    }

    public class CharmQuark : Quark
    {
        public CharmQuark()
        {
            this.Type = QuarkType.c;
            this.Name = "Charm Quark";
            this.Symbol = 'c';
            this.EChange = "+(2/3)";
            this.Mass = new Energy(1.25, Energy.GigaElectronVolt);
        }
    }
}
