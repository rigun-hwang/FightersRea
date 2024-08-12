using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Fireball : MonoBehaviour
{
    public int Damge;
    public float speed;
    public Rigidbody2D rigid;
    // Start is called before the first frame update
    void Start()
    {
        Damge = UIM.Instance.skillDamage;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindWithTag("Enemy"))
        {
            Rigidbody2D target = GameObject.FindWithTag("Enemy").GetComponent<Rigidbody2D>();

            Vector2 dirVec = target.position - rigid.position;
            rigid.velocity = dirVec * Time.deltaTime * speed;
        }
        else
        {
            Destroy(gameObject);
        }



    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            collision.GetComponent<UpgradedEnemy>().TakeDamage(Damge);
            Debug.Log("Hit");
            Destroy(this.gameObject);
        }
        if (collision.CompareTag("wall"))
        {
            Destroy(this.gameObject);
        }

    }
}
