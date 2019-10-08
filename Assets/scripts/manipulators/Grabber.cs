using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace manipulators
{
    public class Grabber : Manipulator
    {
        public Transform backRayOrigin;
        public Transform selectorPosition;
        private Item currentItem;
        private bool readyToGrab;
        private Animator animator;
        private static readonly int BeginGrab = Animator.StringToHash("beginGrab");

        private void Start()
        {
            animator = GetComponent<Animator>();
        }

        private void Update()
        {
            if (readyToGrab)
            {
                findItemToGrabAndMove();
            }
            else if (currentItem != null)
            {
                moveItem();
            }
        }

        public void setReadyToGrab()
        {
            readyToGrab = true;
        }

        private void findItemToGrabAndMove()
        {
            Item item = findItem();
            if (item != null && !item.itemTypes.Contains(acceptedType))
            {
                readyToGrab = false;
                animator.SetTrigger(BeginGrab);
                currentItem = item;
                currentItem.setPhysics(false);
            }
        }

        public void dropItem()
        {
            currentItem.setPhysics(true);
            currentItem = null;
        }

        private void moveItem()
        {
            currentItem.transform.position = selectorPosition.transform.position;
        }

        private Item findItem()
        {
            Ray backRay = new Ray(backRayOrigin.position, Vector3.back);
            RaycastHit hit;
            if (Physics.Raycast(backRay, out hit, 2))
            {
                Item item = hit.transform.GetComponent<Item>();
                return item;
            }

            return null;
        }
    }
}