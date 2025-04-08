using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SliderController : MonoBehaviour
{
    [SerializeField] private GameObject liquid;
    [SerializeField] private GameObject slider;

    [SerializeField] private float targetLiquidHeight = 135f;
    [SerializeField] private float startLiquidHeight = 0f;

    [SerializeField] private float targetSliderHeight = 327f;
    [SerializeField] private float startSliderHeight = 121f;

    float baseData;


    private void Start(){
        baseData = GameLogic.Instance.TargetHeightGame - GameLogic.Instance.waterLevel.transform.position.y;
    }

    private void Update() {
        
        float parameter = (
            GameLogic.Instance.TargetHeightGame - GameLogic.Instance.waterLevel.transform.position.y ) / baseData;
        
        parameter = (parameter *-1) +1;
 
        liquid.GetComponent<RectTransform>().sizeDelta = new Vector2(
            liquid.GetComponent<RectTransform>().rect.width,
            Mathf.Lerp(startLiquidHeight, targetLiquidHeight, parameter)
        );

        slider.GetComponent<RectTransform>().anchoredPosition = new Vector2(
            slider.GetComponent<RectTransform>().anchoredPosition.x,
            Mathf.Lerp(startSliderHeight, targetSliderHeight, parameter)
        );
    }
}
