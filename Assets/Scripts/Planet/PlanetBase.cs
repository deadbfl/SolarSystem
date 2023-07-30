using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetBase : MonoBehaviour
{
    public Planets currentPlanetType;

    public Texture texture;

    public float massOfPlanet;
    public float diameter;
    public float distanceFromSun;
    public float rotationPeriod;
    [SerializeField] private bool clockWise = true;


    private Rigidbody rb;

    private Renderer m_Renderer;

    private float rotationSpeed = 720;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        m_Renderer = GetComponent<Renderer>();

        rb.mass = massOfPlanet;

        transform.localScale = Vector3.one * diameter;

        transform.position = new Vector3(0, 0, distanceFromSun);

        m_Renderer.material.SetTexture("_MainTex", texture);

        rotationPeriod /= 24;

        rotationSpeed /= rotationPeriod;

        if (!clockWise) rotationSpeed = -rotationSpeed;
    }

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.up);
    }

    public void CalculateTheForce(PlanetBase m_otherPlanet) // m kutle
    {
        float mass1 = massOfPlanet;
        float mass2 = m_otherPlanet.massOfPlanet;

        float distance = Vector3.Distance(this.transform.position, m_otherPlanet.transform.position);

        float force = (CalculateGravitionalForce.instance.G * mass1 * mass2) / (distance * distance);

        Vector3 forceVector = m_otherPlanet.transform.position - this.transform.position;

        rb.AddForce(forceVector.normalized * force);
    }

    public void CalculateSpeedOfPlanet(PlanetBase m_otherPlanet)
    {
        float distance = Vector3.Distance(this.transform.position, m_otherPlanet.transform.position);

        transform.LookAt(m_otherPlanet.transform);

        rb.velocity += transform.right * Mathf.Sqrt(CalculateGravitionalForce.instance.G * m_otherPlanet.massOfPlanet * 4 / (3 * distance));
    }
}
