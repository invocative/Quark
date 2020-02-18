namespace Elementary.Quarks
{
    using UnitsNet;
    using UnitsNet.Units;

    public class TopQuark : Quark
    {
        public TopQuark(bool isAnti = false) : base(isAnti)
        {
            Type = QuarkType.t;
            Name = "Top Quark";
            InternalChar = "t";
            InternalAntiChar = "t\u0304";
            EChange = "+(2/3)";
            ClearMass = new Energy(9.74e+46, EnergyUnit.ElectronVolt);
            weakType = QuarkWeakType.Up;
        }
    }
    public class BottomQuark : Quark
    {
        public BottomQuark(bool isAnti = false) : base(isAnti)
        {
            Type = QuarkType.b;
            Name = "Beauty Quark";
            InternalChar = "b";
            InternalAntiChar = "b\u0304";
            EChange = "-(1/3)";
            ClearMass = new Energy(2.63e+45, EnergyUnit.ElectronVolt);
            weakType = QuarkWeakType.Down;
        }
    }
    public class UpQuark : Quark
    {
        public UpQuark(bool isAnti = false) : base(isAnti)
        {
            Type = QuarkType.u;
            Name = "Up Quark";
            InternalChar = "u";
            InternalAntiChar = "u\u0304";
            EChange = "+(2/3)";
            ClearMass = new Energy(1.13e+42, EnergyUnit.ElectronVolt);
            weakType = QuarkWeakType.Up;
        }
    }

    public class DownQuark : Quark
    {
        public DownQuark(bool isAnti = false) : base(isAnti)
        {
            Type = QuarkType.d;
            Name = "Down Quark";
            InternalChar = "d";
            InternalAntiChar = "d\u0304";
            EChange = "-(1/3)";
            ClearMass = new Energy(2.69e+42, EnergyUnit.ElectronVolt);
            weakType = QuarkWeakType.Down;
        }
    }

    public class StrangeQuark : Quark
    {
        public StrangeQuark(bool isAnti = false) : base(isAnti)
        {
            Type = QuarkType.s;
            Name = "Strange Quark";
            InternalChar = "s";
            InternalAntiChar = "s\u0304";
            EChange = "-(1/3)";
            ClearMass = new Energy(2.69e+42, EnergyUnit.ElectronVolt);
            weakType = QuarkWeakType.Down;
        }
    }

    public class CharmQuark : Quark
    {
        public CharmQuark(bool isAnti = false) : base(isAnti)
        {
            Type = QuarkType.c;
            Name = "Charm Quark";
            InternalChar = "c";
            InternalAntiChar = "c\u0304";
            EChange = "+(2/3)";
            ClearMass = new Energy(7.17e+44, EnergyUnit.ElectronVolt);
            weakType = QuarkWeakType.Up;
        }
    }
}
