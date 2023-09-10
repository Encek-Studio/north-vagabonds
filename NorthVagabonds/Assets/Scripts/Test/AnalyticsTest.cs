using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Services.Analytics;
using Unity.Services.Core;
using Unity.Services.Core.Environments;
using UnityEngine;
using UnityEngine.Analytics;

public class AnalyticsTest : MonoBehaviour
{
    async void Start()
    {
        try
        {
            var options = new InitializationOptions().SetEnvironmentName("test");
            await UnityServices.InitializeAsync(options);
            AnalyticsService.Instance.StartDataCollection();

            Debug.Log("Unity Services have been initialized!");
        }
        catch (Exception ex)
        {
            Debug.Log("Unity Services couldn't be initialized (reason: " + ex.Message + ")");
        }
    }

    public void AnalyticsTestButton()
    {
        AnalyticsService.Instance.CustomData("testEvent", new Dictionary<string, object>()
        {
            {"testParam", "Hello World"}
        });

        AnalyticsService.Instance.Flush();
    }
}
