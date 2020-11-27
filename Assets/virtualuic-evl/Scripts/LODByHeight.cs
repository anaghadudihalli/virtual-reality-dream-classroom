using UnityEngine;
using System.Collections;
[ExecuteInEditMode]
public class LODByHeight : MonoBehaviour {

	public float cameraHeight;

	public float minHeight;
	public float maxHeight;

	public GameObject[] lodObjects;

	// Update is called once per frame
	void Update () {
        if(Camera.main)
		    cameraHeight = Camera.main.transform.position.y;

        foreach (GameObject lodObject in lodObjects)
        {
            if (cameraHeight >= minHeight && cameraHeight <= maxHeight && !lodObject.activeSelf)
            {
                if (GetComponentInParent<LODScript>())
                {
                    if (GetComponentInParent<LODScript>().lodActive)
                        lodObject.SetActive(true);
                }
                else
                {
                    lodObject.SetActive(true);
                }
            }
            else if (cameraHeight >= minHeight && cameraHeight <= maxHeight && lodObject.activeSelf)
            {

            }
            else if (lodObject.activeSelf)
            {
                lodObject.SetActive(false);
            }

            if (GetComponentInParent<LODScript>() && !GetComponentInParent<LODScript>().lodActive)
            {
                lodObject.SetActive(false);
            }
        }
	}
}
