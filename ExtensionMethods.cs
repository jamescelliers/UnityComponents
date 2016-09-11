using UnityEngine;
using System.Collections;

public static class ExtensionMethods
{

    /// <summary>
    /// Removes Bracketed Suffix By finding first "(" and removes chars from there
    /// (Useful for using name for GameObject identification, just dont use (), instead use [] or <>)
    /// </summary>
    /// <param name="objectToRename">GameObject to change name of</param>
    public static void ParseCloneName(this GameObject objectToRename)
    {
        string s = objectToRename.name;
        int startParse = 0;
        char open = '(';

        for (int i = 0; i < objectToRename.name.Length; i++)
        {
            if (objectToRename.name[i].Equals(open))
            {
                startParse = i;
            }
        }
        int count = objectToRename.name.Length - startParse;
        s = s.Remove(startParse, count);
        objectToRename.name = s;
    }

}
