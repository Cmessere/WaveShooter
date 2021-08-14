using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float bulletSpeed = 10f;

    [SerializeField]
    private Transform barrelTransform;

    [SerializeField]
    private GameObject bullet;

    private Vector2 targetDirection;
    private float targetAngle;

    private void Update()
    {
        targetDirection = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        targetAngle = Mathf.Atan2(targetDirection.y, targetDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, targetAngle - 90f);

        if(Input.GetMouseButtonDown(0))
        {
            FireBullet();
        }
    }

    private void FireBullet()
    {
        GameObject firedBullet = Instantiate(bullet, barrelTransform.position, barrelTransform.rotation);
        firedBullet.GetComponent<Rigidbody2D>().velocity = barrelTransform.up * bulletSpeed;

    }
}
