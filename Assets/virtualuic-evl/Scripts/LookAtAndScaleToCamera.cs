using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtAndScaleToCamera : MonoBehaviour {

    [SerializeField]
    float referenceDistance = 1;

	// Update is called once per frame
	void LateUpdate () {

        transform.localScale = Vector3.one * (Vector3.Distance(transform.position, Camera.main.transform.position) / referenceDistance);
        transform.LookAt(transform.position + Camera.main.transform.rotation * Vector3.forward,
            Camera.main.transform.rotation * Vector3.up);
    }
}
