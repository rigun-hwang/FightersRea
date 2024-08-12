using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool[] isfull;
    public GameObject[] slots;
    public SpriteRenderer Weapon;

    // Start is called before the first frame update
    public void Equip(Image image)
    {
        Weapon.sprite = image.sprite;
    }
}
