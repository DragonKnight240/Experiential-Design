using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour
{
    public string SceneToLoad;
    Fade Fade;
    public Character Germaine;

    private void Start()
    {
        Fade = FindObjectOfType<Fade>();
    }

    private void OnTriggerEnter(Collider other)
    {
        //SceneManager.LoadScene(SceneToLoad);

        if (Germaine)
        {
            GameManager.Instance_.GermaineOpinion = Germaine.GetOpinionOfPlayer();
        }

        Time.timeScale = 0;
        Fade.fadeOut = true;
        StartCoroutine(LoadAsync());
    }

    IEnumerator LoadAsync()
    {
        if (Fade)
        {
            if (Fade.fadeOut)
            {
                yield return null;
            }
        }

        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(SceneToLoad);

        while (!asyncLoad.isDone)
        {
            yield return null;
        }

        Time.timeScale = 1;
    }

    public void LoadNewScene(string newScene)
    {
        SceneToLoad = newScene;
        StartCoroutine(LoadAsync());
    }
}
