using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class VideoNextScene : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer vp;
    void Start()
    {
        vp.loopPointReached += OnVideoFinished;
    }

    // Update is called once per frame
    void OnVideoFinished(VideoPlayer vp){
        SceneManager.LoadScene("Laboratory");
    }
}
