using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionUI : MonoBehaviour
{
    // Basic parameters
    public Text optionText;
    private Button thisButton;
    private DialogPiece currentPiece;

    private string nextPieceID;

    void Awake()
    {
        thisButton = GetComponent<Button>();

        // Track option clicked
        thisButton.onClick.AddListener(OnOptionClicked);
    }

    // Update piece and option information
    public void UpdateOption(DialogPiece piece, DialogOption option)
    {
        currentPiece = piece;
        optionText.text = option.text;
        nextPieceID = option.targetID;
    }

    // Return linked dialogPiece when option is clicked
    public void OnOptionClicked()
    {
        if (nextPieceID == "")
        {
            DialogUI.Instance.dialogPanel.SetActive(false);
            return;
        }
        else
        {
            DialogUI.Instance.UpdateMainDialog(DialogUI.Instance.currentData.dialogIndex[nextPieceID]);
        }
    }
}
