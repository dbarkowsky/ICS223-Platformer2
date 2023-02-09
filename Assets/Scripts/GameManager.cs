using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score;
    private bool timerPaused;
    private int remainingSeconds;
    private bool gameover = false;
    Coroutine ticktock;
    // Start is called before the first frame update
    void Start()
    {
        remainingSeconds = 15;
        timerPaused = false;
        ticktock = StartCoroutine(Tick());
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space") && !gameover)
        {
            if (timerPaused)
            {
                ticktock = StartCoroutine(Tick());
            } else
            {
                StopCoroutine(ticktock);
            }
            timerPaused = !timerPaused;
        }
    }

    IEnumerator Tick()
    {
        score.text = remainingSeconds.ToString();
        while (remainingSeconds > 0)
        {
            yield return new WaitForSecondsRealtime(1.0f);
            remainingSeconds--;
            score.text = remainingSeconds.ToString();
        }
        Debug.Log("Game Over");
        gameover = true;
    }
}
