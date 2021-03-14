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
            }
        }
    }
}
