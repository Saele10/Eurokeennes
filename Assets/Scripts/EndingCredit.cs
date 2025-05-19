using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement; // Pour charger la scène

public class EndingCredit : MonoBehaviour
{
    public float scrollspeed = 60f;
    public float endYPosition = 2000f; // Ajuste cette valeur selon la hauteur de ton crédit

    private RectTransform rectTransform;

    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        // Scroll vers le haut
        rectTransform.anchoredPosition += new Vector2(0, scrollspeed * Time.deltaTime);

        // Si on appuie sur Échap, retour au menu
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ReturnToMainMenu();
        }

        // Si le crédit a dépassé la position finale, retour au menu
        if (rectTransform.anchoredPosition.y >= endYPosition)
        {
            ReturnToMainMenu();
        }
    }

    void ReturnToMainMenu()
    {
        SceneManager.LoadScene("MainMenu"); // Assure-toi que "MainMenu" correspond au nom exact de ta scène
    }
}
