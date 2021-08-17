using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float damage = 10f;
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public float getDamage()
    {
        return damage;
    }
}
