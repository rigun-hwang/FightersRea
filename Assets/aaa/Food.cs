using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public int heal;
    float Timer = 0;
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (collision.gameObject.GetComponent<Move>().health >= 100)
            {
                collision.gameObject.GetComponent<Move>().health = 100;
            }
            else
            {
                collision.gameObject.GetComponent<Move>().health += heal;
                Destroy(gameObject);
            }
        }
    }


}
