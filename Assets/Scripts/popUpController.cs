using Unity.VisualScripting;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class popUpController : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private GameObject _popUp;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (_popUp != null)
        {
            _popUp.SetActive(true);
            Destroy(this.gameObject);
        }
    }
}

