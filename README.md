# WPF Data Binding Demo

Dit project demonstreert verschillende methoden om data binding te implementeren in een WPF (Windows Presentation Foundation) applicatie.

## Inhoud

1. [Wat is Data Binding?](#wat-is-data-binding)
2. [Waarom Data Binding?](#waarom-data-binding)
3. [Data Binding in WPF](#data-binding-in-wpf)
    - [Direct toevoegen van items](#1-direct-toevoegen-van-items)
    - [Toevoegen van objecten met `DisplayMemberPath`](#2-toevoegen-van-objecten-met-displaymemberpath)
    - [Gebruik van `ItemsSource` voor binding](#3-gebruik-van-itemssource-voor-binding)
4. [DataContext en Eigenschappen Binding](#datacontext-en-eigenschappen-binding)
5. [Binding in XAML](#binding-in-xaml)


## 1. Wat is Data Binding?

Data binding is een krachtige en flexibele manier om de User Interface (UI) van een applicatie te koppelen aan de data-logica. In WPF (Windows Presentation Foundation) stelt data binding ons in staat om de UI automatisch bij te werken wanneer de onderliggende data verandert, en vice versa.

## 2. Waarom Data Binding?

1. **Scheiding van Logica en UI**: Data binding helpt om de logica van de applicatie te scheiden van de presentatie. Dit maakt de code beter onderhoudbaar en testbaar.
2. **Automatische Updates**: Wanneer de data verandert, wordt de UI automatisch bijgewerkt zonder dat je handmatige updates in de UI-code hoeft te doen.
3. **Kleiner risico op fouten**: Omdat data en UI automatisch gesynchroniseerd worden, is er minder kans op inconsistenties.

## 3. Data Binding in WPF

In WPF kun je data binding op verschillende manieren toepassen. Laten we enkele methoden bekijken die in de bestaande code worden gebruikt:

### 3.1 Direct toevoegen van items

In dit geval voeg je direct string items toe aan een `ComboBox` en verwerk je de selectie met een event handler. Dit is de eenvoudigste manier, maar het mist de voordelen van data binding zoals automatische updates.

```csharp
cmbDataCodeBehind1.Items.Add("Item 1 (code behind method 1)");
cmbDataCodeBehind1.Items.Add("Item 2 (code behind method 1)");
cmbDataCodeBehind1.Items.Add("Item 3 (code behind method 1)");
cmbDataCodeBehind1.SelectionChanged += CmbDataCodeBehind1_SelectionChanged;
```

### 3.2 Toevoegen van objecten met DisplayMemberPath

Hier voeg je objecten toe en specificeer je welke eigenschap getoond moet worden in de ComboBox door de DisplayMemberPath in te stellen. Dit maakt het mogelijk om complexere objecten te gebruiken en alleen de gewenste eigenschap weer te geven.

Het object wat hier wordt gebruikt noem je myitem.cs en is een standaard class in c-sharp:

```csharp
public class myitem
{
    public string Name { get; set; }
    public string Value { get; set; }
}
```

```csharp
cmbDataCodeBehind2.Items.Add(new myitem { Name = "Item 1 (code behind method 2)", Value = "a" });
cmbDataCodeBehind2.Items.Add(new myitem { Name = "Item 2 (code behind method 2)", Value = "b" });
cmbDataCodeBehind2.Items.Add(new myitem { Name = "Item 3 (code behind method 2)", Value = "c" });
cmbDataCodeBehind2.DisplayMemberPath = "Name";
cmbDataCodeBehind2.SelectionChanged += CmbDataCodeBehind2_SelectionChanged;
```

### 3.3 Gebruik van ItemsSource voor binding

In dit geval koppel je een lijst (_itemsA) aan de ComboBox via de ItemsSource eigenschap. Dit is een meer flexibele manier om data binding te gebruiken omdat je de data-bron kunt wijzigen en de UI automatisch wordt bijgewerkt.

```csharp
_itemsA.Add(new myitem { Name = "Item 1 (code behind binding method 1)", Value = "a" });
_itemsA.Add(new myitem { Name = "Item 2 (code behind binding method 1)", Value = "b" });
_itemsA.Add(new myitem { Name = "Item 3 (code behind binding method 1)", Value = "c" });
cmbDataCodeBehind3.DisplayMemberPath = "Name";
cmbDataCodeBehind3.ItemsSource = _itemsA;
cmbDataCodeBehind3.SelectionChanged += CmbDataCodeBehind2_SelectionChanged;
```

### 4. DataContext en Eigenschappen Binding

Hier wordt DataContext gebruikt om een object aan de hele UI te binden. Door this.DataContext = this in te stellen, geef je aan dat de MainWindow zelf de data-context is. Dit betekent dat alle bindbare eigenschappen binnen de MainWindow beschikbaar zijn voor data binding in de UI.

```csharp
_itemsB.Add(new myitem { Name = "Item 1 (code behind binding method 2)", Value = "a" });
_itemsB.Add(new myitem { Name = "Item 2 (code behind binding method 2)", Value = "b" });
_itemsB.Add(new myitem { Name = "Item 3 (code behind binding method 2)", Value = "c" });
this.DataContext = this;
```

### 5. Binding in XAML

Om data binding nog verder te verduidelijken, kun je binding ook in XAML (eXtensible Application Markup Language) definiëren. Hier is een voorbeeld van hoe je de _itemsB lijst zou kunnen binden aan een ComboBox in XAML:

```html
<Window x:Class="WpfApp_DataBindingDemo.MainWindow"
        xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
        xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
        Title="MainWindow" Height="350" Width="525">
    <Grid>
        <ComboBox x:Name="cmbDataXaml" 
                  DisplayMemberPath="Name" 
                  ItemsSource="{Binding myItemsB}" 
                  SelectionChanged="CmbDataCodeBehind2_SelectionChanged"/>
    </Grid>
</Window>
```

Hier gebruik je de ItemsSource binding direct in XAML om te verbinden met de eigenschap "myItemsB" en stel je DisplayMemberPath in om de Name eigenschap van de myitem objecten weer te geven.