using UnityEngine;
using System.Collections;

public class TargetDrop : MonoBehaviour
{
    public float dropAngle = 90f;
    public float rotationSpeed = 120f;
    public float upDelay = 5f;

    private float currentAngle = 0f;
    private bool isMoving = false;
    private bool isDown = false;
    private Coroutine resetCoroutine;

    void Update()
    {
        //Rotate toward down state
        float targetAngle = isDown ? dropAngle : 0f;

        if (!Mathf.Approximately(currentAngle, targetAngle))
        {
            float step = rotationSpeed * Time.deltaTime;
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, step);
            transform.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
        }
    }

    //Drop Target
    public void DropTarget()
    {
        if (isDown || isMoving) return;

        isDown = true;

        // Start timer to go back up if not hit
        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        resetCoroutine = StartCoroutine(AutoReset());
    }

    //Called when shot
    public void OnHit()
    {
        if (!isDown) return;

        GoUp();
    }

    IEnumerator AutoReset()
    {
        yield return new WaitForSeconds(upDelay);

        if (isDown) // only reset if still down
        {
            GoUp();
        }
    }

    void GoUp()
    {
        isDown = false;

        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);
    }
}