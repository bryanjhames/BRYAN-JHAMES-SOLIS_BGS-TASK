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
            // Initialize player data with initial values
            playerData = new PlayerData(1000, 100);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void AddCoins(int amount)
    {
        playerData.coins += amount;
        OnDataChanged();
    }

    public void SpendCoins(int amount)
    {
        if (playerData.coins >= amount)
        {
            playerData.coins -= amount;
            OnDataChanged();
        }
    }

    public void AddGems(int amount)
    {
        playerData.gems += amount;
        OnDataChanged();
    }

    public void SpendGems(int amount)
    {
        if (playerData.gems >= amount)
        {
            playerData.gems -= amount;
            OnDataChanged();
        }
    }

    public delegate void DataChanged();
    public event DataChanged OnDataChanged;
}
