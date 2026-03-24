using System;
using UnityEngine;
using Random = UnityEngine.Random;

public class Codegym11 : MonoBehaviour
{
    public AudioSource SFX;
    public AudioClip[] FootSounds;
    int Sound = 0;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Step()
    {
        Sound = Random.Range(0, FootSounds.Length);
       
        SFX.clip = FootSounds[Sound];
        SFX.Play();
    }
}
