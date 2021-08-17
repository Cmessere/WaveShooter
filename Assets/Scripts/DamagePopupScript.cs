using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DamagePopupScript : MonoBehaviour
{
    public float durationTimer;

    public void setDamageText(float damage)
    {
        this.gameObject.GetComponent<TextMeshPro>().text = "-" + damage;
    }

    void Update()
    {
        durationTimer -= Time.deltaTime;
        float step = 1.5f * Time.deltaTime;

        transform.position = Vector3.MoveTowards(transform.position, transform.position + new Vector3(0, 1, 0), step);

        if (durationTimer <= 0)
            Destroy(this.gameObject);
    }
}
