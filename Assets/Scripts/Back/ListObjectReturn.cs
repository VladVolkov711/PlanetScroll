using System.Collections.Generic;
using UnityEngine;

public class ListObjectReturn : MonoBehaviour
{
    [SerializeField] private GameObject ButtonBack;
    public List<GameObject> ListForReturn;

    private void Update() => ButtonBack.SetActive(ListForReturn.Count > 0);
}
