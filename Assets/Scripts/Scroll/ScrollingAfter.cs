using System.Collections.Generic;
using UnityEngine;

public class ScrollingAfter : MonoBehaviour
{
    public List<GameObject> PlanetListAfter;

    public void SpawnPlanet(ref GameObject obj)
    {
        GameObject objPlanet = Instantiate(obj, transform, false);
        objPlanet.GetComponent<Renderer>().material.color = obj.GetComponent<Renderer>().material.color;
        objPlanet.transform.localScale = new Vector2(150, 150);
        PlanetListAfter.Add(objPlanet);
    }
}
