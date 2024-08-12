using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class UpgradedEnemy : MonoBehaviour
{
    private float horizontal;
    private float vertical;
    public int maxHealth = 100;
    int currentHealth;
    public Animator anim;
    public Rigidbody2D target;
    public SpriteRenderer sp;

    public Rigidbody2D myRigidbody;
    public float speed;
    public Spawner spawner;
    public float range = 0;
    float timer = 0;
/*    public bool isAnim;*/
/*    public GameObject[] DropItem;

    public GameObject[] Common;
    public GameObject[] Rare;
    public GameObject[] Epic;
    public GameObject[] Legendary;


    public string[] Grade = { "Common", "Rare", "Epic", "Legendary" };*/
    // Start is called before the first frame update
    private void Start()
    {
        currentHealth = maxHealth;
        spawner = GameObject.Find("Spawn").GetComponent<Spawner>();
    }

    // Update is called once per frame
    public void TakeDamage(int dmg)
    {
        currentHealth -= dmg;
        anim.SetTrigger("Hurt");

        if (currentHealth < 0)
        {
            StartCoroutine(Die());
        }
    }
    IEnumerator Die()
    {
        spawner.monstCount -= 1;
        anim.SetTrigger("Die");
        /*        spawner.monstCount -= 1;

                string grade = Grade[WeightRandom()];
                gameObject.GetComponent<Collider2D>().enabled = false;*/

        /*        if (grade == "Common")
                {
                    Instantiate(Common[Random.Range(0, Common.Length)], transform.position, Quaternion.identity);

                }
                if (grade == "Rare")
                {
                    Instantiate(Rare[Random.Range(0, Rare.Length)], transform.position, Quaternion.identity);

                }*/
        /*        if (grade == "Epic")
                {
                    Instantiate(Epic[Random.Range(0, Epic.Length)], transform.position, Quaternion.identity);

                }
                if (grade == "Legendary")
                {
                    Instantiate(Legendary[Random.Range(0, Legendary.Length)], transform.position, Quaternion.identity);

                }*/
        yield return new WaitForSeconds(0.5f);
        Destroy(gameObject);
    }

    private void FixedUpdate()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody2D>();

        Vector2 dirVec = target.position - myRigidbody.position;
        float Dist = Vector2.Distance(target.position, myRigidbody.position);
        timer += Time.fixedDeltaTime;
        if (Dist <= range && timer >= 1)
        {
            anim.SetTrigger("Attack");
            timer = 0;
            target.GetComponent<Move>().TakeDamage(10);

        }

        else
        {
            Vector2 nextVec = dirVec.normalized * speed * Time.fixedDeltaTime;
            myRigidbody.MovePosition(myRigidbody.position + nextVec);
            myRigidbody.velocity = Vector2.zero;
            /*            if (isAnim == true)
                        {
                            //anim.SetBool("IsWalking", true);

                        }*/
            anim.SetBool("IsWalking", true);

        }

    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }
        sp.flipX = target.position.x < myRigidbody.position.x;
    }


/*    public int WeightRandom()
    {
        int random = Random.Range(1, 100);
        Debug.Log(random);
        if (1 <= random && random < 50)
        {
            return 0;
        }
        if (50 <= random && random < 90)
        {
            return 1;
        }
        if (90 <= random && random < 98)
        {
            return 2;
        }
        if (98 <= random && random <= 100)
        {
            return 3;
        }
        return -1;
    }*/

}