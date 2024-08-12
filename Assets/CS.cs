using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CS : MonoBehaviour
{
    public string CName;
    public GameObject CObj;
    public Sprite CSprite;
    public GameObject CMenu;
    public GameObject Skill;
    public string Rank;
    public bool locked;
    public UIM uimanager;
    public Sprite weapon;
    public int health;
    public int damage;
    public int skillDamage;
    public void OnClick()
    {
        CMenu.SetActive(true);
        /*uimanager.playerFeb = CObj;*/

    }
    public void Select()
    {
        if (!locked)
        {
            uimanager.player.sprite = CSprite;
            uimanager.Weapon.sprite = weapon;
            uimanager.health = health;
            uimanager.damage = damage;
            uimanager.skillDamage = skillDamage;
            uimanager.skill = Skill;
        }



    }
}
