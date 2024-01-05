using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Assets.Scripts.UI
{
    public class ButtonSelectable : MonoBehaviour, ISelectHandler, IDeselectHandler, IPointerEnterHandler, IPointerExitHandler
    {

        public void OnSelect(BaseEventData eventData)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle |= FontStyles.Underline;
        }

        public void OnDeselect(BaseEventData eventData)
        {
            gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle ^= FontStyles.Underline;
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
            //gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle |= FontStyles.Underline;
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            //gameObject.GetComponentInChildren<TextMeshProUGUI>().fontStyle ^= FontStyles.Underline;
        }
    }
}