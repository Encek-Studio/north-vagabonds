using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FrameManager : MonoBehaviour
{
    private void Start() 
    {   
        QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 60;
    }
}
