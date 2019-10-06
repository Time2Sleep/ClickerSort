using System;
using UnityEngine;

namespace manipulators
{
    public class Grabber : MonoBehaviour
    {
        public Transform frontRayOrigin;
        public Transform backRayOrigin;
        public Transform selectorPosition;
        private Animator animator;
        private float speed;
        private Item currentItem;
        private bool finished =true;


        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (isBusy())
            {
                putItemToCorrectLine();
            }
            else if (finished)
            {
                checkForIncomingItems();
            }
        }

        private void putItemToCorrectLine()
        {
            currentItem.transform.position = selectorPosition.transform.position;
        }

        public bool isBusy()
        {
            return currentItem != null;
        }

        public void Finished()
        {
            finished = true;
        }

        private void checkForIncomingItems()
        {
            Ray frontRay = new Ray(frontRayOrigin.position, Vector3.forward);
            Ray backRay = new Ray(backRayOrigin.position, Vector3.back);

            Item item = tryGetItem(frontRay);
            if (item != null)
            {
                moveToCorrectLine(item);
            }

            item = tryGetItem(backRay);
            if (item != null)
            {
                moveToCorrectLine(item);
            }


            Debug.DrawRay(frontRayOrigin.position, Vector3.forward * 100f, Color.green);
            Debug.DrawRay(backRayOrigin.position, Vector3.back * 100f, Color.red);
        }

        private void moveToCorrectLine(Item item)
        {
            currentItem = item;
            currentItem.setPhysics(false);
        }

        public void drop()
        {
            finished = false;
            currentItem.setPhysics(true);
            currentItem = null;
        }

        private Item tryGetItem(Ray ray)
        {
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                Item item = hit.transform.GetComponent<Item>();
                if (item != null)
                {
                    return item;
                }
            }

            return null;
        }
    }
}