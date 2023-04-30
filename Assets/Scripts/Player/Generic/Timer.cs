using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public int startTime;
    [SerializeField]
    private float countdownRate;

    private int currTime = 5;
    private float timeSinceLastCountdown;

    public UnityEvent<int> OnTimerCountdown = new UnityEvent<int>();

    public static Timer Instance
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

    private static Timer instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("Multiple Timer Singletons detected, deleting object. Please remove extra Timer singleton from scene", this);
            Destroy(this.gameObject);
            return;
        }

        Instance = this;
        currTime = startTime;
        timeSinceLastCountdown = Time.time;
        OnTimerCountdown.AddListener(GameManager.Instance.GameOverFromTimer);
    }

    private void Update()
    {
        if (Time.time - timeSinceLastCountdown > countdownRate)
        {
            if (currTime > 0)
            {
                currTime--;
                timeSinceLastCountdown = Time.time;
                OnTimerCountdown?.Invoke(currTime);
            }
        }
    }

    public void UpdateTime(int amount)
    {
        currTime += amount;
        OnTimerCountdown?.Invoke(currTime);
    }
}
