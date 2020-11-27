using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class LODScript : MonoBehaviour {
    public bool lodByDistance = false;
    public float cameraDistance;

	public GameObject[] LODObjects;
	public bool alwaysShow = false;
	public float minimumDistance = 50;

    public bool lodActive;

	// Update is called once per frame
	void Update () {

        if (lodByDistance)
        {
            cameraDistance = Vector3.Distance(transform.position, Camera.main.transform.position);

            if ((alwaysShow || cameraDistance <= minimumDistance) && !LODObjects[0].activeSelf)
            {
                foreach (GameObject g in LODObjects)
                {
                    g.SetActive(true);
                }
                lodActive = true;
            }
            else if (cameraDistance > minimumDistance && LODObjects[0].activeSelf)
            {
                foreach (GameObject g in LODObjects)
                {
                    g.SetActive(false);
                }
                lodActive = false;
            }
        }
	}
}
