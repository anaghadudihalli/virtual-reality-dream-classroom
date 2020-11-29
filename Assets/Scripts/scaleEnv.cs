using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scaleEnv : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject classroom;
    public float x_small = 0.1f;
    public float y_small = 0.1f;
    public float z_small = 0.1f;
    public float x_pos_small = 0.1f;
    public float y_pos_small = 0.1f;
    public float z_pos_small = 0.1f;
    public float x_normal = 1f;
    public float y_normal = 1f;
    public float z_normal = 1f;
    public float x_pos_normal = 1f;
    public float y_pos_normal = 1f;
    public float z_pos_normal = 1f;
    bool isSmall = false;

    void Start()
    {
        Debug.Log("In Start");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Key Press");
        if (Input.GetKeyDown(KeyCode.E)) {
            Debug.Log("E");
            if (!isSmall)  {
                classroom.transform.localScale = new Vector3(x_small, y_small, z_small);
                classroom.transform.localPosition = new Vector3(x_pos_small, y_pos_small, z_pos_small);
                isSmall = true;
            }
        }
        else if (Input.GetKeyDown(KeyCode.R)){
            Debug.Log("R");
            if (isSmall) {
                classroom.transform.localScale = new Vector3(x_normal, y_normal, z_normal);
                classroom.transform.localPosition = new Vector3(x_pos_normal, y_pos_normal, z_pos_normal);
                isSmall = false;
            }
        }
    }
}
