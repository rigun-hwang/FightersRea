using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Photon.Pun;

public class Move : MonoBehaviourPun
{
    private float horizontal;
    [SerializeField]
    private float speed = 8f;

    [SerializeField]
    private IsGround isGround;

    private bool isFacingRight = false;
    Rigidbody2D rigid;
    [SerializeField] private Animator anim;

    [SerializeField]
    private int JumpForce;

    [SerializeField]
    private PhotonView pv;

    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (!pv.IsMine)
        {
            return;
        }
        horizontal = Input.GetAxis("Horizontal");
        if (horizontal > 0 || horizontal < 0)
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

        rigid.velocity = new Vector2(horizontal * speed, rigid.velocity.y);
        
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
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }



}
