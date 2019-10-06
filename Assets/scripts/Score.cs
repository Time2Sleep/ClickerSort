
    using UnityEngine;
    using UnityEngine.UI;

    public class Score : MonoBehaviour
    {
        private int score = 0;
        private Text text;

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