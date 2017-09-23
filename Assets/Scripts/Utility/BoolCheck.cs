using System.Collections.Generic;

public class BoolCheck
{
    /// <summary>
    /// Also works as "All are False", returning false for true
    /// </summary>
    /// <param name="bools"></param>
    /// <returns></returns>
    public static bool AnyTrue(List<bool> bools)
    {
        foreach (bool b in bools)
            if (b)
                return b;
        return false;
    }
    public static bool AnyTrue(bool[] bools)
    {
        foreach (bool b in bools)
            if (b)
                return b;
        return false;
    }
    /// <summary>
    /// Also works as "All are True", returning false for true
    /// </summary>
    /// <param name="bools"></param>
    /// <returns></returns>
    public static bool AnyFalse(List<bool> bools)
    {
        foreach (bool b in bools)
            if (!b)
                return b;
        return true;
    }
    public static bool AnyFalse(bool[] bools)
    {
        foreach (bool b in bools)
            if (!b)
                return b;
        return true;
    }
    /// <summary>
    /// Returns the index of the booleans that return true
    /// </summary>
    public static int[] WhichAreTrue(bool[] bools)
    {
        List<int> areTrue = new List<int>();
        for (int i = 0; i < bools.Length - 1; i++)
        {
            if (bools[i])
                areTrue.Add(i);
        }
        return areTrue.ToArray();
    }
    /// <summary>
    /// Returns the index of the booleans that return false
    /// </summary>
    public static int[] WhichAreFalse(bool[] bools)
    {
        List<int> areFalse = new List<int>();
        for (int i = 0; i < bools.Length - 1; i++)
        {
            if (!bools[i])
                areFalse.Add(i);
        }
        return areFalse.ToArray();
    }
}
