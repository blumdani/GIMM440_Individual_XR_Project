using UnityEngine;
using System.Collections;

public class TargetDrop : MonoBehaviour
{
    public float dropAngle = 90f;
    public float rotationSpeed = 120f;
    public float upDelay = 3f;

    public int points = 100;
    public AudioSource hitSound;

    private float currentAngle = 0f;
    private bool isDown = false;
    private Coroutine resetCoroutine;

    void Update()
    {
        float targetAngle = isDown ? dropAngle : 0f;

        if (!Mathf.Approximately(currentAngle, targetAngle))
        {
            float step = rotationSpeed * Time.deltaTime;
            currentAngle = Mathf.MoveTowards(currentAngle, targetAngle, step);

            transform.localRotation = Quaternion.Euler(currentAngle, 0f, 0f);
        }
    }

    public void DropTarget()
    {
        if (isDown) return;

        isDown = true;

        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        resetCoroutine = StartCoroutine(AutoReset());
    }

    public void OnHit()
    {
        if (!isDown) return;
        if (!GameManager.Instance.IsGameActive) return;

        if (hitSound != null)
            hitSound.PlayOneShot(hitSound.clip);

        ScoreManager.Instance.AddScore(points);

        GoUp();
    }

    IEnumerator AutoReset()
    {
        yield return new WaitForSeconds(upDelay);

        if (isDown)
            GoUp();
    }

    void GoUp()
    {
        isDown = false;

        if (resetCoroutine != null)
            StopCoroutine(resetCoroutine);

        GetComponent<TargetMover>()?.StopMoving();
    }

    public bool IsDown()
    {
        return isDown;
    }
}