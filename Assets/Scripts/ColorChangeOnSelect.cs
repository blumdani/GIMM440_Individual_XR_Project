using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class ColorChangeOnSelect : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    Renderer rend;

    void Awake()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        rend = GetComponent<Renderer>();

        grabInteractable.selectEntered.AddListener(OnSelect);
    }

    void OnSelect(SelectEnterEventArgs args)
    {
        rend.material.color = new Color(
            Random.value,
            Random.value,
            Random.value
        );
    }
}
