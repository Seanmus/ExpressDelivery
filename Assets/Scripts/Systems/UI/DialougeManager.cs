using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialougeManager : MonoBehaviour
{
    [SerializeField]
    private GameObject dialougeContainer;
    [SerializeField]
    private Image dialougeImage;
    [SerializeField]
    private TextMeshProUGUI dialougeText;

    [SerializeField]
    private Sprite defaultImage;

    private bool dialougeEnabled = false;
    private bool isLoadedClusterFresh = false;

    private int currDialougePage = 0;
    private int maxDialouge = 0;

    private DialougeCluster loadedCluster;

    public static DialougeManager Instance
    {
        get
        {
            return instance;
        }
        private set
        {
            instance = value;
        }
    }
    private static DialougeManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple Dialouge Managers detected, deleting object. Please remove extra Dialouge Manager from scene", this);
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
    }

    public void OpenDialougeWindow()
    {
        if (dialougeEnabled)
        {
            return;
        }
        dialougeContainer.SetActive(true);
        dialougeEnabled = true;
    }

    public void CloseDialougeWindow()
    {
        dialougeContainer.SetActive(false);
        dialougeEnabled = false;
        isLoadedClusterFresh = false;
    }

    /// <summary>
    /// Think of this a pre-setup to opening the dialouge.
    /// </summary>
    /// <param name="cluster"></param>
    public void LoadDialougeCluster(DialougeCluster cluster)
    {
        loadedCluster = cluster;
        isLoadedClusterFresh = true;
        maxDialouge = cluster.dialougePairs.Length;
        currDialougePage = 0;
    }

    public void AdvanceLoadedCluster()
    {
        if (isLoadedClusterFresh == true && dialougeEnabled)
        {
            if (currDialougePage == maxDialouge)
            {
                //Dialouge Finished
                CancelLoadedCluster();
                CloseDialougeWindow();
                return;
            }

            Sprite image = loadedCluster.dialougePairs[currDialougePage].dialougeImage;
            string text = loadedCluster.dialougePairs[currDialougePage].dialougeContent;

            if (image != null)
            {
                dialougeImage.sprite = image;
            }
            else
            {
                dialougeImage.sprite = default;
            }

            dialougeText.text = text;
            currDialougePage++;
        }
    }

    public void CancelLoadedCluster()
    {
        isLoadedClusterFresh = false;
        loadedCluster = null;
        dialougeImage.sprite = defaultImage;
        dialougeText.text = "";
    }
}