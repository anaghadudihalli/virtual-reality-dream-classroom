using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SensorGUI : MonoBehaviour {

    [SerializeField]
    bool showDetail;

    [SerializeField]
    GameObject detailPanel;

    [SerializeField]
    GameObject icon;

    public Text nameText;

    public Text descriptionText;

    public Text lastChangeText;

    public Button doorStateButton;

    public Button overrideButton;

    public Button iconButton;

    public InputField inputField;

    public Text unitsText;

    private void Start()
    {
        detailPanel.SetActive(false);
        icon.SetActive(true);
    }

    public void ToggleDetailGUI()
    {
        if(icon.activeSelf)
        {
            detailPanel.SetActive(true);
            icon.SetActive(false);
        }
        else
        {
            detailPanel.SetActive(false);
            icon.SetActive(true);
        }
    }
}
