using System;
using UnityEngine;

public class State : MonoBehaviour
{
    private Score score { get; set; }
    [SerializeField] private bool laserUnlocked = true;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }
}