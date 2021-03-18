using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToOffice : MonoBehaviour {
    public void OnTriggerEnter(Collider other) {
        if (other.name.Contains("RNA")) {
            StartCoroutine(loadNext());
        }
    }

    IEnumerator loadNext() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Office");
    }
}
