using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeMusicScript : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private AudioSource startMusic;
    [SerializeField] private AudioSource colliderMusic;
    public Collider2D ChangeMusic;

    void Start()
    {
        startMusic.Play();
    }

    // Update is called once per frame
    void EnterOnTrigger2D(Collider2D col){
        if(col.CompareTag("Music")){
            startMusic.Stop();
            colliderMusic.Play();
        }
    }
}
