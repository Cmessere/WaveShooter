using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public int maxDamage;
    public int minDamage;
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    public (int min, int max) getDamageRange()
    {
        return (minDamage, maxDamage);
    }
}
