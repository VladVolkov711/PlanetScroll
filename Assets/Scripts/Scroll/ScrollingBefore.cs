using System.Threading.Tasks;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBefore : MonoBehaviour
{
    public List<GameObject> PlanetList;

    [SerializeField] private GameObject _scrollPlanetPrefab;
    [SerializeField] private int _planetCount = 40;

    [SerializeField] private float _minScalePos;
    [SerializeField] private float _maxScalePos;

    [SerializeField] private ScrollingAfter _scrollingAfter;
    internal GameObject _planetDestroy;

    internal int _id;
    internal int _currentCountInList;

    private void Awake()
    {
        for (int i = 0; i < _planetCount; i++)
        {
            GameObject newPlanet = Instantiate(_scrollPlanetPrefab, transform, false);

            newPlanet.GetComponent<Image>().color =
                                            new Color(Random.value, Random.value, Random.value, 1);

            newPlanet.transform.localScale = new Vector2(200, 200);

            PlanetList.Add(newPlanet);
            PlanetList[i].GetComponent<PlanetID>().Id = i;

            _scrollingAfter.SpawnPlanet(ref newPlanet);
        }
    }

    private void FixedUpdate()
    {
        int i = 0;
        int newid = 0;
        for (; i < _planetCount; i++)
        {
            if (PlanetList[i] != null &&
                    PlanetList[i].transform.position.x > _minScalePos &&
                            PlanetList[i].transform.position.x < _maxScalePos)
            {
                _currentCountInList = i;
                _id = PlanetList[i].GetComponent<PlanetID>().Id;

                PlanetList[i].transform.localScale = Vector2.Lerp(PlanetList[i].transform.localScale,
                    new Vector2(300, 300), 0.1f);

                newid = _id;

                if (newid == _id) _planetDestroy = PlanetList[i];
                else _planetDestroy = null;

            }
            else
            {
                PlanetList[i].transform.localScale = Vector2.Lerp(PlanetList[i].transform.localScale,
                    new Vector2(200, 200), 0.1f);
            }
        }
    }
}
