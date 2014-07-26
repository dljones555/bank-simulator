using System;
using System.IO;
using System.Collections.Generic;
using System.Reflection;

/// <summary>
/// Gets a random first name from an embedded list
/// </summary>
/// <returns>Random first name</returns>

public class RandomNameGenerator
{
    private List<string> m_FirstNames;
    private List<string> m_LastNames;
    private List<String> _randomNameList;

    private Random m_Random;

    public RandomNameGenerator(int numNames)
    {
        m_Random = new Random();
        _randomNameList = new List<String>();

        for (int i = 0; i < numNames; i++)
        {
            _randomNameList.Add(GetRandomFirstName() + " " + GetRandomLastName());
        }
    }

    public List<string> RandomNameList
    {
        get { return _randomNameList; }
    }

    private string GetRandomFirstName()
    {
        try
        {
            if (m_FirstNames == null)
            {
                // Load the names from the embedded resource
                // Note: The following path "BankSimulator.FirstNames.txt" represents
                // the Assembly name "DOT" text file name.  If your assembly name is not
                // BankSimulator, fix it.
                m_FirstNames = LoadResourceStringList("BankTellerSimulator.FirstNames.txt");
            }

            return m_FirstNames[m_Random.Next(m_FirstNames.Count)];
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to generate a random first name: " + ex.Message);
        }
    }

    /// <summary>
    /// Gets a random last name from an embedded list
    /// </summary>
    /// <returns>Random last name</returns>
    private string GetRandomLastName()
    {
        try
        {
            if (m_LastNames == null)
            {
                // Load the names from the embedded resource
                // Note: The following path "BankSimulator.FirstNames.txt" represents
                // the Assembly name "DOT" text file name.  If your assembly name is not
                // BankSimulator, fix it.
                m_LastNames = LoadResourceStringList("BankTellerSimulator.LastNames.txt");
            }

            return m_LastNames[m_Random.Next(m_LastNames.Count)];
        }
        catch (Exception ex)
        {
            throw new Exception("Unable to generate a random last name: " + ex.Message);
        }
    }

    /// <summary>
    /// Loads the requested resource file as a string list
    /// </summary>
    /// <param name="filename">Resource file to load</param>
    /// <returns>List containing the strings in the resource file</returns>
    private List<string> LoadResourceStringList(string filename)
    {
        List<string> list = new List<string>();

        // Get a reference to the running assembly using reflection
        Assembly a = Assembly.GetExecutingAssembly();

        // Read the embedded file using a StreamReader
        using (StreamReader sr = new StreamReader(a.GetManifestResourceStream(filename)))
        {
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine());
            }
            sr.Close();
        }
        Console.WriteLine("Loaded {0} strings for '{1}'", list.Count, filename);
        return list;
    }

}