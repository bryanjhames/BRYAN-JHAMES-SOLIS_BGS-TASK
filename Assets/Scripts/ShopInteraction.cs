using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Game.Shop.ViewModel 
{
    public class ShopInteraction : MonoBehaviour
    {
        public static ShopInteraction Instance;
        public GameObject shopUI; // Assign the shop UI Panel in the inspector
        public TMP_Text dialogueText; // Assign a UI Text element for dialogue in the inspector

        public string[] openingDialogues;
        public string[] closingDialogues;
        private bool isShopOpen = false;

        void Start()
        {
            // Initialize the opening dialogues array
            openingDialogues = new string[10];
            openingDialogues[0] = "Welcome to my humble shop! How can I assist you today?";
            openingDialogues[1] = "Looking for something special? I've got just the thing for you!";
            openingDialogues[2] = "Ah, a new customer! Feel free to browse my wares.";
            openingDialogues[3] = "Hello there! Need any supplies for your journey?";
            openingDialogues[4] = "Greetings, traveler! I've got the best prices in town.";
            openingDialogues[5] = "Good day! Take your time and have a look around.";
            openingDialogues[6] = "Welcome! If you need anything, just let me know.";
            openingDialogues[7] = "Hi there! You won't find better deals anywhere else.";
            openingDialogues[8] = "Step right up! I've got goods from all over the world.";
            openingDialogues[9] = "Hello! Looking for something in particular today?";

            // Initialize the closing dialogues array
            closingDialogues = new string[5];
            closingDialogues[0] = "Thank you! Come again!";
            closingDialogues[1] = "Hope to see you soon!";
            closingDialogues[2] = "Take care and travel safe!";
            closingDialogues[3] = "Goodbye and good luck!";
            closingDialogues[4] = "Don't forget to check back for new items!";
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                ShowRandomOpeningDialogue();
                shopUI.SetActive(true);
                isShopOpen = true;
                // Time.timeScale = 0f; // Pause the game when the shop UI is open
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                shopUI.SetActive(false);
                isShopOpen = false;
                ShowRandomClosingDialogue();
                // Time.timeScale = 1f; // Resume the game when the shop UI is closed
            }
        }

        public void ShowRandomOpeningDialogue()
        {
            if (openingDialogues.Length > 0 && dialogueText != null)
            {
                int randomIndex = Random.Range(0, openingDialogues.Length);
                dialogueText.text = openingDialogues[randomIndex];
            }
        }

        public void ShowRandomClosingDialogue()
        {
            if (closingDialogues.Length > 0 && dialogueText != null)
            {
                int randomIndex = Random.Range(0, closingDialogues.Length);
                dialogueText.text = closingDialogues[randomIndex];
            }
        }
    }
}
