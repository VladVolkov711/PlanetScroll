using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScrollingBefore : MonoBehaviour
{
    public List<GameObject> PlanetList;

    [SerializeField] private GameObject _scrollPlanetPrefab;
    [SerializeField] private int _planetCount = 40;

    //[SerializeField] private float _minScalePos;
    //[SerializeField] private float _maxScalePos;

    [SerializeField] private ScrollingAfter _scrollingAfter;
    [SerializeField] internal GameObject _planetDestroy;

    internal int _id;
    internal int _currentCountInList;

    public GameObject scrollbar;
    private float scroll_pos = 0;
    public List<float> pos;

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
            pos.Add(i);
        }
    }

    private void Update()
    {
        float distance = 1f / (pos.Count - 1f);
        for (int j = 0; j < pos.Count; j++) pos[j] = distance * j;

        if (Input.GetMouseButton(0)) scroll_pos = scrollbar.GetComponent<Scrollbar>().value;
        else
        {
            for (int i = 0; i < pos.Count; i++)
            {
                if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
                {
                    _planetDestroy = transform.GetChild(i).gameObject;
                    scrollbar.GetComponent<Scrollbar>().value = Mathf.Lerp(scrollbar.GetComponent<Scrollbar>().value, pos[i], 0.1f);
                }
            }
        }

        for (int i = 0; i < pos.Count; i++)
        {
            if (scroll_pos < pos[i] + (distance / 2) && scroll_pos > pos[i] - (distance / 2))
            {
                _planetDestroy = transform.GetChild(i).gameObject;
                transform.GetChild(i).localScale =
                    Vector2.Lerp(transform.GetChild(i).localScale, new Vector2(300f, 300f), 0.1f);

                for (int j = 0; j < pos.Count; j++)
                {
                    if (j != i)
                    {
                        transform.GetChild(j).localScale =
                            Vector2.Lerp(transform.GetChild(j).localScale, new Vector2(200f, 200f), 0.1f);
                    }
                }
            }
        }

    }
}
