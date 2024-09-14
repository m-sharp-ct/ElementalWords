using System.Text.RegularExpressions;

namespace ElementalWords;

public partial class Program
{
    /// <summary>
    /// List of Elements in the Periodic Table
    /// </summary>
    private static readonly List<(string Symbol, string Name)> Elements =
    [
        // Seriously, this should be a NuGet or CSV...
        ("H", "Hydrogen"), ("He", "Helium"), ("Li", "Lithium"), ("Be", "Beryllium"), ("B", "Boron"),
        ("C", "Carbon"), ("N", "Nitrogen"), ("O", "Oxygen"), ("F", "Fluorine"), ("Ne", "Neon"),
        ("Na", "Sodium"), ("Mg", "Magnesium"), ("Al", "Aluminum"), ("Si", "Silicon"), ("P", "Phosphorus"),
        ("S", "Sulfur"), ("Cl", "Chlorine"), ("Ar", "Argon"), ("K", "Potassium"), ("Ca", "Calcium"),
        ("Sc", "Scandium"), ("Ti", "Titanium"), ("V", "Vanadium"), ("Cr", "Chromium"), ("Mn", "Manganese"),
        ("Fe", "Iron"), ("Co", "Cobalt"), ("Ni", "Nickel"), ("Cu", "Copper"), ("Zn", "Zinc"),
        ("Ga", "Gallium"), ("Ge", "Germanium"), ("As", "Arsenic"), ("Se", "Selenium"), ("Br", "Bromine"),
        ("Kr", "Krypton"), ("Rb", "Rubidium"), ("Sr", "Strontium"), ("Y", "Yttrium"), ("Zr", "Zirconium"),
        ("Nb", "Niobium"), ("Mo", "Molybdenum"), ("Tc", "Technetium"), ("Ru", "Ruthenium"), ("Rh", "Rhodium"),
        ("Pd", "Palladium"), ("Ag", "Silver"), ("Cd", "Cadmium"), ("In", "Indium"), ("Sn", "Tin"),
        ("Sb", "Antimony"), ("Te", "Tellurium"), ("I", "Iodine"), ("Xe", "Xenon"), ("Cs", "Cesium"),
        ("Ba", "Barium"), ("La", "Lanthanum"), ("Ce", "Cerium"), ("Pr", "Praseodymium"), ("Nd", "Neodymium"),
        ("Pm", "Promethium"), ("Sm", "Samarium"), ("Eu", "Europium"), ("Gd", "Gadolinium"), ("Tb", "Terbium"),
        ("Dy", "Dysprosium"), ("Ho", "Holmium"), ("Er", "Erbium"), ("Tm", "Thulium"), ("Yb", "Ytterbium"),
        ("Lu", "Lutetium"), ("Hf", "Hafnium"), ("Ta", "Tantalum"), ("W", "Tungsten"), ("Re", "Rhenium"),
        ("Os", "Osmium"), ("Ir", "Iridium"), ("Pt", "Platinum"), ("Au", "Gold"), ("Hg", "Mercury"),
        ("Tl", "Thallium"), ("Pb", "Lead"), ("Bi", "Bismuth"), ("Po", "Polonium"), ("At", "Astatine"),
        ("Rn", "Radon"), ("Fr", "Francium"), ("Ra", "Radium"), ("Ac", "Actinium"), ("Th", "Thorium"),
        ("Pa", "Protactinium"), ("U", "Uranium"), ("Np", "Neptunium"), ("Pu", "Plutonium"), ("Am", "Americium"),
        ("Cm", "Curium"), ("Bk", "Berkelium"), ("Cf", "Californium"), ("Es", "Einsteinium"), ("Fm", "Fermium"),
        ("Md", "Mendelevium"), ("No", "Nobelium"), ("Lr", "Lawrencium"), ("Rf", "Rutherfordium"), ("Db", "Dubnium"),
        ("Sg", "Seaborgium"), ("Bh", "Bohrium"), ("Hs", "Hassium"), ("Mt", "Meitnerium"), ("Ds", "Darmstadtium"),
        ("Rg", "Roentgenium"), ("Cn", "Copernicium"), ("Nh", "Nihonium"), ("Fl", "Flerovium"), ("Mc", "Moscovium"),
        ("Lv", "Livermorium"), ("Ts", "Tennessine"), ("Og", "Oganesson")
    ];
    
    // Use this so that I will be able to iterate over the Symbol and Name later
    private static readonly Dictionary<string, string> ElementsDictionary = new();

    private static void Main()
    {
        foreach (var (symbol, name) in Elements)
        {
            ElementsDictionary[symbol] = name;
        }
        Console.WriteLine("Please enter a word you'd like to form using elements from the periodic table");
        var input = Console.ReadLine();
        // Sanity check
        if (string.IsNullOrEmpty(input)) return;
        // Checks string comprised of letters only
        var isLetters = IsLettersRegex().Match(input);
        if (isLetters.Success)
        {
            // Go into forms. Consider Single Responsibility pattern
        }
    }

    [GeneratedRegex("^[a-zA-z]*$")]
    private static partial Regex IsLettersRegex();
}