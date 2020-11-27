using UnityEngine;
using System.Collections;

[ExecuteInEditMode]
public class AngleHelper : MonoBehaviour {
    [SerializeField]
    Vector2 position;

    [SerializeField]
    float angle;
	
	// Update is called once per frame
	void Update () {
        angle = Mathf.Atan2(position.x, position.y) * Mathf.Rad2Deg;
	}
}
