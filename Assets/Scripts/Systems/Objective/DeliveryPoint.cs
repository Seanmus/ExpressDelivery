using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeliveryPoint : MonoBehaviour
{
    public bool isObjectiveFinished {get; private set;} = false;

    [SerializeField]
    private int timerIncrease = 5;

    private void Start()
    {
        BagelDesu.ObjectiveManager.Instance.RegisterPoint(this);
    }

    public void FinishObjective()
    {
        if (isObjectiveFinished == false)
        {
            isObjectiveFinished = true;
            Timer.Instance.UpdateTime(timerIncrease);
            BagelDesu.ObjectiveManager.Instance.DeliverPackage();
        }
    }
}
