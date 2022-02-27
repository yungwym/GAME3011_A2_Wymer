using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAreaController : MonoBehaviour
{
    public bool isCollidingWithGamePin = false;
    public bool isCollidingWithPlayerPin = false;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
            Debug.Log("Active Area Colliding With GamePin");
            isCollidingWithGamePin = true;
        }

        if (collision.CompareTag("PlayerPin"))
        {
            isCollidingWithPlayerPin = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("GamePin"))
        {
            Debug.Log("Active Area Not Colliding With GamePin");
            isCollidingWithGamePin = false;
        }

        if (collision.CompareTag("PlayerPin"))
        {
            isCollidingWithPlayerPin = false;
        }
    }
}
