using UnityEngine;

public class DeleteItems : MonoBehaviour
{
    [SerializeField] private ScrollingBefore _scrollingBefore;
    [SerializeField] private ListObjectReturn _listObjectReturn;

    public void DeleteItemInList()
    {
        _listObjectReturn.ListForReturn.Add(_scrollingBefore._planetDestroy);
        _scrollingBefore._planetDestroy.SetActive(false);
    }
}
