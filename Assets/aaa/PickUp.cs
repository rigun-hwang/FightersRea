using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class PickUp : MonoBehaviour
{
    public Sprite item;
    public Inventory Inventory;
    public int dmg = 0;
    public float range = 0;
    public Weapon wp;

    float Timer = 0;

    private void Start()
    {
        wp = GameObject.Find("L_Weapon").GetComponent<Weapon>();
        Inventory = GameObject.Find("Manager").GetComponent<Manager>().Inventory.GetComponent<Inventory>();
    }

    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 10)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) {
            for (int i = 0; i < Inventory.slots.Length; i++)
            {
                if (Inventory.isfull[i] == false)
                {
                    Inventory.isfull[i] = true;
                    Image image = Inventory.slots[i].GetComponent<Image>();

                    Color tempColor = image.color;
                    tempColor.a = 255f;
                    image.color = tempColor;
                    Inventory.slots[i].GetComponent<Image>().sprite = item;
                    wp.Damage = dmg;
                    wp.Range = range;
                    wp.Change();

                    Destroy(gameObject);
                    break;
                }
            }
        }
    }

}
