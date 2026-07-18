using UnityEngine;
using TMPro; // Required to control TextMeshPro components

public class LeafManager : MonoBehaviour
{
    // Allows any other script to easily talk to the LeafManager
    public static LeafManager Instance;

    [Header("UI Reference")]
    [SerializeField] private TextMeshProUGUI leafText;

    private int leavesCollected = 0;

    void Awake()
    {
        // Set up the static instance
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        UpdateUI();
    }

    // Call this function whenever a leaf is eaten
    public void AddLeaf()
    {
        leavesCollected++;
        UpdateUI();
    }

    // Updates the actual numbers on the player's screen
    private void UpdateUI()
    {
        if (leafText != null)
        {
            leafText.text = "Leaves: " + leavesCollected;
        }
    }
}