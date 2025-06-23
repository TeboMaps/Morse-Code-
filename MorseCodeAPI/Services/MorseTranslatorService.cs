using System;

using System.Collections.Generic;
using System.Text;

public class MorseTranslatorService
{
    private static readonly Dictionary<char, string> _textToMorse = new()
    {
        ['A'] = ".-",
        ['B'] = "-...",
        ['C'] = "-.-.",
        ['D'] = "-..",
        ['E'] = ".",
        ['F'] = "..-.",
        ['G'] = "--.",
        ['H'] = "....",
        ['I'] = "..",
        ['J'] = ".---",
        ['K'] = "-.-",
        ['L'] = ".-..",
        ['M'] = "--",
        ['N'] = "-.",
        ['O'] = "---",
        ['P'] = ".--.",
        ['Q'] = "--.-",
        ['R'] = ".-.",
        ['S'] = "...",
        ['T'] = "-",
        ['U'] = "..-",
        ['V'] = "...-",
        ['W'] = ".--",
        ['X'] = "-..-",
        ['Y'] = "-.--",
        ['Z'] = "--..",
        ['1'] = ".----",
        ['2'] = "..---",
        ['3'] = "...--",
        ['4'] = "....-",
        ['5'] = ".....",
        ['6'] = "-....",
        ['7'] = "--...",
        ['8'] = "---..",
        ['9'] = "----.",
        ['0'] = "-----",
        [' '] = "/",
        ['.'] = ".-.-.-",
        [','] = "--..--",
        ['!'] = "-.-.--",
        ['?'] = "..--..",
        ['\''] = ".----.",
        ['-'] = "-....-",
        ['/'] = "-..-.",
        ['@'] = ".--.-."
    };

    private static readonly Dictionary<string, char> _morseToText = new();

    static MorseTranslatorService()
    {
        foreach (var pair in _textToMorse)
            _morseToText[pair.Value] = pair.Key;
    }

    public string Encode(string input)
    {
        var sb = new StringBuilder();
        foreach (char ch in input.ToUpper())
            if (_textToMorse.TryGetValue(ch, out var morse))
                sb.Append(morse + " ");
        return sb.ToString().Trim();
    }

    public string Decode(string morseCode)
    {
        var sb = new StringBuilder();
        foreach (var code in morseCode.Split(' '))
            if (_morseToText.TryGetValue(code, out var letter))
                sb.Append(letter);
        return sb.ToString();
    }
}
