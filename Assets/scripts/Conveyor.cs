using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 3f;

    private void OnCollisionStay(Collision other)
    {
        other.transform.Translate(Time.deltaTime*speed*transform.right, Space.World);
    }
}
