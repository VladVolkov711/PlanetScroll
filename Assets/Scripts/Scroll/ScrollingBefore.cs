using System.Collections.Generic;
using UnityEngine;

public class ScrollingBefore : MonoBehaviour
{
    public List<GameObject> PlanetList;

    [SerializeField] private GameObject _scrollPlanetPrefab;
    [SerializeField] private int _planetCount = 40;

    [SerializeField] private int _minScalePos;
    [SerializeField] private int _maxScalePos;
    private bool _isScroll;

    [SerializeField] internal GameObject _planetDestroy;

    internal int _id;
    internal int _currentCountInList;

    private void Awake()
    {
        for (int i = 0; i < _planetCount; i++)
        {
            GameObject newPlanet = Instantiate(_scrollPlanetPrefab, transform, false);
            newPlanet.GetComponent<Renderer>().material.color = new Color(Random.value, Random.value, Random.value, 1);
            newPlanet.transform.localScale = new Vector2(200, 200);
            PlanetList.Add(newPlanet);
            PlanetList[i].GetComponent<PlanetID>().Id = i;
        }
    }

    private void FixedUpdate()
    {
        int i = 0;
        int newid = 0;
        for (; i < _planetCount; i++)
        {
            if (PlanetList[i].transform.position.x > _minScalePos && PlanetList[i].transform.position.x < _maxScalePos)
            {
                _currentCountInList = i;
                _id = PlanetList[i].GetComponent<PlanetID>().Id;
                Debug.Log(PlanetList[i].GetComponent<PlanetID>().Id);

                newid = _id;

                if(newid == _id) _planetDestroy = PlanetList[i];
                else _planetDestroy = null;

            }
            else
            {
                
            }
        }
    }

    public void isScroll(bool isscroll)
    {
        _isScroll = isscroll;
    }
}
