using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("References")]
    public TargetSequence sequence;
    public GameObject endScreen;

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

        if (endScreen != null)
            endScreen.SetActive(true);
    }
}