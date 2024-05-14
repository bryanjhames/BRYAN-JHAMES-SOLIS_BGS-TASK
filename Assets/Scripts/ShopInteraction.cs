using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ShopInteraction : MonoBehaviour
{
    public GameObject shopUI; // Assign the shop UI Panel in the inspector
    public TMP_Text dialogueText; // Assign a UI Text element for dialogue in the inspector

    public string[] dialogues;

    void Start()
    {
        // Initialize the dialogues array
        dialogues = new string[10];
        dialogues[0] = "Welcome to my humble shop! How can I assist you today?";
        dialogues[1] = "Looking for something special? I've got just the thing for you!";
        dialogues[2] = "Ah, a new customer! Feel free to browse my wares.";
        dialogues[3] = "Hello there! Need any supplies for your journey?";
        dialogues[4] = "Greetings, traveler! I've got the best prices in town.";
        dialogues[5] = "Good day! Take your time and have a look around.";
        dialogues[6] = "Welcome! If you need anything, just let me know.";
        dialogues[7] = "Hi there! You won't find better deals anywhere else.";
        dialogues[8] = "Step right up! I've got goods from all over the world.";
        dialogues[9] = "Hello! Looking for something in particular today?";
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            ShowRandomDialogue();
            shopUI.SetActive(true);
            //Time.timeScale = 0f; // Pause the game when the shop UI is open
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            shopUI.SetActive(false);
            //Time.timeScale = 1f; // Resume the game when the shop UI is closed
        }
    }

    void ShowRandomDialogue()
    {
        if (dialogues.Length > 0 && dialogueText != null)
        {
            int randomIndex = Random.Range(0, dialogues.Length);
            dialogueText.text = dialogues[randomIndex];
        }
    }
}
