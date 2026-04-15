using UnityEngine;
using UnityEngine.SceneManagement;

public class ShootableButton : MonoBehaviour
{
    public enum ButtonAction
    {
        LoadScene,
        QuitGame
    }

    [Header("Action")]
    public ButtonAction action;

    [Header("Scene (only used if LoadScene)")]
    public string sceneToLoad;

    [Header("Optional")]
    public AudioSource hitSound;

    private bool hasBeenHit = false;

    public void OnHit()
    {
        if (hasBeenHit) return;
        hasBeenHit = true;

        if (hitSound != null)
            hitSound.PlayOneShot(hitSound.clip);

        switch (action)
        {
            case ButtonAction.LoadScene:
                LoadScene();
                break;

            case ButtonAction.QuitGame:
                QuitGame();
                break;
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(sceneToLoad);
    }

    void QuitGame()
    {
        Debug.Log("Quit Game");

        Application.Quit();

        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}