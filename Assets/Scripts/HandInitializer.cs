using UnityEngine;

public class HandInitializer : MonoBehaviour
{
    public MonoBehaviour rightHandGun;
    public MonoBehaviour leftHandGun;

    const string HAND_PREF_KEY = "ActiveHand";

    void Start()
    {
        int saved = PlayerPrefs.GetInt(HAND_PREF_KEY, 1);

        if (saved == 1)
        {
            rightHandGun.enabled = true;
            leftHandGun.enabled = false;
        }
        else
        {
            rightHandGun.enabled = false;
            leftHandGun.enabled = true;
        }
    }
}