using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPinController : MonoBehaviour
{
    public bool isColldingWithGamePin = false;
    public bool isColldingWithActiveArea = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
           // Debug.Log("Player Pin Collision with GamePin");
            isColldingWithGamePin = true;
        }

        if (collision.CompareTag("ActiveArea"))
        {
            isColldingWithActiveArea = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
           // Debug.Log("Player Pin Not Colliding with GamePin");
            isColldingWithGamePin = false;
        }
        
        if (collision.CompareTag("ActiveArea"))
        {
            isColldingWithActiveArea = false;
        }
    }
}
