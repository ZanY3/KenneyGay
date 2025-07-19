using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public static UIManager Instance;

    public Text healthText;
    public Text coinsText;

    private void Awake()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
    }

    public void UpdateHealth(float currentHealth)
    {
        healthText.text = "HP: " + Mathf.CeilToInt(currentHealth).ToString();
    }

    public void UpdateCoins(int runCoins, int totalCoins)
    {
        coinsText.text = $"Монеты: {runCoins} / Всего: {totalCoins}";
    }
}
