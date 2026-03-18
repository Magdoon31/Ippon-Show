using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class FightStyleSelection : MonoBehaviour
{
    [Header("UI")]
    public TMP_InputField nameInput;

    public TMP_Text styleNameText;
    public TMP_Text styleDescriptionText;

    public TMP_Text bodyTypeText;
    public TMP_Text difficultyText;

    [Header("Styles")]
    public FightStyleData[] styles;

    [Header("Body Types")]
    public string[] bodyTypes = { "Skeleton", "Skinny", "Slim", "Muscular" };

    public static int currentStyle = 0;
    public static int currentBody = 0;
    private bool isMainMenu;

    void Start()
    {
        //styles = Resources.LoadAll<FightStyleData>("Styles");
        if (styles == null || styles.Length == 0)
        {
            Debug.LogError("Nie znaleziono ¿adnych stylów walki w Resources/Styles!");
            return;
        }
        isMainMenu = SceneManager.GetActiveScene().name == "MainMenu";
        if (isMainMenu)
        {
            UpdateStyle();
            UpdateBody();
        }
            
    }

    public void NextStyle()
    {
        currentStyle++;

        if (currentStyle >= styles.Length)
            currentStyle = 0;
        if (isMainMenu)
            UpdateStyle();
    }

    public void PreviousStyle()
    {
        currentStyle--;

        if (currentStyle < 0)
            currentStyle = styles.Length - 1;
        if (isMainMenu)
            UpdateStyle();
    }

    void UpdateStyle()
    {
        if (!isMainMenu) return;
        styleNameText.text = styles[currentStyle].styleName;
        styleDescriptionText.text = styles[currentStyle].description;
    }

    public void NextBody()
    {
        currentBody++;

        if (currentBody >= bodyTypes.Length)
            currentBody = 0;
        if (isMainMenu)
            UpdateBody();
    }

    public void PreviousBody()
    {
        currentBody--;

        if (currentBody < 0)
            currentBody = bodyTypes.Length - 1;
        if (isMainMenu)
            UpdateBody();
    }

    void UpdateBody()
    {
        bodyTypeText.text = bodyTypes[currentBody];

        switch (bodyTypes[currentBody])
        {
            case "Skeleton":
                difficultyText.text = "Impossible";
                break;

            case "Skinny":
                difficultyText.text = "Hard";
                break;

            case "Slim":
                difficultyText.text = "Normal";
                break;

            case "Muscular":
                difficultyText.text = "Easy";
                break;
        }
    }
}