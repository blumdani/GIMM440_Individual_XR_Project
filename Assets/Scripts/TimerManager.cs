using UnityEngine;
using TMPro;
using System.Collections;

public class TimerManager : MonoBehaviour
{
    [Header("Timer")]
    public float roundTime = 60f;
    public TextMeshProUGUI timerText;

    [Header("Countdown UI")]
    public GameObject countdownObject;        // your raw image background
    public TextMeshProUGUI countdownText;     // text in front of it

    private float timeRemaining;
    private bool isRunning = false;

    void Start()
    {
        timeRemaining = roundTime;

        // Start countdown instead of timer
        StartCoroutine(StartCountdown());
    }

    IEnumerator StartCountdown()
    {
        countdownObject.SetActive(true);

        int count = 3;

        while (count > 0)
        {
            countdownText.text = count.ToString();
            yield return new WaitForSeconds(1f);
            count--;
        }

        countdownText.text = "GO!";
        yield return new WaitForSeconds(0.5f);

        countdownObject.SetActive(false);

        //NOW start the game
        isRunning = true;

        GameManager.Instance.StartGame();
    }

    void Update()
    {
        if (!isRunning) return;

        timeRemaining -= Time.deltaTime;

        if (timeRemaining <= 0)
        {
            timeRemaining = 0;
            isRunning = false;
            EndRound();
        }

        UpdateUI();
    }

    void UpdateUI()
    {
        timerText.text = "Time: " + Mathf.CeilToInt(timeRemaining);
    }

    void EndRound()
    {
        Debug.Log("Round Over");

        GameManager.Instance.EndGame();
    }
}