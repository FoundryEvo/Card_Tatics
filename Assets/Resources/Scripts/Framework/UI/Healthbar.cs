using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image hpBG; // 血条 UI
    public Image hpFill; // 血条的填充部分
    public float maxHealth;
    public float minHealth = 0;
    public float currentHealth;
    public void SetMaxHealth(float maxHealth)
    {
        hpFill.fillAmount = maxHealth;
    }
    public void SetHealth(float health)
    {
        hpFill.fillAmount = health / maxHealth; // 按比例减少血条
    }    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        hpBG = transform.GetComponent<Image>();
        hpFill = transform.Find("hpFill").GetComponent<Image>();
        currentHealth = maxHealth;
        this.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        SetHealth(currentHealth);
    }
}
