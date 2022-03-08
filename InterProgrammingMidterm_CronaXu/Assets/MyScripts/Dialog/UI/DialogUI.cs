using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class DialogUI : Singleton<DialogUI>
{
    // UI objects
    [Header("Basic Elements")]
    public Text mainText;
    public Button nextButton;

    public GameObject dialogPanel;
    public GameObject gameManager;

    [Header("Options")]
    public RectTransform optionPanel;
    public OptionUI optionPrefab;

    [Header("Data")]
    public DialogData currentData;
    int currentIndex = 0;

    [Header("AppleGroups")]
    public GameObject apple2;
    public GameObject apple5;
    public GameObject apple6;

    [Header("Triggers")]
    public GameObject a2;
    public GameObject a5;
    public GameObject a6;
    public GameObject waterTri;
    public GameObject CactusTri;
    public GameObject TreeTri;

    [Header("Icons")]
    public GameObject water;
    public GameObject seed;
    public GameObject soil;

    protected void Awake()
    {
        nextButton.onClick.AddListener(ContinueDialog);
    }

    // Load next piece of dialog
    void ContinueDialog()
    {
        if (currentIndex < currentData.dialogPieces.Count)
        {
            UpdateMainDialog(currentData.dialogPieces[currentIndex]);
        }
        else
        {
            dialogPanel.SetActive(false);
        }
        
    }

    // Load new dialogData
    public void UpdateDialogData(DialogData data)
    {
        currentData = data;
        currentIndex = 0;
    }

    // Load corresponding dialogPiece
    public void UpdateMainDialog(DialogPiece piece)
    {
        dialogPanel.SetActive(true);
        currentIndex++;

        // Change gamemanager parameters according to the dialogs triggered
        if (piece.ID == "12")
        {
            apple2.SetActive(true);
            a2.SetActive(false);
            gameManager.GetComponent<GameManager>().appleFilled += 1;
        }

        if (piece.ID == "22")
        {
            apple5.SetActive(true);
            a5.SetActive(false);
            gameManager.GetComponent<GameManager>().appleFilled += 1;
        }

        if (piece.ID == "32")
        {
            apple6.SetActive(true);
            a6.SetActive(false);
            gameManager.GetComponent<GameManager>().appleFilled += 1;
        }

        if (piece.ID == "41")
        {
            waterTri.SetActive(false);
            gameManager.GetComponent<GameManager>().hasWater = true;
            gameManager.GetComponent<GameManager>().treeStatus += 1;
            water.SetActive(true);
        }

        if (piece.ID == "102")
        {
            CactusTri.SetActive(false);
            gameManager.GetComponent<GameManager>().hasSeed = true;
            gameManager.GetComponent<GameManager>().treeStatus += 1;
            seed.SetActive(true);
        }

        if (piece.ID == "111")
        {
            TreeTri.SetActive(false);
            gameManager.GetComponent<GameManager>().hasSoil = true;
            gameManager.GetComponent<GameManager>().treeStatus += 1;
            soil.SetActive(true);
        }


        mainText.text = "";
        mainText.DOText(piece.text, 1f);

        // Check if there is a next dialogPiece
        if (piece.options.Count == 0 && currentData.dialogPieces.Count > 0)
        {
            // Set next button active
            nextButton.interactable = true;
            nextButton.gameObject.SetActive(true);
            nextButton.transform.GetChild(0).gameObject.SetActive(true);
            
        }
        else
        {
            // Set next button inactive
            nextButton.interactable = false;
            nextButton.transform.GetChild(0).gameObject.SetActive(false);
        }

        // Create new options
        CreateOptions(piece);
    }

    // Load Corresponding options
    void CreateOptions(DialogPiece piece)
    {
        // Clear options if there are options left in the panel
        if (optionPanel.childCount > 0)
        {
            for (int i = 0; i < optionPanel.childCount; i++)
            {
                Destroy(optionPanel.GetChild(i).gameObject);
            }
        }

        // Instantiate all options of the dialopPiece
        for (int i = 0; i < piece.options.Count; i++)
        {
            var option = Instantiate(optionPrefab, optionPanel);
            option.UpdateOption(piece, piece.options[i]);
        }
    }
}
