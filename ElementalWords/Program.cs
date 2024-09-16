using System.Text.RegularExpressions;

namespace ElementalWords;

public partial class Program
{
    /// <summary>
    /// List of Elements in the Periodic Table
    /// </summary>
    private static readonly Dictionary<string, string> Elements = new()
    {
        // Seriously, this should be a NuGet or CSV...
        { "H", "Hydrogen" }, { "He", "Helium" }, { "Li", "Lithium" }, { "Be", "Beryllium" }, { "B", "Boron" },
        { "C", "Carbon" }, { "N", "Nitrogen" }, { "O", "Oxygen" }, { "F", "Fluorine" }, { "Ne", "Neon" },
        { "Na", "Sodium" }, { "Mg", "Magnesium" }, { "Al", "Aluminum" }, { "Si", "Silicon" }, { "P", "Phosphorus" },
        { "S", "Sulfur" }, { "Cl", "Chlorine" }, { "Ar", "Argon" }, { "K", "Potassium" }, { "Ca", "Calcium" },
        { "Sc", "Scandium" }, { "Ti", "Titanium" }, { "V", "Vanadium" }, { "Cr", "Chromium" }, { "Mn", "Manganese" },
        { "Fe", "Iron" }, { "Co", "Cobalt" }, { "Ni", "Nickel" }, { "Cu", "Copper" }, { "Zn", "Zinc" },
        { "Ga", "Gallium" }, { "Ge", "Germanium" }, { "As", "Arsenic" }, { "Se", "Selenium" }, { "Br", "Bromine" },
        { "Kr", "Krypton" }, { "Rb", "Rubidium" }, { "Sr", "Strontium" }, { "Y", "Yttrium" }, { "Zr", "Zirconium" },
        { "Nb", "Niobium" }, { "Mo", "Molybdenum" }, { "Tc", "Technetium" }, { "Ru", "Ruthenium" }, { "Rh", "Rhodium" },
        { "Pd", "Palladium" }, { "Ag", "Silver" }, { "Cd", "Cadmium" }, { "In", "Indium" }, { "Sn", "Tin" },
        { "Sb", "Antimony" }, { "Te", "Tellurium" }, { "I", "Iodine" }, { "Xe", "Xenon" }, { "Cs", "Cesium" },
        { "Ba", "Barium" }, { "La", "Lanthanum" }, { "Ce", "Cerium" }, { "Pr", "Praseodymium" }, { "Nd", "Neodymium" },
        { "Pm", "Promethium" }, { "Sm", "Samarium" }, { "Eu", "Europium" }, { "Gd", "Gadolinium" }, { "Tb", "Terbium" },
        { "Dy", "Dysprosium" }, { "Ho", "Holmium" }, { "Er", "Erbium" }, { "Tm", "Thulium" }, { "Yb", "Ytterbium" },
        { "Lu", "Lutetium" }, { "Hf", "Hafnium" }, { "Ta", "Tantalum" }, { "W", "Tungsten" }, { "Re", "Rhenium" },
        { "Os", "Osmium" }, { "Ir", "Iridium" }, { "Pt", "Platinum" }, { "Au", "Gold" }, { "Hg", "Mercury" },
        { "Tl", "Thallium" }, { "Pb", "Lead" }, { "Bi", "Bismuth" }, { "Po", "Polonium" }, { "At", "Astatine" },
        { "Rn", "Radon" }, { "Fr", "Francium" }, { "Ra", "Radium" }, { "Ac", "Actinium" }, { "Th", "Thorium" },
        { "Pa", "Protactinium" }, { "U", "Uranium" }, { "Np", "Neptunium" }, { "Pu", "Plutonium" },
        { "Am", "Americium" },
        { "Cm", "Curium" }, { "Bk", "Berkelium" }, { "Cf", "Californium" }, { "Es", "Einsteinium" },
        { "Fm", "Fermium" },
        { "Md", "Mendelevium" }, { "No", "Nobelium" }, { "Lr", "Lawrencium" }, { "Rf", "Rutherfordium" },
        { "Db", "Dubnium" },
        { "Sg", "Seaborgium" }, { "Bh", "Bohrium" }, { "Hs", "Hassium" }, { "Mt", "Meitnerium" },
        { "Ds", "Darmstadtium" },
        { "Rg", "Roentgenium" }, { "Cn", "Copernicium" }, { "Nh", "Nihonium" }, { "Fl", "Flerovium" },
        { "Mc", "Moscovium" },
        { "Lv", "Livermorium" }, { "Ts", "Tennessine" }, { "Og", "Oganesson" }
    };

    private static void Main()
    {
        while (true)
        {
            Console.WriteLine("Please enter a word you'd like to form using elements from the periodic table");
            var input = Console.ReadLine();
            // Sanity check
            if (string.IsNullOrEmpty(input))
            {
                Main();
            }
            
            // Checks string comprised of letters only
            var isLetters = IsLettersRegex().Match(input);
            if (!isLetters.Success)
            {
                Console.WriteLine("input must contain a-z characters only.");
                Main();
            }

            var combinations = ElementalForms(input);
            if (combinations.Count == 0)
            {
                Console.WriteLine("Unable to construct word using period table of elements.");
                Main();
            }

            foreach (var combination in combinations)
            {
                Console.WriteLine(string.Join(", ", combination));
            }
        }
    }

    /// <summary>
    /// Passes responsibility to external function 
    /// </summary>
    /// <param name="input">Input from the user</param>
    /// <returns></returns>
    private static List<List<string>> ElementalForms(string input)
    {
        var forms = new List<List<string>>();
        TrackIndexOfInput(input, 0, [], forms);
        return forms;
    }

    /// <summary>
    /// Tracks the input character by character and checks whether the letter
    /// currently iterating whether there's a matching element in the list of <see cref="Elements"/>
    /// </summary>
    /// <param name="word">Word from user <see cref="input"/></param>
    /// <param name="start">Index to start from the <see cref="word"/></param>
    /// <param name="path">Current location of the process</param>
    /// <param name="formationList">The result of the <see cref="path"/> process</param>
    private static void TrackIndexOfInput(string word, int start, List<string> path, List<List<string>> formationList)
    {
        if (start == word.Length)
        {
            formationList.Add([..path]);
            return;
        }
        
        for (var end = start + 1; end <= word.Length; end++)
        {
            var symbol = word.Substring(start, end - start).ToLower();
            symbol = char.ToUpper(symbol[0]) + symbol.Substring(1);
            if (Elements.TryGetValue(symbol, out var element))
            {
                path.Add($"{element} ({symbol})");
                // Make use of recursion to carry on with the rest of the word (making the formation)
                TrackIndexOfInput(word, end, path, formationList);
                path.RemoveAt(path.Count - 1);
            }
        }
    }

    // Using Generated Regex Attribute
    [GeneratedRegex("^[a-zA-z]*$")]
    private static partial Regex IsLettersRegex();
}