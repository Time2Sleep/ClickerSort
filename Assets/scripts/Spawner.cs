using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] cubes;
    
    // Start is called before the first frame update
    private void Start()
    {
        Spawn();
    }


    private IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
        Spawn();
    }

    private void Spawn()
    {
        int rand = Random.Range(0, 3);
        Instantiate(cubes[rand], transform.position, Quaternion.identity);
        StartCoroutine(nameof(Wait));
    }
}
