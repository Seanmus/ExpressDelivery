using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivatePiston : MonoBehaviour
{
    private Animator animator;
    [SerializeField]
    private float timeToReset = 2f;
    private bool isExtended = false;
    private Coroutine ResetRoutine;

    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    public void Push()
    {
        if (!isExtended)
        {
            animator.SetTrigger("Push");
            isExtended = true;
        }

        ResetRoutine = StartCoroutine(Reset());
    }

    private IEnumerator Reset()
    {
        float internalTimer = 0f;
        while(internalTimer < timeToReset)
        {
            internalTimer += Time.deltaTime;
            yield return new WaitForSeconds(.1f);
        }

        animator.SetTrigger("Reset");
        isExtended = false;
    }
}
