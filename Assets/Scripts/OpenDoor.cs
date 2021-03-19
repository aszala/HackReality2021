using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{

    private bool opened = false;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other) {
        if (!opened) {
            if (other.name.Contains("Hand")) {
                this.transform.Rotate(new Vector3(0, -90, 0));
                opened = true;

                if (transform.name.Equals("door_1") && GameObject.Find("RNA Sample") == null) {
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayClip(1);
                    GameObject.Find("Target").transform.position = new Vector3(-15.4125f, 1.189f, 13.1088f);
                }
            }
        }
    }
}
