using System.Collections.Generic;
using UnityEngine;

public class ScrollingAfter : MonoBehaviour
{
    public List<GameObject> PlanetListAfter;

    public void SpawnPlanet(ref GameObject obj)
    {
        GameObject objPlanet = Instantiate(obj, transform, false);
        objPlanet.transform.localScale = new Vector2(150, 150);
        objPlanet.GetComponent<Switcheble>().IsSwich = true;

        PlanetListAfter.Add(objPlanet);
        objPlanet.SetActive(false);
    }
}
