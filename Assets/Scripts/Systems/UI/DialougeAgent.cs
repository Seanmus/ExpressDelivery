using KartGame.KartSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialougeAgent : MonoBehaviour
{
    [SerializeField]
    private DialougeCluster cluster;
    public void TriggerDialouge()
    {
        DialougeManager.Instance.LoadDialougeCluster(cluster);
        DialougeManager.Instance.OpenDialougeWindow();
        DialougeManager.Instance.AdvanceLoadedCluster();
        gameObject.SetActive(false);
    }
}
