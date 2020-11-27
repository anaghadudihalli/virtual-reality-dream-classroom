using UnityEngine;
using System.Collections;

public class LightSwitchToggle : MonoBehaviour {

    Light[] lights;
    public Material mat;
    public int matIndex;

	// Use this for initialization
	void Start () {
        lights = GetComponentsInChildren<Light>();
        Renderer renderer = GetComponent<Renderer>();
        if (renderer)
        {
            mat = renderer.materials[matIndex];
            mat.EnableKeyword("_EMISSION");
        }
    }
	
	// Update is called once per frame
	void Update () {

    }

    public void ToggleLights()
    {
        foreach (Light l in lights)
        {
            l.enabled = !l.enabled;

            if (mat && l.enabled)
            {
                mat.SetColor("_EmissionColor", Color.white * Mathf.LinearToGammaSpace(1));
                mat.SetColor("_Color", Color.blue);
                DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.blue);
            }
            else if (mat)
            {
                mat.SetColor("_Color", Color.black);
                mat.SetColor("_EmissionColor", Color.black * Mathf.LinearToGammaSpace(0));
                DynamicGI.SetEmissive(GetComponent<Renderer>(), Color.black);
            }
        }
    }

    public void ToggleShadows()
    {
        foreach (Light l in lights)
        {
            if (l.shadows == LightShadows.None)
                l.shadows = LightShadows.Hard;
            else if (l.shadows == LightShadows.Hard)
                l.shadows = LightShadows.Soft;
            else
                l.shadows = LightShadows.None;
        }
    }
}
