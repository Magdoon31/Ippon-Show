using UnityEngine;

public class MainMenuBTN : MonoBehaviour
{
    public void MainMenu()
    {
        LevelManager.Instance.LoadScene("MainMenu", "CrossFade");
    }
}
