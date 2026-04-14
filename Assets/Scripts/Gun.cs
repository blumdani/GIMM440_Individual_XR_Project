using UnityEngine;
using UnityEngine.InputSystem;

public class Gun : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;

    public InputActionProperty triggerAction;

    public float fireCooldown = 0.2f;
    private float lastFireTime;

    void Update()
    {
        if (triggerAction.action.ReadValue<float>() > 0.5f)
        {
            if (Time.time > lastFireTime + fireCooldown)
            {
                Shoot();
                lastFireTime = Time.time;
            }
        }
    }

    void Shoot()
    {
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}