using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public int countdownTime;

    public Player player;

    public Spawner spawner;

    private Vector3 direction;

    public float strength = 5f;

    public Text scoreText;

    public Text highScoreText;

    public Text countdownDisplay;

    public GameObject JBText;

    public GameObject Tap;

    public GameObject startButton;

    public GameObject gameplaySound;

    public GameObject deadSound;

    private int score;

    private int highScore;

    public void Awake()
    {
        Application.targetFrameRate = 60;
        Pause();
        JBText.SetActive(false);
        Tap.SetActive(false);
        countdownDisplay.gameObject.SetActive(false);

        

        highScoreText.text = "HiScore " + PlayerPrefs.GetInt("HiScore", 0).ToString();

    }

    public void Play()
    {

        score = 0;
        scoreText.text = score.ToString();

        Instantiate(gameplaySound);


        startButton.SetActive(false);
        JBText.SetActive(false);

        StartCoroutine(CountdownToStart());

        Time.timeScale = 1;
        player.enabled = false;
        spawner.enabled = false;



        Pipes[] pipes = FindObjectsOfType<Pipes>();

        for (int i = 0; i < pipes.Length; i++)
        {
            Destroy(pipes[i].gameObject);
        }

    }

    public void Pause()
    {
        Time.timeScale = 0;
        player.enabled = false;
    }


    public void GameOver()
    {

        Instantiate(deadSound);
        JBText.SetActive(true);

        startButton.SetActive(true);

        Pause();
    }

    public void IncreaseScore()
    {
        score++;
        scoreText.text = score.ToString();
        
        if (score > PlayerPrefs.GetInt("HiScore", 0))
        {
            PlayerPrefs.SetInt("HiScore", score);
            highScoreText.text = "HiScore " + score.ToString();
        }
        

        

    }

    public void MovePlayer()
    {
        player.enabled = true;
        direction = Vector3.up * strength;
        spawner.enabled = true;
        Tap.SetActive(false);
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
