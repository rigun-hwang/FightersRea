using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;
using UnityEngine.UI;

public class Move : MonoBehaviourPun
{
    private float horizontal;
    private float vertical;
    [SerializeField] private Image barImage;

    [SerializeField]
    private float speed = 8f;

    [SerializeField]
    private IsGround isGround;

    [SerializeField]
    private GameObject model;

    private bool isFacingRight = false;
    Rigidbody2D rigid;
    [SerializeField] private Animator anim;

    [SerializeField]
    private int JumpForce;


    [SerializeField]
    public float health = 0;


    [SerializeField]
    VariableJoystick joystick;

    [SerializeField]
    public GameObject dieScreen;

    public SpriteRenderer Player;
    public SpriteRenderer Weapon;
    void Start()
    {
        Debug.Log(UIM.Instance.Map);
        rigid = GetComponent<Rigidbody2D>();
        Player.sprite = UIM.Instance.player.sprite;
        Weapon.sprite = UIM.Instance.Weapon.sprite;
        health = UIM.Instance.health;
    }

    void Update()
    {

        barImage.fillAmount = health/100;
        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        if (horizontal > 0 || horizontal < 0 || vertical > 0 || vertical < 0)
        {
            anim.SetBool("isWalk", true);
        }
        else
        {
            anim.SetBool("isWalk", false);

        }




        Flip();
    }


    private void FixedUpdate()
    {

        rigid.velocity = new Vector2(horizontal * speed, vertical * speed);
        
    }

    private void Jump()
    {
        if (isGround.isGround == true)
        {
            rigid.AddForce(Vector3.up * JumpForce, ForceMode2D.Impulse);

        }
    }
    private void Flip()
    {
        if (isFacingRight && horizontal < 0 || !isFacingRight && horizontal > 0)
        {
            
            isFacingRight = !isFacingRight;
            Vector3 localScale = model.transform.localScale;
            localScale.x *= -1f;
            model.transform.localScale = localScale;
        }
    }
    public void TakeDamage(int damge)
    {
        health -= damge;
        if (health <= 0) {

            Die();
        }
    }
    void Die()
    {
        dieScreen.SetActive(true);
        Debug.Log("Destroyed");
    }


}
