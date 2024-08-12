using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class UseSkill : MonoBehaviour
{
    public GameObject skill;
    public Animator anim;
    public float Timer;
    bool used = false;

    private void Awake()
    {
        skill = UIM.Instance.skill;
    }


    public void Use()
    {
        if (!used)
        {
            Instantiate(skill, transform.position, Quaternion.identity);
            anim.SetTrigger("Skill");
            used = true;
        }


    }
    private void Update()
    {
        if (used)
        {
            Timer += Time.deltaTime;
        }
        if (Timer >= 2)
        {
            Timer = 0;
            used = false;
        }
    }
}
