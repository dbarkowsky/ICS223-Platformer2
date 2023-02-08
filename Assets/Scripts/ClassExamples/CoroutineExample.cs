using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoroutineExample : MonoBehaviour
{
    private Coroutine coroutine;
    void Start()
    {
        coroutine = StartCoroutine(Countdown());
    }

    IEnumerator Countdown()
    {
        Debug.Log("Countdown started");
        for (int i = 10; i >= 0; i--)
        {
            yield return new WaitForSeconds(1.0f);
            Debug.Log(i);
        }
        Debug.Log("Blastoff");
    }
}


