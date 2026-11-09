using System;
using System.Collections.Generic;

public class Translator
{
    public static void Run()
    {
        var englishToGerman = new Translator();
        englishToGerman.AddWord("House", "Haus");
        englishToGerman.AddWord("Car", "Auto");
        englishToGerman.AddWord("Plane", "Flugzeug");

        Console.WriteLine(englishToGerman.Translate("Car"));   // Auto
        Console.WriteLine(englishToGerman.Translate("Plane"));  // Flugzeug
        Console.WriteLine(englishToGerman.Translate("Train"));  // ???
    }

    private Dictionary<string, string> _words = new();

    /// <summary>
    /// Adds a translation from one word to another.
    /// </summary>
    public void AddWord(string fromWord, string toWord)
    {
        _words[fromWord] = toWord;
    }

    /// <summary>
    /// Returns the translation, or "???" if none is available.
    /// </summary>
    public string Translate(string fromWord)
    {
        if (_words.TryGetValue(fromWord, out string translation))
        {
            return translation;
        }

        return "???";
    }
}