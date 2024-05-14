using UnityEngine;

public class PlayerDataManager : MonoBehaviour
{
    public static PlayerDataManager Instance { get; private set; }

    public PlayerData playerData;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        LoadPlayerData();
    }

    public void SavePlayerData()
    {
        PlayerPrefs.SetInt("coin", playerData.coins);
        PlayerPrefs.SetInt("gem", playerData.gems);
    }

    public void LoadPlayerData()
    {
        int coins = PlayerPrefs.GetInt("coin", 1000); // Default to 0 if no data exists
        int gems = PlayerPrefs.GetInt("gem", 100); // Default to 0 if no data exists

        playerData = new PlayerData(coins, gems);
    }

    public void AddCoins(int amount)
    {
        playerData.coins += amount;
        SavePlayerData();
    }

    public void AddGems(int amount)
    {
        playerData.gems += amount;
        SavePlayerData();
    }
}
