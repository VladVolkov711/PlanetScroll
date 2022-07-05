using System.Collections.Generic;
using UnityEngine;

public class ScrollingAfter : MonoBehaviour
{
    public List<GameObject> PlanetListAfter;

    [SerializeField] private float _minScalePos;
    [SerializeField] private float _maxScalePos;

    public void SpawnPlanet(ref GameObject obj)
    {
        GameObject objPlanet = Instantiate(obj, transform, false);
        objPlanet.transform.localScale = new Vector2(150, 150);
        objPlanet.GetComponent<Switcheble>().IsSwich = true;

        PlanetListAfter.Add(objPlanet);
        objPlanet.SetActive(false);
    }

    private void FixedUpdate()
    {
        int i = 0;
        for (; i < transform.childCount; i++)
        {
            if (PlanetListAfter[i] != null &&
                    PlanetListAfter[i].transform.position.x > _minScalePos &&
                            PlanetListAfter[i].transform.position.x < _maxScalePos)
            {
                PlanetListAfter[i].transform.localScale = Vector2.Lerp(PlanetListAfter[i].transform.localScale,
                    new Vector2(200, 200), 0.1f);

            }
            else
            {
                PlanetListAfter[i].transform.localScale = Vector2.Lerp(PlanetListAfter[i].transform.localScale,
                    new Vector2(150, 150), 0.1f);
            }
        }
    }
}
