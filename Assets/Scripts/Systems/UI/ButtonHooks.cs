using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonHooks : MonoBehaviour
{
    private Button btn;
    [SerializeField]
    private GameState gameState;

    private void Start()
    {
        btn = GetComponent<Button>();
        btn.onClick.AddListener(delegate { GameManager.Instance.SwitchScenes(gameState); });
    }
}
