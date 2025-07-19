using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    [Header("Player Progress")]
    public int totalCoins;    // Всего собранных монет
    public int currentRunCoins;  // Монеты в текущем заходе
    public PlayerStats playerStats; // Ссылка на скриптаблобъект с базовыми статами

    private void Awake()
    {
        if (Instance == null) { Instance = this; DontDestroyOnLoad(gameObject); }
        else Destroy(gameObject);
    }

    private void Start()
    {
        LoadProgress();
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        currentRunCoins = 0;
        // При запуске уровня обновить статы игрока
        var player = FindObjectOfType<PlayerController>();
        if (player != null) player.ApplyStats(playerStats);
    }

    public void AddCoin(int amount = 1)
    {
        currentRunCoins += amount;
        UIManager.Instance.UpdateCoins(currentRunCoins, totalCoins);
    }

    public void EndRun(bool victory)
    {
        if (victory)
        {
            totalCoins += currentRunCoins;
            SaveProgress();
        }
        // Перезапуск сцены
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    private void SaveProgress()
    {
        PlayerPrefs.SetInt("TotalCoins", totalCoins);
        // Здесь можно сохранять дополнительные данные, ну если захошешь
        PlayerPrefs.Save();
    }

    private void LoadProgress()
    {
        totalCoins = PlayerPrefs.GetInt("TotalCoins", 0);
    }
}
