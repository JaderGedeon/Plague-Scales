using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Resolution_Settings : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private TMP_Dropdown resoldropdown;

    private Resolution[] resolutions;
    List<Resolution> filterResol = new List<Resolution>();

    private double currentRefreshRate;
    private int CurrentResolInd = 0;

    void Start()
    {
        resolutions = Screen.resolutions;
        filterResol = new List<Resolution>();

        resoldropdown.ClearOptions();
        currentRefreshRate = Screen.currentResolution.refreshRateRatio.value;

        for (int i = 0; i < resolutions.Length; i++)
        { 
            if (resolutions[i].refreshRateRatio.value == currentRefreshRate)
            {
                filterResol.Add(resolutions[i]);
            }
        }

        List<string> options = new List<string>();  
        for (int i = 0; i < filterResol.Count; i++) 
        {
            string resolutionOPT = filterResol[i].width + "x" + filterResol[i].height + " " + filterResol[i].refreshRateRatio.value + "Hz";
            options.Add(resolutionOPT); 
            if (filterResol[i].width == Screen.width && filterResol[i].height == Screen.height) 
            {
                CurrentResolInd = i;
            }
        }

        resoldropdown.AddOptions(options);
        resoldropdown.value = CurrentResolInd;
        resoldropdown.RefreshShownValue();

    }

    public void SetResolution(int resolutionIndex)   
    {
        Resolution resolution = filterResol[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, true);
    }

    // Update is called once per frame
}
