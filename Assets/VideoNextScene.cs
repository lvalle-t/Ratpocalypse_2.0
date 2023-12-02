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

    private void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(1);
        }
    }

    // Update is called once per frame
    void OnVideoFinished(VideoPlayer vp){
        SceneManager.LoadScene("MainMenu");
    }
}
