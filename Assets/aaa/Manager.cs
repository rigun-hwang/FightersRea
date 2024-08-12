using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager : MonoBehaviour
{
    public GameObject Inventory;
    public void OnInvetory()
    {
        Inventory.SetActive(true);
    }
    public void OffInvetory()
    {
        Inventory.SetActive(false);
    }
    public void Restart()
    {
        SceneManager.LoadScene("DemoScene");
    }
}
