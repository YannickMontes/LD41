using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RossNeverTiltTheHead : MonoBehaviour {

    private Quaternion rosstation;

    void Awake()
    {
        rosstation = this.transform.rotation;
    }

	void Update () {
        this.transform.rotation = rosstation;
	}

}
