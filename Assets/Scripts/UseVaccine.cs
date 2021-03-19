using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseVaccine : MonoBehaviour {

    private bool saidLine = false;

	private void Start() {
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(0);
    }

	public void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Vaccine")) {
            bool end = EndGame.deliverVaccine();
            other.gameObject.name = "Empty";

            if (end) {
                StartCoroutine(endGame());
			} else {
                if (!saidLine) {
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(1);
                    saidLine = true;
                }
			}
        }
    }

    public IEnumerator endGame() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Ending");
    }
}
