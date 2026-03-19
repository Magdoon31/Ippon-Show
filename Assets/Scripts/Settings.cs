using UnityEngine;
using Toggle = UnityEngine.UI.Toggle;
using UnityEngine.SceneManagement;
public class Settings : MonoBehaviour
{
    public Toggle HPPrecToggle;
    public GameObject[] targets;

    void Start()
    {
        bool isActive = PlayerPrefs.GetInt("HPPrecIsON", 0) == 1;
        if (SceneManager.GetActiveScene().name == "Game")
        {
            foreach (GameObject target in targets)
                target.SetActive(isActive);
        }
        if (HPPrecToggle != null)
        {
            HPPrecToggle.isOn = isActive;
        }
    }
    public void SaveSettings()
    {
        PlayerPrefs.SetInt("HPPrecIsON", HPPrecToggle.isOn ? 1 : 0);
        PlayerPrefs.Save();
        Debug.Log("SAVE");
    }
    public void LoadSettings()
    {
        HPPrecToggle.isOn = PlayerPrefs.GetInt("HPPrecIsON", 0) == 1;
    }
}
