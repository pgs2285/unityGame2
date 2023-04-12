using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class OnMouseEnter : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IDragHandler
{
    public GameObject panel; // 이동할 UI 패널
    public float offset = 10f; // 마우스 위치에서 패널 위치까지의 간격

    private RectTransform panelRectTransform;

    private void Awake()
    {
        
    }


    public void OnPointerEnter(PointerEventData eventData){
        
        string text = gameObject.GetComponentInChildren<TextMesh>().text.ToString();
        
        panel.SetActive(true);

        //panelRectTransform = panel.GetComponent<RectTransform>(); // panel 에서 RectTransform 컴포넌트를 가져옴
        panel.transform.position = eventData.position + new Vector2(offset, 0);
        
        panel.GetComponentInChildren<TextMeshProUGUI>().text = text;
        Debug.Log(text);
    }

    public void OnPointerExit(PointerEventData eventData){
        panel.SetActive(false);
    }
    public void OnDrag(PointerEventData eventData)
    {
        panel.transform.position = Input.mousePosition + new Vector3(offset, 0);
    }
}

