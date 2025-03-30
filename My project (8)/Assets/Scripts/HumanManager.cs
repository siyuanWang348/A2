using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HumanManager : MonoBehaviour
{
    public GameObject human; 
    public float value = 0f; 
    public Vector3 sizeChange; 
    private Vector3 initialPosition;
    private Quaternion initialRotation;
    private Vector3 initialScale;

    void Start()
    {
        initialPosition = human.transform.position;
        initialRotation = human.transform.rotation;
        initialScale = human.transform.localScale;
        value = human.transform.position.x;
    }

    public void MoveLeft()
    {
        value -= 8.1f; 
        human.transform.position = new Vector3(value, human.transform.position.y, human.transform.position.z); 
    }

    public void MoveRight()
    {
        value += 8.1f;
        human.transform.position = new Vector3(value, human.transform.position.y, human.transform.position.z); 
    }

    public void RotateLeft()
    {
        human.transform.Rotate(0f, 20f, 0f);
    }

    public void RotateRight()
    {
        human.transform.Rotate(0f, -20f, 0f);
    }

    public void ResetPosition()
    {
        human.transform.position = initialPosition;
        human.transform.rotation = initialRotation;
        human.transform.localScale = initialScale;
        value = initialPosition.x;
    }
}