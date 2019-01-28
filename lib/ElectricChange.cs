namespace Elementary.Quarks
{
    using Sprache;

    public class ElectricChange
    {
        public char Unit = '\u212F';
        public bool IsPositive;
        public string Value;



        public ElectricChange(bool Positive, string value)
        {
            IsPositive = Positive;
            Value = value;
        }

        public static Parser<ElectricChange> Token =
            from first in Parse.Char('+').Or(Parse.Char('-'))
            from _1 in Parse.Char('(')
            from n1 in Parse.Number
            from del in Parse.Char('/')
            from n2 in Parse.Number
            from _2 in Parse.Char(')')
            select new ElectricChange(first.Equals('+'), $"{n1}/{n2}");


        public override string ToString() => $"{(IsPositive ? "+" : "-")}({Value}){Unit}";


        public static implicit operator string(ElectricChange e)
        {
            return e.ToString();
        }
        public static implicit operator ElectricChange(string e)
        {
            return Token.Parse(e);
        }
    }
}
