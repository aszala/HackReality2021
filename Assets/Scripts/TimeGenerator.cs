using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimeGenerator : MonoBehaviour {

    public GameObject parent;
    public Shader cybervoid;

	private float[] offsets;

    void Start() {
		offsets = new float[parent.transform.childCount];

		for (int i = 0; i < parent.transform.childCount; i++) {
            parent.transform.GetChild(i).GetComponent<MeshRenderer>().material = new Material(cybervoid);

			offsets[i] = Random.value * 10;
		}


        //StartCoroutine(SetTime());
    }

	private void FixedUpdate() {
		for (int i = 0; i < parent.transform.childCount; i++) {
			float time = Mathf.Sin(Time.time + offsets[i]);
			parent.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("Vector1_EA88A7BF", time);
		}
	}

	// Update is called once per frame
	/* IEnumerator SetTime() {
		 while (true) {
			 for (int i = 0; i < parent.transform.childCount; i++) {
				 float time = Mathf.Sin(Time.time);
				 parent.transform.GetChild(i).GetComponent<MeshRenderer>().material.SetFloat("Vector1_EA88A7BF", time);
			 }

			 yield return new WaitForSecondsRealtime(0.5f);
		 }
	 }*/
}
