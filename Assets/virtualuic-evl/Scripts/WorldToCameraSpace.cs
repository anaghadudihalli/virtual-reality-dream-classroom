using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldToCameraSpace : MonoBehaviour {

    public Transform worldPosition;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(worldPosition)
            transform.position = Camera.main.WorldToScreenPoint(worldPosition.position);
    }
}
