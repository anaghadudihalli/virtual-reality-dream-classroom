using UnityEngine;
using System.Collections;

public class ThirdPersonCameraScript : MonoBehaviour
{
    [SerializeField]
    public Transform cameraController;

    public float cameraYaw = Mathf.PI / 2.0f;
    public float cameraPitch = 0;

    public float cameraDistance = -2;
    public float verticalOffset = 0.5f; // camera height

    public float sensitivityX = -0.1f;
    public float sensitivityY = 0.1f;
    public float zoomSensitivity = 1.0f;

    public bool aimMode = false;
    public bool enableRotation = true;

    GameObject focusObject;
    public float focusInterpolationTime = 1.0f;
    public float focusInterpolationTimer = 0.0f;

    [SerializeField]
    Transform newFocusObject;

    [SerializeField]
    Transform lastFocusObject;

    public enum RotateMode { MouseHold, KeyHold, KeyToggle };

    public RotateMode rotateMode = RotateMode.MouseHold;
    int mouseButton = 0;

    Vector3 lastMousePos;
    Vector3 lastMousePos_translateLRUD; //Left, Right, Up, Down
    Vector3 lastMousePos_translateFB; //Forward, Back

    [SerializeField]
    bool middleMouseButtonTranslateLRUD;

    [SerializeField]
    bool rightMouseButtonTranslateFB;

    bool translateEnabled;
    bool translateFBEnabled;

    float translateLR;
    float translateFB;

    // [SerializeField]
    // ColorPickerTriangle colorPicker;

    // Use this for initialization
    void Start()
    {
        if (!cameraController)
            cameraController = Camera.main.transform;

        cameraController.transform.rotation = Quaternion.identity;
        focusObject = new GameObject("Camera Focus");

        lastFocusObject = transform;
        if (newFocusObject == null)
        {
            newFocusObject = transform;
        }

        focusObject.transform.parent = newFocusObject;
        focusObject.transform.position = newFocusObject.position;
    }

    // Update is called once per frame
    void Update()
    {
        // if(colorPicker.IsMousePressed())
        // {
        // return;
        // }

        switch (rotateMode)
        {
            case (RotateMode.MouseHold):
                if (!enableRotation)
                    lastMousePos = Input.mousePosition;
                enableRotation = Input.GetMouseButton(mouseButton);
                break;
            case (RotateMode.KeyHold):
                if (!enableRotation)
                    lastMousePos = Input.mousePosition;
                // Google Earth style rotate
                enableRotation = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.LeftControl);
                break;
            case (RotateMode.KeyToggle):
                // SWG Style
                if (Input.GetKeyDown(KeyCode.LeftAlt))
                {
                    enableRotation = !enableRotation;
                }
                break;
        }

        if (newFocusObject != lastFocusObject && focusInterpolationTimer < 1)
        {
            focusObject.transform.position = Vector3.Lerp(lastFocusObject.position, newFocusObject.position, focusInterpolationTimer);
            focusInterpolationTimer += Time.deltaTime * focusInterpolationTime;
        }
        else if (newFocusObject != lastFocusObject && focusInterpolationTimer >= 1)
        {
            lastFocusObject = newFocusObject;
            focusObject.transform.parent = newFocusObject;
            focusInterpolationTimer = 0;
        }
        else
        {
            focusObject.transform.position = newFocusObject.position;
        }

        // Rotate the camera based on input
        if (enableRotation)
        {
            //cameraYaw += Input.GetAxis("Mouse X") * sensitivityX;
            //cameraPitch += Input.GetAxis("Mouse Y") * sensitivityY;

            cameraYaw += (Input.mousePosition.x - lastMousePos.x) * 0.1f * sensitivityX;
            cameraPitch += (Input.mousePosition.y - lastMousePos.y) * 0.1f * sensitivityY;
            lastMousePos = Input.mousePosition;
        }
        if (cameraDistance + Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity < 0)
            cameraDistance += Input.GetAxis("Mouse ScrollWheel") * zoomSensitivity;

        // Clamp rotation
        if (cameraYaw > 2 * Mathf.PI)
            cameraYaw -= 2 * Mathf.PI;
        if (cameraYaw < 0)
            cameraYaw += 2 * Mathf.PI;

        if (cameraPitch > Mathf.PI / 2.5f)
            cameraPitch = Mathf.PI / 2.5f;
        if (cameraPitch < -Mathf.PI / 2.5f)
            cameraPitch = -Mathf.PI / 2.5f;

        if(middleMouseButtonTranslateLRUD)
        {
            // Prevent large jumps if button was pressed offscreen
            if(Input.GetMouseButton(2) && !translateEnabled)
                lastMousePos_translateLRUD = Input.mousePosition;

            translateEnabled = Input.GetMouseButton(2);
            if (translateEnabled)
            {
                verticalOffset -= (Input.mousePosition.y - lastMousePos_translateLRUD.y) * 0.1f * sensitivityY;
                translateLR -= (Input.mousePosition.x - lastMousePos_translateLRUD.x) * 0.1f * sensitivityX;
            }
            lastMousePos_translateLRUD = Input.mousePosition;
        }

        if (rightMouseButtonTranslateFB)
        {
            // Prevent large jumps if button was pressed offscreen
            if (Input.GetMouseButton(1) && !translateFBEnabled)
                lastMousePos_translateFB = Input.mousePosition;

            translateFBEnabled = Input.GetMouseButton(1);
            if (translateFBEnabled)
            {
                translateFB -= (Input.mousePosition.y - lastMousePos_translateFB.y) * 0.1f * sensitivityY;
            }
            lastMousePos_translateFB = Input.mousePosition;
        }

        // Spherical to cartesian coordinate conversion
        float x = cameraDistance * Mathf.Cos(cameraYaw) * Mathf.Cos(cameraPitch);
        float z = cameraDistance * Mathf.Sin(cameraYaw) * Mathf.Cos(cameraPitch);
        float y = cameraDistance * Mathf.Sin(cameraPitch);

        newFocusObject.transform.position = newFocusObject.transform.position + transform.localRotation * new Vector3(-translateLR, 0, -translateFB);
        cameraController.transform.position = focusObject.transform.position + new Vector3(x, y + verticalOffset, z);
        translateLR = 0;
        translateFB = 0;

        // Look at the character
        cameraController.transform.LookAt(focusObject.transform.position + new Vector3(0, verticalOffset, 0));
    }

    public void SetFocusObject(Transform newObject)
    {
        if (focusInterpolationTimer == 0)
        {
            newFocusObject = newObject;
        }
    }
}
