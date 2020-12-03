using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer_Manager : MonoBehaviour
{
    public GameObject timerText;
    public GameObject highScoreText;
    public static float limitSeconds = 31f;
    private float step = 1f;
    public static int startOrNah = 0;
    public static bool top1Activated;
    public static bool bottom1Activated;
    public static bool right1Activated;
    public static bool left1Activated;
    public static bool chaser1Activated;
    public static bool playerWon;

    private void Start()
    {
        highScoreText.GetComponent<Text>().text = "Best: " + PlayerPrefs.GetFloat("HighScore", 30f).ToString("n1");
        timerText.GetComponent<Text>().text = "Time Left: 30.0";
        limitSeconds = 31f;
        top1Activated = false;
        bottom1Activated = false;
        right1Activated = false;
        left1Activated = false;
    }

    private void Update()
    {
        if (Count_Down.beginGame == true && startOrNah == 0)
        {
            StartCoroutine(TimerRoutine());
            startOrNah++;
        }
    }

    IEnumerator TimerRoutine()
    {
        Debug.Log("1 AND NOW IS THIS WORKING. limitSeconds is " + limitSeconds);
        while (limitSeconds > 0)
        {
            limitSeconds -= step;
            timerText.GetComponent<Text>().text = "Time Left: " + limitSeconds.ToString("n1");
            Debug.Log("AND NOW IS THIS WORKING. limitSeconds is " + limitSeconds);
            if (limitSeconds <= 25)
            {
                top1Activated = true;
            }
            if (limitSeconds <= 20)
            {
                bottom1Activated = true;
            }
            if (limitSeconds <= 15)
            {
                right1Activated = true;
            }
            if (limitSeconds <= 10)
            {
                left1Activated = true;
            }
            if(limitSeconds == 0)
            {
                playerWon = true;
                SceneManager.LoadScene("GAME_OVER_YOU_WON");
            }
            if(limitSeconds < PlayerPrefs.GetFloat("HighScore", 30f))
            {
                PlayerPrefs.SetFloat("HighScore", limitSeconds);
                highScoreText.GetComponent<Text>().text = "Best: " + limitSeconds.ToString("n1");
            }
            yield return new WaitForSeconds(step);
        }
    }

}
