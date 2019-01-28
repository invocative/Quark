# Elementary.Quarks
Elementary Particle Quark parser
This project is part of a closed project ElementarySandbox


# API

### ElectricChange

Base parse:
```CSharp
var e = ElectricChange.Token.Parse("+(1/2)") 
// has return new object
{
  IsPositive: true,
  Value: "1/2"
}

e.ToString() // -> ["+(1/2)ℯ"]
```

### Quark

Base parse:
```CSharp

var qList = Quark.Token.Parse("[u|u|d]") // uud a quark structure of proton

qList.First().ToString() // -> [u +(2/3)ℯ 2.01 MeV]


qList.Last()
// ->
{
  Mass: new Energy(2.01, Energy.MegaElectronVolt),
  Symbol: 'u',
  Type: TopQuark,
  EChange: "+(2/3)"
}
```
