using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CalculateGravitionalForce : MonoBehaviour
{
    public static CalculateGravitionalForce instance;

    public readonly float G = 100;

    public GameObject planetParent;

    public List<PlanetBase> planet = new List<PlanetBase>();

    private void Awake()
    {
        instance = this;

        for (int i = 0; i < planetParent.transform.childCount; i++)
            planet.Add(planetParent.transform.GetChild(i).GetComponent<PlanetBase>());
    }
    private void Start()
    {
        for (int i = 0; i < planet.Count; i++)
        {
            PlanetBase firstPlanet = planet[i];
            for (int j = 0; j < planet.Count; j++)
            {
                PlanetBase secondPlanet = planet[j];

                if (i == j) { continue; }

                firstPlanet.CalculateSpeedOfPlanet(secondPlanet);
            }
        }
    }
    private void FixedUpdate()
    {
        for (int i = 0; i < planet.Count; i++)
        {
            PlanetBase firstPlanet = planet[i];
            for (int j = 0; j < planet.Count; j++)
            {
                PlanetBase secondPlanet = planet[j];

                if (i == j) { continue; }

                firstPlanet.CalculateTheForce(secondPlanet);
            }
        }
    }
}
