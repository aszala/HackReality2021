using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveToOffice : MonoBehaviour {
    public void OnTriggerEnter(Collider other) {
        if (other.name.Contains("RNA")) {
            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(4);
            StartCoroutine(loadNext());
        }
    }

    IEnumerator loadNext() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Office");
    }
}
