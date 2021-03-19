using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateRNA : MonoBehaviour {

    public GameObject rna;

    private List<string> objects = new List<string>();

    private bool spawned = false;

    private bool saidLine = false;

	private void Start() {

        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(0);
        GameObject.Find("Target").transform.position = new Vector3(-0.773f, 1.398f, 0.909f);
        StartCoroutine(sayNext());
    }

    IEnumerator sayNext() {
        yield return new WaitForSeconds(8);
        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(1);
        GameObject.Find("Target").transform.position = new Vector3(0, -10, 0);
    }

	void Update() {
        bool poly = false, protein = false;

        foreach (string s in objects) {
            if (s.Contains("Polymerase")) {
                poly = true;
            }

            if (s.Contains("Spike")) {
                protein = true;

                if (!saidLine) {
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(2);
                    GameObject.Find("Target").transform.position = new Vector3(0.554f, 1.1705f, 0.7854f);

                    saidLine = true;
                }
            }
        }

        if (poly && protein && !spawned) {

            GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(3);

            spawned = true;
            objects.Clear();

            StartCoroutine(makeRNA());
        }
    }

    IEnumerator makeRNA() {
        yield return new WaitForSeconds(26);

        Destroy(GameObject.Find("Polymerase"));
        Destroy(GameObject.Find("Spike"));

        GameObject r = Instantiate(rna);
        r.transform.position = new Vector3(-0.254f, 1.558f, 0.881f);
        r.name = "RNA";

        GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(4);
        GameObject.Find("Target").transform.position = new Vector3(-0.265f, 1.683f, 0.889f);

        StartCoroutine(moveTarget());
    }

    IEnumerator moveTarget() {
        yield return new WaitForSeconds(3);
        GameObject.Find("Target").transform.position = new Vector3(1.3568f, 0.76f, 0.1797f);
    }

    public void OnTriggerEnter(Collider other) {
        if (!spawned) {
            objects.Add(other.name);
        }
    }

    public void OnTriggerExit(Collider other) {
        objects.Remove(other.name);
    }
}
