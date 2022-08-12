using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountdownTimer : MonoBehaviour
{
    

    public int countdownTime;

    public GameObject startButton;

    public GameObject Tap;

    public Text countdownDisplay;

   


    public void Start()
    {
        StartCoroutine(CountdownToStart());
    }

    IEnumerator CountdownToStart()
    {

        countdownDisplay.gameObject.SetActive(true);
        while (countdownTime > 0)
        {
            countdownDisplay.text = countdownTime.ToString();

            yield return new WaitForSeconds(1f);

            countdownTime--;
        }

        Tap.SetActive(true);


        countdownDisplay.gameObject.SetActive(false);


    }
}
