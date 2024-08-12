using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerCombat : MonoBehaviour
{
    public PhotonView pv;
    public Animator anim;
    public Transform attackPoint;
    public int AttakDamage = 10;
    public float attackRange = 0.5f;
    public LayerMask enemyLayers;
    float Timer = 0;
    bool CanAttack = false;
    // Start is called before the first frame update

    private void Awake()
    {
        AttakDamage = UIM.Instance.damage;
    }
    private void Update()
    {
        Timer += Time.deltaTime;
        if (Timer >= 0.5f)
        {
            Timer = 0;
            CanAttack = true;
        }
    }



    public void Attack()
    {
        if (CanAttack) {
            CanAttack = false;

            anim.SetTrigger("Attack");

            Collider2D[] hitEnemy = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
            Debug.Log(hitEnemy);
            foreach (Collider2D enemy in hitEnemy)
            {
                enemy.GetComponent<UpgradedEnemy>().TakeDamage(AttakDamage);
                Debug.Log("Hit");
            }
        }

    }
}
