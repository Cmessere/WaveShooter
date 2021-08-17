using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject damagePopup;
    public float speed = 1.0f;
    public float health = 100;

    Vector3 playerPosition;
    void Start()
    {
        GameObject player = GameObject.Find("Player");
        playerPosition = player.transform.position;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Bullet")
        {
            Destroy(collision.gameObject);
            health -= collision.gameObject.GetComponent<Bullet>().getDamage();
            GameObject currentPopup = Instantiate(damagePopup, gameObject.transform.position + new Vector3(0, 1f, 0), Quaternion.identity);

            Debug.Log("Ouch");
        }
    }

    void Update()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, playerPosition, step);
        if(health <= 0)
        {
            Destroy(this.gameObject);
        }
    }


}
