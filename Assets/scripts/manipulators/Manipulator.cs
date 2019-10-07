using System;
using items;
using UnityEngine;

namespace manipulators
{
    public class Manipulator : MonoBehaviour
    {
        public Conveyor conveyor;
        public ItemType acceptedType;

        private void Start()
        {
            acceptedType = conveyor.expectedType;
        }
    }
}