using UnityEngine;

public class Truck : MonoBehaviour
{
    [SerializeField] private string acceptingType;
    private Score score { get; set; }


    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>().type.Equals(acceptingType))
        {
            Debug.Log("The Right Cube Inside me");
            score.addPoint();
        }

        Destroy(other.gameObject);
    }
}