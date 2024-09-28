using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // Start is called before the first frame update
    private void Awake() {
        DontDestroyOnLoad(this);
    }
    void Start()
    {
        
    }
     public void PlaySound(AudioClip clip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();
        audioSource.clip = clip;
        audioSource.Play();
    }


    void Update()
    {
        
    }
}
