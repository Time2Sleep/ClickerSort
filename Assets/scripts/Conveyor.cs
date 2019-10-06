using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 3f;

    private void OnCollisionStay(Collision other)
    {
        Debug.Log("Collision stay" + other.gameObject.name);
        other.transform.Translate(transform.right*speed*Time.deltaTime, Space.World);
    }
}
