using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class SceneFOVLineRenderer : MonoBehaviour {
    [SerializeField]
    bool showSphereLine = true;

    [SerializeField]
    bool showCameraLine = true;

    [SerializeField]
    float maxDistance = 6.1f;

    [SerializeField]
    float effectiveDistance = 4.3f;

    [SerializeField]
    float dist = 6.1f;

    [SerializeField]
    GameObject[] markers;

    [SerializeField]
    Vector3 screenPos;

	// Use this for initialization
	void Start () {
	
	}

    // Update is called once per frame
    void Update()
    {
        if (showSphereLine)
        {
            foreach (GameObject marker in markers)
            {
                if (marker.activeSelf)
                {
                    Color lineColor = Color.green;
                    screenPos = GetComponent<Camera>().WorldToViewportPoint(marker.transform.position);
                    dist = Vector3.Distance(transform.position, marker.transform.position);

                    if (screenPos.x < 0 || screenPos.x > 1 || screenPos.y < 0 || screenPos.y > 1)
                    {
                        lineColor = Color.grey;
                    }
                    else
                    {
                        if (dist > effectiveDistance)
                            lineColor = Color.yellow;

                        if (dist <= maxDistance)
                            Debug.DrawLine(transform.position, marker.transform.position, lineColor);
                    }
                }
            }
        }

        if (showCameraLine)
        {
            Debug.DrawLine(transform.position, transform.position + transform.forward * 0.5f, Color.cyan);
            //Debug.DrawLine(transform.position, transform.position + transform.up * 0.5f, Color.green);
        }

    }
}
