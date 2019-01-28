<!-- Logo -->
<p align="center">
  <a href="#">
    <img height="128" width="128" src="https://upload.wikimedia.org/wikipedia/commons/thumb/b/b7/Proton_quark_structure.svg/401px-Proton_quark_structure.svg.png">
  </a>
</p>

<!-- Name -->
<h1 align="center">
  Elementary Quark Lib 🔅
</h1>

Remark:
  `This project is part of a closed project ElementarySandbox`


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


qList.First()
// ->
{
  Mass: new Energy(2.01, Energy.MegaElectronVolt),
  Symbol: 'u',
  Type: TopQuark,
  EChange: "+(2/3)"
}
```
