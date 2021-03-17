using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CreateRNA : MonoBehaviour {

    public GameObject rna;

    private List<string> objects = new List<string>();

    void Update() {
        bool poly = false, protein = false;

        foreach (string s in objects) {
            if (s.Contains("Polymerase")) {
                poly = true;
            }

            if (s.Contains("Spike")) {
                protein = true;
            }
        }

        if (poly && protein) {
            Destroy(GameObject.Find("Polymerase"));
            Destroy(GameObject.Find("Spike"));

            GameObject r = Instantiate(rna);
            r.transform.position = new Vector3(-0.254f, 1.558f, 0.881f);
            r.name = "RNA";
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
