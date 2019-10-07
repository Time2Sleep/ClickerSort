using System;
using items;
using UnityEngine;

public class Conveyor : MonoBehaviour
{
    public float speed = 3f;
    public ItemType expectedType;
    [SerializeField]private Renderer conveyorBelt;
    float conveyorOffset = 0f;
    private void OnCollisionStay(Collision other)
    {
        other.transform.Translate(Time.deltaTime * speed * transform.right, Space.World);
    }

    void FixedUpdate()
    {
        conveyorOffset -= speed / 2f;
        conveyorBelt.material.SetTextureOffset("_MainTex", new Vector2(0, conveyorOffset * Time.deltaTime));
    }
}