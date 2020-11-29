using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class computerOn : MonoBehaviour
{
    public GameObject cameraRig;
    public GameObject laptop;
    public GameObject screen;
    bool isCameraRigClose;
    bool repeatAgain = true; 
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("checkIfNear", 0f, 4f);
        Debug.Log("In start");
    }

    void checkIfNear()
    {
        Debug.Log("In check if near");
        Debug.Log(Vector3.Distance(laptop.transform.localPosition, cameraRig.transform.localPosition));
        isCameraRigClose = false;
        if (Vector3.Distance(laptop.transform.localPosition, cameraRig.transform.localPosition) <= 0) {
            Debug.Log("Distance is less");
            isCameraRigClose = true;
        }
        if (isCameraRigClose) {
            Debug.Log("True");
            StartCoroutine(turnOnScreen());
        }
    }

    IEnumerator turnOnScreen() {
        screen.SetActive(true);
        yield return new WaitForSeconds(3);
        screen.SetActive(false);
        isCameraRigClose = false;
        // repeatAgain = false;
    }
}
