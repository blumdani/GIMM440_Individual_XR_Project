using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public TargetSequence sequence;
    public GameObject endScreen;

    [Header("End Screen UI")]
    public TextMeshProUGUI finalScoreText;

    public bool IsGameActive = false;

    void Awake()
    {
        Instance = this;
    }

    public void StartGame()
    {
        IsGameActive = true;

        if (sequence != null)
            sequence.StartSequence();
    }

    public void EndGame()
    {
        IsGameActive = false;

        if (sequence != null)
            sequence.StopSequence();

        //SET SCORE TEXT
        if (finalScoreText != null)
            finalScoreText.text = "Score: " + ScoreManager.Instance.score + "!";

        //SHOW END SCREEN
        if (endScreen != null)
            endScreen.SetActive(true);
    }
}