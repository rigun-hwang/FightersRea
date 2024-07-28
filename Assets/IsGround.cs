using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsGround : MonoBehaviour
{
    public bool isGround;
    private void OnTriggerStay2D(Collider2D collision)
    {
        isGround = true;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        isGround = true;
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        isGround = false;
    }
}
