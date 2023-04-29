using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBox : MonoBehaviour
{
    [SerializeField]
    private string tag;
    public GameObject resetPosition;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag(tag) == true)
        {
            other.gameObject.transform.parent.position = resetPosition.transform.position;
        }
    }
}
