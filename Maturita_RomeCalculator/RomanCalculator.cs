using System.Text;

class RomanCalculator
{
    private Dictionary<char, int> romanValues = new Dictionary<char, int>()
    {
        {'I', 1},
        {'V', 5},
        {'X', 10},
        {'L', 50},
        {'C', 100},
        {'D', 500},
        {'M', 1000}
    };

    public int RomanToArabic(string roman)
    {
        int total = 0;
        int lastVal = 0;
        for (var i = roman.Length - 1; i >= 0; i--)
        {
            char c = roman[i];
            int curVal = GetRomanCharacterValue(c);

            total += curVal >= lastVal ? curVal : -curVal;

            lastVal = curVal;
        }

        return total;
    }

    public string ArabicToRoman(int num)
    {
        //15 -> XV
        //135 -> CXXXV
        if ((num < 0) || (num > 3999)) throw new ArgumentOutOfRangeException("insert value betwheen 1 and 3999");
        if (num < 1) return string.Empty;
        if (num >= 1000) return "M" + ArabicToRoman(num - 1000);
        if (num >= 900) return "CM" + ArabicToRoman(num - 900);
        if (num >= 500) return "D" + ArabicToRoman(num - 500);
        if (num >= 400) return "CD" + ArabicToRoman(num - 400);
        if (num >= 100) return "C" + ArabicToRoman(num - 100);
        if (num >= 90) return "XC" + ArabicToRoman(num - 90);
        if (num >= 50) return "L" + ArabicToRoman(num - 50);
        if (num >= 40) return "XL" + ArabicToRoman(num - 40);
        if (num >= 10) return "X" + ArabicToRoman(num - 10);
        if (num >= 9) return "IX" + ArabicToRoman(num - 9);
        if (num >= 5) return "V" + ArabicToRoman(num - 5);
        if (num >= 4) return "IV" + ArabicToRoman(num - 4);
        if (num >= 1) return "I" + ArabicToRoman(num - 1);
        throw new ArgumentOutOfRangeException("something bad happened");
    }

    private int GetRomanCharacterValue(char c)
    {
        if (!romanValues.TryGetValue(c, out int val))
        {
            throw new ArgumentException("Numeral not definied");
        }

        return val;
    }

    public string AddRomanNumerals(string a, string b)
        => ArabicToRoman(RomanToArabic(a) + RomanToArabic(b));
}