using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIScript : MonoBehaviour
{
    public TMP_Text CampaignCompleted;
    public TMP_Text RandomModeCompleted;
    GameObject ActiveMap;

    void Update()
    {
        if(GameObject.FindGameObjectWithTag("Map") != null)
        {
            ActiveMap = GameObject.FindGameObjectWithTag("Map");
            CampaignCompleted.text = ActiveMap.name;
            RandomModeCompleted.text = ActiveMap.name;
        }
    }
}
