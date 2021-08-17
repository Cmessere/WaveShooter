using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public GameManager GM;

    void Start()
    {
        GM = GameObject.Find("GameManager").GetComponent<GameManager>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
            Debug.Log("Player has been eaten");
        if (collision.gameObject.tag == "Enemy")
        {
            GM.GameOver();
        }
    }
}
