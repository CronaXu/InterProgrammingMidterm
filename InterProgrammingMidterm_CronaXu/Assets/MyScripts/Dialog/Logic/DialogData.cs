using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Create scriptable object type in create asset options
[CreateAssetMenu(fileName = "New Dialog", menuName = "Dialog/Dialog Data")]

public class DialogData : ScriptableObject
{
    // Create dialogPiece list
    public List<DialogPiece> dialogPieces = new List<DialogPiece>();
    // Create a dictionary to keep track of pieces options lead to
    public Dictionary<string, DialogPiece> dialogIndex = new Dictionary<string, DialogPiece>();

    // Load dialogPiece keys in editor
#if UNITY_EDITOR

    void OnValidate()
    {
        dialogIndex.Clear();
        foreach (var piece in dialogPieces)
        {
            if (!dialogIndex.ContainsKey(piece.ID))
            {
                dialogIndex.Add(piece.ID, piece);
            }
        }
    }

#endif
}
