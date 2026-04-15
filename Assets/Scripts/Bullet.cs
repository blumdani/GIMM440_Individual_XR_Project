using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public float lifeTime = 5f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    void OnCollisionEnter(Collision collision)
    {
        TargetDrop target = collision.collider.GetComponentInParent<TargetDrop>();

        if (target != null)
        {
            target.OnHit();
        }


        //Handle menu buttons
        ShootableButton button = collision.collider.GetComponentInParent<ShootableButton>();
        if (button != null)
        {
            button.OnHit();
        }

        Destroy(gameObject);
    }
}
