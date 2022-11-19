using TMPro;
using UnityEngine;

public class ScreenScoreText : MonoBehaviour
{
    public TextMeshProUGUI Score;
    public TextMeshProUGUI TopScore;


    private void Update()
    {
        Score.text = "Score " + PlayerPrefs.GetInt("intermediateScore").ToString();
        TopScore.text = "Top score " + PlayerPrefs.GetInt("TopScore").ToString();
    }

}
