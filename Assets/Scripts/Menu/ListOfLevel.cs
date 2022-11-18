using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListOfLevel : MonoBehaviour
{
    public GameObject ListOfLevels;
    public GameObject MainMenu;

    public void OpenList()
    {
        MainMenu.SetActive(false);
        ListOfLevels.SetActive(true);
    }
}
