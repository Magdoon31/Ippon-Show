using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Linq;
using Unity.VisualScripting;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    public Slider progressBar;
    public GameObject transitionsContainer;

    private SceneTransition[] transitions;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
        transitions = transitionsContainer.GetComponentsInChildren<SceneTransition>();
        LoadScene("MainMenu", "CrossFade");
    }
    public void LoadScene(string sceneName, string transitionName)
    {
        StartCoroutine(LoadSceneAsync(sceneName, transitionName));
    }

    private IEnumerator LoadSceneAsync(string sceneName, string transitionName)
    {
        SceneTransition transition = transitions.First(t => t.name == transitionName);
        transitionsContainer.SetActive(true);
        AsyncOperation scene = SceneManager.LoadSceneAsync(sceneName);
        scene.allowSceneActivation = false;

        yield return transition.AnimateTransitionIn();

        progressBar.gameObject.SetActive(true);
        
        yield return new WaitForSeconds(0.5f);
        progressBar.value = 0.2f;
        do
        {
            progressBar.value = scene.progress;
            yield return null;
        } while (scene.progress < 0.9f);

        yield return new WaitForSeconds(1f);

        scene.allowSceneActivation = true;

        progressBar.gameObject.SetActive(false);
        if (sceneName == "Game")
        {
            MusicManager.Instance.PlayMusic("Game");
        }
        if (sceneName == "MainMenu")
        {
            MusicManager.Instance.PlayMusic("Menu");
        }
        yield return transition.AnimateTransitionOut();
        transitionsContainer.SetActive(false);
        
    }
}