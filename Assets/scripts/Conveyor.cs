using System;
using items;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 3f;
    public ItemType expectedType;
    
    private void OnCollisionStay(Collision other)
    {
        other.transform.Translate(Time.deltaTime * speed * transform.right, Space.World);
    }
}