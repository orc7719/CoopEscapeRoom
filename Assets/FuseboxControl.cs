using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using ScriptableObjectArchitecture;

public class FuseboxControl : MonoBehaviour
{
    [SerializeField] TMP_Text[] statusText;
    bool[] fuseboxStatus = new bool[4];

    public void ActivateFusebox(int fuseboxId)
    {
        statusText[fuseboxId].text = fuseboxStatus[fuseboxId] ? "Online" : "Offline";
    }

    public void UpdateFusebox01(bool newValue)
    {
        UpdateFusebox(0, newValue);
    }

    public void UpdateFusebox02(bool newValue)
    {
        UpdateFusebox(1, newValue);
    }

    public void UpdateFusebox03(bool newValue)
    {
        UpdateFusebox(2, newValue);
    }

    public void UpdateFusebox04(bool newValue)
    {
        UpdateFusebox(3, newValue);
    }

    void UpdateFusebox(int fuseboxId, bool newValue)
    {
        fuseboxStatus[fuseboxId] = newValue;

        if (newValue == false)
            ActivateFusebox(fuseboxId);
    }
}
