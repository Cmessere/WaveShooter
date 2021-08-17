using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject damagePopup;
    public float speed;
    public float health;

    Vector3 playerPosition;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerPosition = player.transform.position;
    }

    void Update()
    {
        MoveTowardsPlayer();

        if (health <= 0)
        {
            DestroyIfDead();
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            int damage = DealDamage(collision);
            SpawnDamagePopup(damage);
        }
    }

    private void SpawnDamagePopup(int damage)
    {
        GameObject currentPopup = Instantiate(damagePopup, gameObject.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);
        currentPopup.GetComponent<DamagePopupScript>().setDamageText(damage);
    }

    private int DealDamage(Collision2D collision)
    {
        (int min, int max) = collision.gameObject.GetComponent<Bullet>().getDamageRange();
        int damage = Random.Range(min, max + 1);
        health -= damage;
        return damage;
    }

    private void MoveTowardsPlayer()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);
    }
    private void DestroyIfDead()
    {
        Destroy(this.gameObject);
    }

}
