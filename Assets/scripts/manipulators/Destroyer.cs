using items;
using UnityEngine;

namespace manipulators
{
    public class Destroyer : Manipulator
    {
        [SerializeField] private float laserDelay;
        [SerializeField] private GameObject laserMesh;
        private bool canShoot = true;
        public LineRenderer lineRenderer;

        private void Update()
        {
            if (canShoot)
            {
                tryShootItem();
            }
        }

        public void recharge()
        {
            canShoot = true;
        }

        private void tryShootItem()
        {
            Item item = lookForItems();
            if (item != null)
            {
                laserMesh.transform.LookAt(item.transform);
                Debug.Log("asd");
                foreach (ItemType itemType in item.itemTypes)
                {
                    Debug.Log(itemType);
                }
            }

            if (item != null && !item.itemTypes.Contains(acceptedType))
            {
                destroyItem(item);
            }
        }

        private Item lookForItems()
        {
            Ray backRay = new Ray(gameObject.transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.Raycast(backRay, out hit))
            {
                Item item = hit.transform.GetComponent<Item>();

                if (item != null)
                {
                    lineRenderer.SetPosition(0, transform.position);
                    lineRenderer.SetPosition(1, item.transform.position);
                    return item;
                }
            }

            return null;
        }

        private void destroyItem(Item item)
        {
            canShoot = false;
            Destroy(item.gameObject);
            Invoke(nameof(recharge), laserDelay);
        }
    }
}