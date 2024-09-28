using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLose : MonoBehaviour
{
    public String pointTag="point";
    public GameObject player;
       public AudioClip soundToPlay;
    
    public CreatePoint create;
    private void Start() {
        AudioManager audioManager = FindObjectOfType<AudioManager>();
        if (audioManager != null)
        {
            audioManager.PlaySound(soundToPlay);
        }
        else
        {
            Debug.LogError("AudioManager not found!");
        }
    }
    private void OnTriggerEnter2D(Collider2D other) {
        Debug.Log(other);
        if(other.gameObject.CompareTag(pointTag)){
            create.createpoint();
            Destroy(other.gameObject);

        }

    }

}
