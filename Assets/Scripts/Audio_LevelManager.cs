using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public AudioClip musicForThisScene;

    private void Start()
    {
        AudioController.Instance.PlayMusic(musicForThisScene);
    }
}
