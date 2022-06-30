using UnityEngine;

public class SwichItem : MonoBehaviour
{
    [SerializeField] ScrollingBefore _scrollingBefore;
    [SerializeField] ScrollingAfter _scrollingAfter;

    public void SwichElementInList()
    {
        _scrollingAfter.SpawnPlanet(ref _scrollingBefore._planetDestroy);

        Destroy(_scrollingBefore._planetDestroy, 0.5f);
        _scrollingBefore.PlanetList.RemoveAt(_scrollingBefore._currentCountInList);
    }
}
