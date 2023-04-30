using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace BagelDesu
{
    public class ObjectiveManager : MonoBehaviour
    {
        public List<DeliveryPoint> packages { get; private set; }
        public int deliveredPackages { get; private set; } = 0;
        public UnityEvent<int, int> OnPackageDelivered;

        public static ObjectiveManager Instance
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

        private static ObjectiveManager instance;

        private void Awake()
        {
            if (instance != null)
            {
                Debug.Log("Multiple Singletons detected, deleting object. Please remove extra singleton from scene", this);
                Destroy(this.gameObject);
                return;
            }

            Instance = this;

            packages = new List<DeliveryPoint>();
        }

        private void OnEnable()
        {
            OnPackageDelivered.AddListener(GameManager.Instance.GameOverFromWin);
        }

        public void RegisterPoint(DeliveryPoint point)
        {
            packages.Add(point);
        }

        public void DeliverPackage()
        {
            deliveredPackages++;
            OnPackageDelivered?.Invoke(deliveredPackages ,packages.Count);
        }
    }
}
