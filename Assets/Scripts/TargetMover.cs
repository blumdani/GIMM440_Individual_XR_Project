using UnityEngine;

public class TargetMover : MonoBehaviour
{
    private Vector3 originalPos;
    private Vector3 moveStartPos;

    private Vector3 moveDirection;
    private float distance;
    private float speed;

    private float moveTimer = 0f;
    private bool isMoving = false;

    void Awake()
    {
        originalPos = transform.localPosition;
    }

    void Update()
    {
        if (!isMoving) return;

        moveTimer += Time.deltaTime * speed;

        float movement = Mathf.PingPong(moveTimer, distance);

        transform.localPosition = moveStartPos + moveDirection * movement;
    }

    public void Configure(Vector3 direction, float distance, float speed)
    {
        this.moveDirection = direction.normalized;
        this.distance = distance;
        this.speed = speed;

        moveStartPos = transform.localPosition;
        moveTimer = 0f;
        isMoving = true;
    }

    public void StopMoving()
    {
        isMoving = false;
        transform.localPosition = originalPos;
    }
}