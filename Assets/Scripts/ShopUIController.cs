using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Game.Shop.ViewModel;

namespace Game.Shop.Controller
{
    public class ShopUIController : MonoBehaviour
    {
        [SerializeField] private Button speechBubble;
        [SerializeField] private GameObject shopUI;
        [SerializeField] private Button shopCloseBtn;

        private ShopInteraction shopInteraction;

        void Start()
        {
            speechBubble.onClick.AddListener(ShowShopUI);
            shopCloseBtn.onClick.AddListener(CloseShopUI);

            shopInteraction = FindObjectOfType<ShopInteraction>();
        }

        public void ShowBubble()
        {
            speechBubble.gameObject.SetActive(true);
        }

        public void CloseBubble()
        {
            speechBubble.gameObject.SetActive(false);
        }

        public void ShowShopUI()
        {
            CloseBubble();
            shopUI.SetActive(true);
        }

        public void CloseShopUI()
        {
            shopUI.SetActive(false);
            ShowBubble();
            shopInteraction.ShowRandomClosingDialogue();
            StartCoroutine(CloseDelay());
        }

        public IEnumerator CloseDelay()
        {
            yield return new WaitForSeconds(1.01f);
            CloseBubble();
        }
    }
}

