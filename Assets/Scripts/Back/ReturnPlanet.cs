using UnityEngine;

public class ReturnPlanet : MonoBehaviour
{
    [SerializeField] private ScrollingBefore _scrollingBefore;
    [SerializeField] private ScrollingAfter _scrollingAfter;
    [SerializeField] private ListObjectReturn _listObjectReturn;

    private int i = 0;
    private int id = 0;

    public void Return()
    {
        i = 0;
        id = 0;

        while (i < _listObjectReturn.ListForReturn.Count) i++;

        if (_listObjectReturn.ListForReturn[i - 1].GetComponent<Switcheble>().IsSwich == true)
        {
            id = _listObjectReturn.ListForReturn[i - 1].GetComponent<PlanetID>().Id;
            _scrollingAfter.PlanetListAfter[id].SetActive(false);
            _scrollingBefore.PlanetList[id].SetActive(true);
            _listObjectReturn.ListForReturn.RemoveAt(i - 1);
        }

        else
        {
            id = _listObjectReturn.ListForReturn[i - 1].GetComponent<PlanetID>().Id;
            _scrollingBefore.PlanetList[id].SetActive(true);
            _listObjectReturn.ListForReturn.RemoveAt(i - 1);
        }
    }
}
