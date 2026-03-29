using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class Dialogue
{
    [SerializeField] List<string> lines;

    public bool hasChoice;

    [TextArea]
    public string yesResponse;

    [TextArea]
    public string noResponse;

    public List<string> Lines => lines;
}
