using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 * The dialog system is the new coding technique I have used in this game.
 * The dialog system makes good use of scriptable objects, singleton and is comparably complicated.
 * It has a unique data structure to manage UI and data at the same time.
 * The system is very flexible, and many other functions can be easily implemented with the similar structure.
 */
public class DialogController : MonoBehaviour
{
    public DialogData currentData;
    public GameObject RPanel;
    bool canTalk = false;

    // Check if player is close enough to target
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && currentData != null)
        {
            canTalk = true;
            RPanel.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            canTalk = false;
            RPanel.SetActive(false);

        }
    }



    void Update()
    {
        // Start dialog
        if (canTalk && Input.GetKeyDown(KeyCode.R))
        {
            RPanel.SetActive(false);
            OpenDialog();
        }
        Debug.Log(canTalk);
    }


    void OpenDialog()
    {
        // Open UI panel and load dialog information
        DialogUI.Instance.UpdateDialogData(currentData);
        DialogUI.Instance.UpdateMainDialog(currentData.dialogPieces[0]);
    }
}
