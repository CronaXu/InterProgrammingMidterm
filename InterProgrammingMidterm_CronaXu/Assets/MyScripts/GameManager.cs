using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool hasWater = false;
    public bool hasSeed = false;
    public bool hasSoil = false;
    public int appleFilled = 0;

    public int treeStatus = 1;
    [SerializeField]
    private AudioSource soundEffects;
    [SerializeField]
    private AudioClip water;
    [SerializeField]
    private AudioClip seed;
    [SerializeField]
    private AudioClip soil;
    [SerializeField]
    private AudioClip treeGrowth;

    // Different growth levels of the sakura
    [SerializeField]
    private GameObject Sakura1;
    [SerializeField]
    private GameObject Sakura2;
    [SerializeField]
    private GameObject Sakura3;
    [SerializeField]
    private GameObject Sakura4;

    // When player step close to the sakura, let it grow according to the number of objects player has collected
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (treeStatus == 2)
            {
                Sakura1.SetActive(false);
                Sakura2.SetActive(true);
            }
            else if (treeStatus == 3)
            {
                Sakura1.SetActive(false);
                Sakura2.SetActive(false);
                Sakura3.SetActive(true);
            }
            else if (treeStatus == 4)
            {
                Sakura1.SetActive(false);
                Sakura2.SetActive(false);
                Sakura3.SetActive(false);
                Sakura4.SetActive(true);
            }

        }
    }
}
