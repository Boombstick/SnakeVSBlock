using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public TextMeshProUGUI TopScore;
    public TextMeshProUGUI HighestLevel;


    private void Update()
    {
        TopScore.text = "Top score " + PlayerPrefs.GetInt("TopScore").ToString();
        HighestLevel.text = "Level " + PlayerPrefs.GetInt("HighestLevel".ToString());
    }
}
