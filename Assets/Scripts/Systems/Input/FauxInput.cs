using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FauxInput : MonoBehaviour
{
    [SerializeField]
    private GameObject[] Items;
    [SerializeField]
    private DialougeAgent finalDialouge;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            foreach (GameObject item in Items)
            {
                item.SetActive(true);
            }
            finalDialouge.TriggerDialouge();

            gameObject.SetActive(false);
        }
    }
}
