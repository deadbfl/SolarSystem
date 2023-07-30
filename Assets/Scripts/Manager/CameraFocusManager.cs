using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFocusManager : MonoBehaviour
{
    public static CameraFocusManager instance;

    [SerializeField] private Vector3[] cameraDistances;

    private Vector3 currentCameraDistance;

    private Transform target;

    private Dictionary<Planets, Transform> planets = new Dictionary<Planets, Transform>();

    private Planets targetPlanets;
    private void Awake()
    {
        instance = this;

        SavePlantsToDictionary();
    }

    public void ChangeCameraFocus(Planets targetPlanet)
    {
        target = planets[targetPlanet];

        targetPlanets = targetPlanet;

    }

    private void FixedUpdate()
    {
        transform.position = target.position + cameraDistances[(int)targetPlanets];
    }

    private void SavePlantsToDictionary()
    {
        int planetCount = CalculateGravitionalForce.instance.planet.Count;

        Planets type;
        Transform targetTransform;

        for(int i = 0;i<planetCount;i++)
        {
            type = CalculateGravitionalForce.instance.planet[i].currentPlanetType;
            targetTransform = CalculateGravitionalForce.instance.planet[i].transform;

            planets.Add(type, targetTransform);
        }
    }
}
