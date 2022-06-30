using UnityEngine;

public class DeleteItems : MonoBehaviour
{
    [SerializeField] ScrollingBefore _scrollingBefore;

    public void DeleteItemInList()
    {
        Destroy(_scrollingBefore._planetDestroy);
        _scrollingBefore.PlanetList.RemoveAt(_scrollingBefore._currentCountInList);
    }
}
