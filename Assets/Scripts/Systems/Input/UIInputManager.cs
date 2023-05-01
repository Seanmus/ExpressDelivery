using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInputManager : MonoBehaviour
{
    [SerializeField]
    private KeyCode advanceDialougeKey = KeyCode.Space;

    private void Update()
    {
        if (Input.GetKeyDown(advanceDialougeKey) || Input.GetMouseButtonDown(0))
        {
            DialougeManager.Instance.AdvanceLoadedCluster();
        }
    }
}
