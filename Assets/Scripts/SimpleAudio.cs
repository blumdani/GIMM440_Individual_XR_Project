using UnityEngine;

public class SimpleAudio : MonoBehaviour
{
    public AudioClip clip;

    void Start()
    {
        AudioSource.PlayClipAtPoint(clip, Camera.main.transform.position, 1f);
    }
}
