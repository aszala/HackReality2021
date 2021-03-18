using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UseVaccine : MonoBehaviour {
    public void OnTriggerEnter(Collider other) {
        if (other.name.Contains("Vaccine")) {
            bool end = EndGame.deliverVaccine();
            other.gameObject.name = "Empty";

            if (end) {
                StartCoroutine(endGame());
			}
        }
    }

    public IEnumerator endGame() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Ending");
    }
}
