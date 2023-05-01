using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    public Transform target;
    private DeliveryPoint closestDeliveryPoint;
    // Start is called before the first frame update
    void Start()
    {
        closestDeliveryPoint = BagelDesu.ObjectiveManager.Instance.packages[0];
    }

    // Update is called once per frame
    void Update()
    {
        if(BagelDesu.ObjectiveManager.Instance.packages.Count > 0)
        {

            foreach (DeliveryPoint deliveryPoint in BagelDesu.ObjectiveManager.Instance.packages)
            {
                if (deliveryPoint.isObjectiveFinished)
                {
                    continue;
                }
                if (Vector3.Distance(deliveryPoint.transform.position, this.transform.position) < 
                    Vector3.Distance(closestDeliveryPoint.transform.position, this.transform.position)|| closestDeliveryPoint.isObjectiveFinished)
                {
                    closestDeliveryPoint = deliveryPoint;
                }
            }
            transform.LookAt(closestDeliveryPoint.transform, Vector3.right);
        }
    }
}
