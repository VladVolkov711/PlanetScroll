using UnityEngine;

public class SwichItem : MonoBehaviour
{
    [SerializeField] private ScrollingBefore _scrollingBefore;
    [SerializeField] private ScrollingAfter _scrollingAfter;
    [SerializeField] private ListObjectReturn _listObjectReturn;

    public void SwichElementInList()
    {
        Transform obj = 
            _scrollingAfter.transform.GetChild(_scrollingBefore._planetDestroy.GetComponent<PlanetID>().Id);

        _listObjectReturn.ListForReturn. Add(obj.gameObject);
        _scrollingBefore._planetDestroy.SetActive(false);

        _scrollingAfter.transform.
            GetChild(_scrollingBefore._planetDestroy.GetComponent<PlanetID>().Id).gameObject.SetActive(true);
    }
}
