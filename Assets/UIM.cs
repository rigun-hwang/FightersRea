using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIM : MonoBehaviour
{

    public string Map;
    public GameObject[] maps;
    public Image player;
    public GameObject playerFeb;
    public Image Weapon;
    public int health;
    public GameObject skill;
    public int damage;
    public int skillDamage;
    public static UIM Instance {
        get
        {
            if(null == instance)
            {
                return null;
            }
            return instance;
        }
    }

    private static UIM instance;

    private void Awake()
    {
        instance = this;

        DontDestroyOnLoad(gameObject);
    }
    public void OpenMenu(GameObject obj)
    {
        obj.SetActive(true);
    }
    public void CloseMenu(GameObject obj)
    {
        obj.SetActive(false);
    }

    public void SelectMap(string Name)
    {
        Map = Name; 
    }

    public void StartGame()
    {
        if (Map != " ")
        {
/*            for (int i = 0; i <  maps.Length; i++)
            {
                if (maps[i].name == Map)
                {
                    maps[i].gameObject.SetActive(true);
                    break;
                }
            }*/
            SceneManager.LoadScene(Map);
        }
    }


    
}
