using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ChangeTargetPlanet : MonoBehaviour
{
    [SerializeField] private TMP_Text currentPlanetText;

    [SerializeField] private GameObject rightButton;
    [SerializeField] private GameObject leftButton;

    private int index = 0;

    private void Awake()
    {
        ChangeText();
    }
    public void Right()
    {
        if (index >= CalculateGravitionalForce.instance.planet.Count - 1) return;

        leftButton.SetActive(true);
        rightButton.SetActive(true);

        index++;

        if (index >= CalculateGravitionalForce.instance.planet.Count - 1)
            rightButton.SetActive(false);
        else 
            rightButton.SetActive(true);

        ChangeText();
    }

    public void Left()
    {
        if (index <= 0) return;

        leftButton.SetActive(true);
        rightButton.SetActive(true);

        index--;

        if (index <= 0)
            leftButton.SetActive(false);
        else
            leftButton.SetActive(true);

        ChangeText();
    }

    private void ChangeText()
    {
        currentPlanetText.SetText(((Planets)index).ToString());

        CameraFocusManager.instance.ChangeCameraFocus((Planets)index);
    }
}
