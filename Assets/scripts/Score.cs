using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    private int score { get; set; }
    private Text text { get; set; }

    private void Start()
    {
        text = GetComponent<Text>();
    }

    public void addPoint()
    {
        score++;
        text.text = score.ToString();
    }
}