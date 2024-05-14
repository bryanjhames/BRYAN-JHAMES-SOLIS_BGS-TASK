using UnityEngine;

[System.Serializable]
public class PlayerData
{
    public int coins;
    public int gems;

    public PlayerData(int initialCoins, int initialGems)
    {
        coins = initialCoins;
        gems = initialGems;
    }
}
