using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ObjectLoader : MonoBehaviour
{

    public GameObject loadingScreen;
    public Slider slider;


    public void LoadLevel(int SceneIndex)
    {
        StartCoroutine(loadAsynchronously(SceneIndex));
    }

    IEnumerator loadAsynchronously(int SceneIndex)
    {

        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneIndex);
        loadingScreen.SetActive(true);
        while (!operation.isDone)
        {
            float prog = Mathf.Clamp01(operation.progress / 0.9f);
            Debug.Log(prog);
            slider.value = prog;
            yield return null;
        }
    }
}
