using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicHandler : MonoBehaviour
{
    [SerializeField] AudioClip MainSong;

    private void Awake()
    {
        int numMusicHandler = FindObjectsOfType<MusicHandler>().Length;
        if(numMusicHandler>1)
        {
            Destroy(gameObject);
        }
        else
        {
            DontDestroyOnLoad(gameObject);
        }
    }

    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        player();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    public void player()
    {
        audioSource.PlayOneShot(MainSong);
    }

    public void stopper()
    {
        audioSource.Stop();
    }

}
