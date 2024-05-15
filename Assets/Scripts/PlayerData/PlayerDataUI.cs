using UnityEngine;
using TMPro;

public class PlayerDataUI : MonoBehaviour
{
    public static PlayerDataUI Instance { get; private set;}
    [SerializeField] private TMP_Text coinsText;
    [SerializeField] private TMP_Text gemsText;

    private void Start()
    {
        UpdateUI();
    }

    public void UpdateUI()
    {
        PlayerDataManager dataManager = PlayerDataManager.Instance;
        if (dataManager != null && dataManager.playerData != null)
        {
            coinsText.text = dataManager.playerData.coins.ToString();
            gemsText.text = dataManager.playerData.gems.ToString();
        }
    }
}
