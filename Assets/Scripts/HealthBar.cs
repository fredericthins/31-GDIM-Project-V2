using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Vector3 offset;
    [SerializeField] Image hpBar;
    [SerializeField] Transform target;
    Color lowColor = Color.red;
    Color highColor = Color.green;
    public void SetHealth(float health, float maxHealth){
        slider.gameObject.SetActive(health <= maxHealth);
        slider.maxValue = maxHealth;
        slider.value = health;

        hpBar.color = Color.Lerp(lowColor, highColor,slider.normalizedValue);
    }
    
    // Update is called once per frame
    void Update()
    {
        slider.transform.position = Camera.main.WorldToScreenPoint(target.position + offset);
    }
}
