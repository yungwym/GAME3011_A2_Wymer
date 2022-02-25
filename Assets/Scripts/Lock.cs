using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum LockType
{
    NONE,
    EASY,
    MEDIUM,
    HARD
}



public class Lock : MonoBehaviour
{
    //Lock Member Variables 
    public LockType lockType;

    public Color pinColor;
    public Color activeAreaColor;

    public Color easyColor;
    public Color mediumColor;
    public Color hardColor;

    public int numOfTiers;

    public GameObject activeArea;
    public GameObject playerPin;

    public float playerPinRotationSpeed = 5.0f;

    public Transform pivotPoint;




    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        playerPin.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), playerPinRotationSpeed * Time.deltaTime);
    }

    public void RotateActiveAreaLeft()
    {
        activeArea.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, 1), playerPinRotationSpeed * Time.deltaTime);
    }

    public void RotateActiveAreaRight()
    {
        activeArea.transform.RotateAround(pivotPoint.position, new Vector3(0, 0, -1), playerPinRotationSpeed * Time.deltaTime);
    }



    public void SetDifficultyToEasy()
    {
        lockType = LockType.EASY;
        pinColor = easyColor;
        activeAreaColor = easyColor;
        activeAreaColor.a = 0.5f;
        SetupColors();
    }

    public void SetDifficultyToMedium()
    {
        lockType = LockType.MEDIUM;
        pinColor = mediumColor;
        activeAreaColor = mediumColor;
        activeAreaColor.a = 0.5f;
        SetupColors();
    }

    public void SetDifficultyToHard()
    {
        lockType = LockType.HARD;
        pinColor = hardColor;
        activeAreaColor = hardColor;
        activeAreaColor.a = 0.5f;
        SetupColors();
    }

    public void SetupColors()
    {
        playerPin.GetComponent<SpriteRenderer>().color = pinColor;
        activeArea.GetComponent <SpriteRenderer>().color = activeAreaColor;
    }


}
