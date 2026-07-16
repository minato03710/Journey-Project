using UnityEngine;
using UnityEngine.UI; // Required to control UI images
using UnityEngine.EventSystems; // Required to detect mouse hovers

public class ButtonHoverFlash : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private Image buttonImage;
    private Color originalColor;
    private bool isHovered = false;

    [Header("Flash Settings")]
    [Tooltip("The bright color the leaf will flash towards (e.g., bright yellow or light green)")]
    public Color flashColor = Color.white;
    
    [Tooltip("How fast the button pulses back and forth")]
    public float flashSpeed = 6f;

    void Start()
    {
        // Automatically grabs the Image component on this button
        buttonImage = GetComponent<Image>();
        if (buttonImage != null)
        {
            originalColor = buttonImage.color;
        }
    }

    void Update()
    {
        if (isHovered && buttonImage != null)
        {
            // Math magic: PingPong oscillates smoothly between 0 and 1
            float t = Mathf.PingPong(Time.time * flashSpeed, 1f);
            
            // Blends between the normal color and your bright flash color
            buttonImage.color = Color.Lerp(originalColor, flashColor, t);
        }
    }

    // Automatically runs when the mouse enters the button area
    public void OnPointerEnter(PointerEventData eventData)
    {
        isHovered = true;
    }

    // Automatically runs when the mouse leaves the button area
    public void OnPointerExit(PointerEventData eventData)
    {
        isHovered = false;
        
        // Instantly reset the color back to completely normal
        if (buttonImage != null)
        {
            buttonImage.color = originalColor;
        }
    }
}