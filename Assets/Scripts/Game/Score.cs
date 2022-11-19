using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public TextMeshProUGUI ScoreText;
    

    private void Update()
    {
        ScoreText.text = PlayerPrefs.GetInt("Score").ToString();
    }



}
