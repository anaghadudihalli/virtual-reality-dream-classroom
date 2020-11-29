using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class s2Talk : MonoBehaviour
{
    public GameObject cameraRig;
    public GameObject humanoid;
    public Animator animator;
    public AudioSource talkingClip;
    bool isCameraRigClose;
    bool repeatAgain = true; 
    // Start is called before the first frame update
    void Start()
    {
        animator.GetComponent<Animator>();   
        talkingClip.GetComponent<AudioSource>();
        InvokeRepeating("checkIfNear", 0f, 4f);
        // Debug.Log("In start");
    }

    void checkIfNear()
    {
        // Debug.Log("In check if near");
        Debug.Log(Vector3.Distance(humanoid.transform.localPosition, cameraRig.transform.localPosition)+"s2");
        // Debug.Log("s2");
        isCameraRigClose = false;
        if (Vector3.Distance(humanoid.transform.localPosition, cameraRig.transform.localPosition) <= 3.5) {
            // Debug.Log("Distance is less");
            isCameraRigClose = true;
        }
        else {
            repeatAgain = true;
        }
        if (isCameraRigClose && repeatAgain) {
            // Debug.Log("True");
            StartCoroutine(startTalking());
        }
    }

    IEnumerator startTalking() {
        animator.SetBool("isTalking", true);
        talkingClip.Play();
        yield return new WaitForSeconds(talkingClip.clip.length);
        animator.SetBool("isTalking", false);
        isCameraRigClose = false;
        repeatAgain = false;
    }
}
