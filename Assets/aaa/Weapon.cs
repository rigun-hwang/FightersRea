using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Weapon : MonoBehaviour
{
    public int Damage;
    public float Range;
    public PlayerCombat player;
    public void Change()
    {
        player.attackRange = Range;
        player.AttakDamage = Damage;
    }
    private void Start()
    {
        Change();
    }
}
