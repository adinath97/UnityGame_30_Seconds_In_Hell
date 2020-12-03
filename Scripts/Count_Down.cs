using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Count_Down : MonoBehaviour
{
    public int countDownTime = 3;
    public Text countDownDisplay;
    public static bool beginGame;
    public float audioVolume = 0.8f;

    private void Start()
    {
        StartCoroutine(CountDownRoutine());
    }

    IEnumerator CountDownRoutine()
    {
        while(countDownTime > 0)
        {
            countDownDisplay.text = countDownTime.ToString();
            yield return new WaitForSeconds(1f);
            countDownTime--;
        }
        countDownDisplay.text = "GO!";
        yield return new WaitForSeconds(1f);
        countDownDisplay.gameObject.SetActive(false);
        beginGame = true;
    }
}
