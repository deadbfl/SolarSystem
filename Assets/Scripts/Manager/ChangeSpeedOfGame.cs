using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChangeSpeedOfGame : MonoBehaviour
{
    [SerializeField] private Slider speedSlider;

    [Range(0, 100)]
    [SerializeField] private int maxSpeed;

    [SerializeField] private TMP_Text speedText;

    private void Awake()
    {
        speedSlider.onValueChanged.AddListener(delegate { SliderValueChange(); });
    }
    private void Start()
    {
        speedSlider.value = 1.1f / maxSpeed;
    }

    private void SliderValueChange()
    {
        int speed = (int)(speedSlider.value * maxSpeed);

        Time.timeScale = speed;

        speedText.SetText("Speed : " + speed);
    }
}
