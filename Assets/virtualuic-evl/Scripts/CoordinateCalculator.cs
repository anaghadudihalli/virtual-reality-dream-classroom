using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class CoordinateCalculator : MonoBehaviour {

    [SerializeField]
    Transform wand;

    [SerializeField]
    Vector3 wandPosition;

    [SerializeField]
    Vector3 wandEuler;

    [SerializeField]
    bool showDegrees = false;

    [SerializeField]
    Quaternion wandRot;

    [SerializeField]
    Transform screenOriginTransform;

    [SerializeField]
    Vector3 screenOrigin;

    [SerializeField]
    Transform screenMarker;

    [SerializeField]
    float distToScreen;

    [SerializeField]
    Vector3 screenMarkerPos;

    [SerializeField]
    Vector2 wallDim = new Vector2(7.305f, 2.058f);

    [SerializeField]
    Vector2 wallRotationRelTOrigin;

    [SerializeField]
    Vector3 normalizedPosition;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        wandPosition = wand.localPosition;
        if(showDegrees)
            wandEuler = wand.localEulerAngles;
        else
            wandEuler = wand.localEulerAngles * Mathf.Deg2Rad;
        wandRot = wand.localRotation;
        screenOrigin = screenOriginTransform.localPosition;


        // Easy step 1: Convert from tracker space to screen space
        Vector3 newWandPosition = Vector3.zero;

        newWandPosition.x = -(screenOrigin.x + -wandPosition.x);
        newWandPosition.y = screenOrigin.y + -wandPosition.y;


        wandEuler.y += wallRotationRelTOrigin.y;
        wandEuler.x += wallRotationRelTOrigin.x;

        // Apply wand rotation
        distToScreen = wandPosition.z + -screenOrigin.z;
        if(wallRotationRelTOrigin.y != 0)
            distToScreen = wandPosition.x + -screenOrigin.x;
        newWandPosition.x += -distToScreen * Mathf.Tan(wandEuler.y * (showDegrees ? Mathf.Deg2Rad : 1));

        float angularDistanceToScreen = distToScreen / Mathf.Cos(wandEuler.y);
        newWandPosition.y += -angularDistanceToScreen * Mathf.Tan(wandEuler.x * (showDegrees ? Mathf.Deg2Rad : 1));

        normalizedPosition = newWandPosition;
        normalizedPosition.x /= wallDim.x;
        normalizedPosition.y /= wallDim.y;

        if (normalizedPosition.x < 0)
        {
            newWandPosition.x = 0;
        }
        else if (normalizedPosition.x > 1)
        {
            newWandPosition.x = wallDim.x;
        }

        if (normalizedPosition.y < 0)
        {
            newWandPosition.y = 0;
        }
        else if (normalizedPosition.y > 1)
        {
            newWandPosition.y = wallDim.y;
        }

        screenMarker.localPosition = newWandPosition;
        screenMarkerPos = screenMarker.localPosition;
        Debug.DrawRay(wand.position, wand.forward * 10);
    }
}
