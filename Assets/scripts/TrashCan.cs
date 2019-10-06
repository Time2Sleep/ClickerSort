
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private string type;
    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Enter" + other.name);
           if (other.GetComponent<cube>().type.Equals(type))
                {
                    Debug.Log("The Right Cube Inside me");
                    score.addPoint();
                }
            Destroy(other.gameObject);
        
    }
}
