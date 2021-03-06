using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ReturnExitCyberspace : MonoBehaviour {

    public void OnTriggerEnter(Collider other) {
        if (other.name.Contains("RNA")) {

            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(5);
            StartCoroutine(loadNext());
        }
    }


    IEnumerator loadNext() {
        yield return new WaitForSeconds(10);
        SceneManager.LoadScene("Lab");
    }
}