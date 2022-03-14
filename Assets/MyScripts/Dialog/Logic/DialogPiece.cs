using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class DialogPiece
{
    // Basic parameters of a dialogPiece
    public string ID;
    public Sprite image;

    [TextArea]
    public string text;

    // Create a list of options
    public List<DialogOption> options = new List<DialogOption>();


}
