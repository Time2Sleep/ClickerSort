using System;
using items;
using UnityEngine;

public class Truck : MonoBehaviour
{
    private ItemType expectedType;
    private Score score { get; set; }
    public Conveyor myConveyor;

    private void Start()
    {
        score = FindObjectOfType<Score>();
        expectedType = myConveyor.expectedType;
    }

    private void OnTriggerEnter(Collider other)
    {
        Item item = other.GetComponent<Item>();
        if (item != null && item.itemTypes.Contains(expectedType))
        {
            Debug.Log("The Right Cube Inside me");
            score.addPoint();
        }

        Destroy(other.gameObject);
    }
}