using System.Collections;
using System.Collections.Generic;
using TMPro;
//using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

public class SettingsMenu : MonoBehaviour
{
    // Start is called before the first frame update
    Resolution[] resolutions;
    public TMP_Dropdown resolutionDropdown;
    public AudioMixer audioMixer;
    void Start(){
        resolutions = Screen.resolutions;
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for(int i=0; i<resolutions.Length; i++){
            string option = resolutions[i].width +" x "+ resolutions[i].height;
            options.Add(option);
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height){
                currentResolutionIndex=i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }
    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }
    
    public void SetVolume(float volume){
        audioMixer.SetFloat("Volume", volume);
    }
    public void SetFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

}
