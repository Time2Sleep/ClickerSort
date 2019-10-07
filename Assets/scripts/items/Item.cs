using System.Collections;
using System.Collections.Generic;
using items;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Item : MonoBehaviour, IDragHandler
{
    private Plane plane { get; set; }
    public List<ItemType> itemTypes;

    // Start is called before the first frame update
    void Start()
    {
        plane = new Plane(Vector3.up, new Vector3(0, 1, 0f));
    }

    public void OnDrag(PointerEventData eventData)
    {
        Ray ray = eventData.pressEventCamera.ScreenPointToRay(eventData.position);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            transform.position = ray.origin + ray.direction * distance;
        }
    }

    public void setPhysics(bool val)
    {
        gameObject.GetComponent<Collider>().enabled = val;
    }
}