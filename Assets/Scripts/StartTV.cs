using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class StartTV : MonoBehaviour {
    
    public VideoPlayer videoPlayer;

	private bool started = false;

	private void OnTriggerEnter(Collider other) {
		if (other.name.Contains("OVR") || other.name.Contains("Grab") || other.name.Contains("Hand")) {
			if (!started) {
				videoPlayer.Play();
				started = true;
			}
		}
	}
}
