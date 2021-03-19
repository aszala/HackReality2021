using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

    public AudioSource src;

    public AudioClip[] clips;

    void Start() {
       // src.clip = clips[0];
       // src.Play();
    }

    public void PlayClip(int index) {
        src.clip = clips[index];
        src.Play();
	}

}
