using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class cube : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{
    public int speedValue;
    public string type;
    private int speed;
    private Plane plane;
    
    // Start is called before the first frame update
    void Start()
    {
        speed = speedValue;
        plane = new Plane(Vector3.up, new Vector3(0,1,0f)); 
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.right*speed * Time.deltaTime);
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


    public void OnEndDrag(PointerEventData eventData)
    {
        speed = speedValue;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        speed = 0;
    }
}
