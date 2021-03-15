using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeskInteract : MonoBehaviour {

    private List<string> objects = new List<string>();


	void Update() {
        bool hand = false, virus = false;

        foreach (string s in objects) {
            if (s.Contains("Hand")) {
                hand = true;
            }

            if (s.Contains("Virus")) {
                virus = true;
			}
		}

        if (hand && virus) {
            // Load new scene
		}
	}

	public void OnTriggerEnter(Collider other) {
        objects.Add(other.name);
    }

    public void OnTriggerExit(Collider other) {
        objects.Remove(other.name);
    }
}
