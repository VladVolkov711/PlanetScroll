using UnityEngine;
using UnityEngine.UI;

public class VisibleId : MonoBehaviour
{
    [SerializeField] private PlanetID _id;
    [SerializeField] private Text _idText;

    private void Start() => _idText.text = "id = " + _id.Id.ToString();
}
