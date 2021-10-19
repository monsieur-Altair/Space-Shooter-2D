using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlanetController : MonoBehaviour
{
    public GameObject[] planetsArray;
    private Queue<GameObject> availablePlanets = new Queue<GameObject>();
    void Start()
    {
        //for (int i = 0; i < planetsArray.Length; i++)
        //    availablePlanets.Enqueue(planetsArray[i]);
        availablePlanets.Enqueue(planetsArray[0]);
        availablePlanets.Enqueue(planetsArray[1]);
        availablePlanets.Enqueue(planetsArray[2]);
        InvokeRepeating("StartMovePlanetDown", 0f, 30f);
    }
    void StartMovePlanetDown()
    {
        EnqueuePlanet();
        if (availablePlanets.Count == 0)
            return;
        GameObject currentPLanet = availablePlanets.Dequeue();
        currentPLanet.GetComponent<Planet>().isMove = true;
    }
    void EnqueuePlanet()
    {
        foreach(GameObject planet in planetsArray)
        {
            if (/*planet.transform.position.y < 0 ||*/ !planet.GetComponent<Planet>().isMove)
                planet.GetComponent<Planet>().ResetPosition();
            availablePlanets.Enqueue(planet);
        }
    }
}
