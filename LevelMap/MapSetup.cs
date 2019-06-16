using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MapSetup : MonoBehaviour
{
    [SerializeField]
    private List<GameObject> mapPlatforms = new List<GameObject>();

    private int currentLevel;

    private void Start()
    {
        Init();   
    }

    private void Init()
    {
        currentLevel = PlayerPrefs.GetInt("CurrentLevel", 1);

        for (int i = 0; i < mapPlatforms.Count; i++)
        {
            if (mapPlatforms[i].GetComponentInChildren<TextMeshPro>())
            {
                mapPlatforms[i].GetComponentInChildren<TextMeshPro>().text = (currentLevel + i) + "";
            }
        }
    }
}
