namespace Elementary.Quarks
{
    using Sprache;

    public class ElectricChange
    {
        public static char Unit = '\u212F';
        public bool IsPositive { get; set; }
        public string Value { get; set; }



        public ElectricChange(bool positive, string value)
        {
            IsPositive = positive;
            Value = value;
        }

        public static Parser<ElectricChange> Token =
            from first in Parse.Char('+').Or(Parse.Char('-')) // plus '+' or minus '-'
            from _1 in Parse.Char('(')  // open brace
            from n1 in Parse.Number         
            from del in Parse.Char('/') // divider
            from n2 in Parse.Number
            from _2 in Parse.Char(')')  // closed brace
            from unit in Parse.Char(Unit).Optional()
            select new ElectricChange(first.Equals('+'), $"{n1}/{n2}");


        public override string ToString() => $"{(IsPositive ? "+" : "-")}({Value}){Unit}";


        public static implicit operator string(ElectricChange e) => e.ToString();
        public static implicit operator ElectricChange(string e) => Token.Parse(e);
    }
}
