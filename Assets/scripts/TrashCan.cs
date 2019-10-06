
using UnityEngine;

public class TrashCan : MonoBehaviour
{
    [SerializeField] private string type;
    private Score score;

    private void Start()
    {
        score = FindObjectOfType<Score>();
    }

    private void OnTriggerStay(Collider other)
    {
        
            if (Input.GetMouseButtonUp(0))
            {
                if (other.GetComponent<cube>().type.Equals(type))
                {
                    Debug.Log("The Right Cube Inside me");
                    score.addPoint();
                }
                Destroy(other.gameObject);
            }
        
    }
}
