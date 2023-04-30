using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimerUpdater : MonoBehaviour
{
    private TextMeshProUGUI text;

    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        text.text = Timer.Instance.startTime.ToString();
        Timer.Instance.OnTimerCountdown.AddListener(UpdateTimer);
    }

    public void UpdateTimer(int amount)
    {
        text.text = amount.ToString();
    }
}
