using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LODByTrigger : MonoBehaviour {

    [SerializeField]
    GameObject[] lodObjects;

	void OnTriggerEnter()
    {
        foreach(GameObject g in lodObjects)
        {
            g.SetActive(true);
        }
    }

    void OnTriggerExit()
    {
        foreach (GameObject g in lodObjects)
        {
            g.SetActive(false);
        }
    }
}
