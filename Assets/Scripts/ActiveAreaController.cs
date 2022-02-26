using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAreaController : MonoBehaviour
{
    public bool isCollidingWithGamePin = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
            Debug.Log("Colliding With GamePin");
            isCollidingWithGamePin = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
            Debug.Log("Not Colliding With GamePin");
            isCollidingWithGamePin = false;
        }
    }
}
