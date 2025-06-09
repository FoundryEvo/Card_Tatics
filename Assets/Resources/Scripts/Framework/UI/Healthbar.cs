using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Healthbar : MonoBehaviour
{
    public Image hpBG; // Ѫ�� UI
    public Image hpFill; // Ѫ������䲿��
    public float maxHealth;
    public float minHealth = 0;
    public float currentHealth;
    public void SetMaxHealth(float maxHealth)
    {
        hpFill.fillAmount = maxHealth;
    }
    public void SetHealth(float health)
    {
        hpFill.fillAmount = health / maxHealth; // ����������Ѫ��
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
