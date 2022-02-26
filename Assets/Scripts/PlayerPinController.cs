using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPinController : MonoBehaviour
{
    public bool isColldingWithGamePin;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
            Debug.Log("Collision with GamePin");
            isColldingWithGamePin = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
            Debug.Log("Not Colliding with GamePin");
            isColldingWithGamePin = false;
        }
    }
}
