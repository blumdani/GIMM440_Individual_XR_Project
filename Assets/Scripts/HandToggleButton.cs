using UnityEngine;
using TMPro;

public class HandToggleButton : MonoBehaviour
{
    const string HAND_PREF_KEY = "ActiveHand";

    [Header("Gun References")]
    public MonoBehaviour rightHandGun;
    public MonoBehaviour leftHandGun; 

    [Header("UI")]
    public TextMeshProUGUI statusText;

    private bool isRightHandActive = true;

    private bool hasBeenHit = false;

    public void OnHit()
    {
        // prevent spam if needed (optional)
        if (hasBeenHit) return;
        hasBeenHit = true;

        ToggleHand();

        // small delay before allowing next toggle
        Invoke(nameof(ResetHit), 0.3f);
    }

    void ResetHit()
    {
        hasBeenHit = false;
    }

    void ToggleHand()
    {
        isRightHandActive = !isRightHandActive;

        if (isRightHandActive)
        {
            rightHandGun.enabled = true;
            leftHandGun.enabled = false;

            if (statusText != null)
                statusText.text = "Current Trigger: Right Hand";

            PlayerPrefs.SetInt(HAND_PREF_KEY, 1);
        }
        else
        {
            rightHandGun.enabled = false;
            leftHandGun.enabled = true;

            if (statusText != null)
                statusText.text = "Current Trigger: Left Hand";

            PlayerPrefs.SetInt(HAND_PREF_KEY, 0);
        }

        PlayerPrefs.Save();
    }

    void Start()
    {
        int saved = PlayerPrefs.GetInt(HAND_PREF_KEY, 1); // default = right hand

        isRightHandActive = (saved == 1);

        if (isRightHandActive)
        {
            rightHandGun.enabled = true;
            leftHandGun.enabled = false;

            if (statusText != null)
                statusText.text = "Current Trigger: Right Hand";
        }
        else
        {
            rightHandGun.enabled = false;
            leftHandGun.enabled = true;

            if (statusText != null)
                statusText.text = "Current Trigger: Left Hand";
        }
    }
}