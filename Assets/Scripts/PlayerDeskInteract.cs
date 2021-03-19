using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerDeskInteract : MonoBehaviour {

    private List<string> objects = new List<string>();

    public GameObject player;

    public GameObject RNASample;

	private void Start() {
        int sceneIndex = SceneManager.GetActiveScene().buildIndex;
        if (SavedPositionManager.savedPositions.ContainsKey(sceneIndex)) {
            player.transform.position = SavedPositionManager.savedPositions[sceneIndex];

            RNASample.SetActive(true);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(3);
            GameObject.Find("Target").transform.position = new Vector3(-5.202f, 1.089f, 13.244f);
            Instantiate(GameObject.Find("Target")).transform.position = new Vector3(-14.357f, 1.101f, 9.189f);
        } else {
            RNASample.SetActive(false);
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(0);
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

            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(2);
            GameObject.Find("Target").transform.position = new Vector3(0f, 0f, 0f);
            StartCoroutine(loadNext());

            objects.Clear();
        }
	}

    IEnumerator loadNext() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("DNASplitter");
    }

	public void OnTriggerEnter(Collider other) {
        objects.Add(other.name);
        print(other.name);
    }

    public void OnTriggerExit(Collider other) {
        objects.Remove(other.name);
    }
}
