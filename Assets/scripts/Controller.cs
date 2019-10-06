using System;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.Experimental.PlayerLoop;

public class Controller : MonoBehaviour
{
//    public LineRenderer lineRenderer;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
//                lineRenderer.SetPosition(0, ray.origin);
                Item item = hit.transform.gameObject.GetComponent<Item>();
                if (item != null)
                {
//                    lineRenderer.SetPosition(1, hit.point);
                    Destroy(item.gameObject);
                }
            }
        }
    }
}