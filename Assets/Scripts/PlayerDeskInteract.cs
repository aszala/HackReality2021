using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeskInteract : MonoBehaviour {

    private List<string> objects = new List<string>();

    public GameObject player;

	private void Start() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex)) {
            player.transform.position = SavedPositionManager.savedPositions[sceneIndex];
        }
    }

	void Update() {
        bool hand = false, virus = false;

        foreach (string s in objects) {
            if (s.Contains("Hand") || s.Contains("GrabVolumeSmall")) {
                hand = true;
            }

            if (s.Contains("Virus")) {
                virus = true;
			}
		}

        if (hand && virus) {
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SavedPositionManager.savedPositions[sceneIndex] = transform.position;

            SceneManager.LoadScene("DNASplitter");
        }
	}

	public void OnTriggerEnter(Collider other) {
        objects.Add(other.name);
        print(other.name);
    }

    public void OnTriggerExit(Collider other) {
        objects.Remove(other.name);
    }
}
