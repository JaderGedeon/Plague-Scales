using System.Collections;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class SceneLoader
{
    private class SceneLoadingMonoBehavior : MonoBehaviour { }

    public enum Scene { 
        MainScene,
        OtherScene,
    }

    public static void LoadAdditive(Scene scene)
    {
        if (SceneManager.GetSceneByName(scene.ToString()).IsValid())
            return;

        GameObject sceneLoadingGameObject = new("Scene Loading Game Object");
        sceneLoadingGameObject.AddComponent<SceneLoadingMonoBehavior>().StartCoroutine(LoadAdditiveSceneAsync(scene, sceneLoadingGameObject));
    }

    public static void UnloadAdditive(Scene scene)
    {
        if (!SceneManager.GetSceneByName(scene.ToString()).IsValid())
            return;

        GameObject sceneLoadingGameObject = new("Scene Unloading Game Object");
        sceneLoadingGameObject.AddComponent<SceneLoadingMonoBehavior>().StartCoroutine(UnloadAdditiveSceneAsync(scene, sceneLoadingGameObject));
    }

    private static IEnumerator LoadAdditiveSceneAsync(Scene scene, GameObject sender)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(scene.ToString(), LoadSceneMode.Additive);

        while (!asyncOperation.isDone)
            yield return null;

        if (asyncOperation.isDone)
            Object.Destroy(sender);
    }

    private static IEnumerator UnloadAdditiveSceneAsync(Scene scene, GameObject sender)
    {
        yield return null;
        AsyncOperation asyncOperation = SceneManager.UnloadSceneAsync(scene.ToString());

        while (!asyncOperation.isDone)
            yield return null;

        if (asyncOperation.isDone)
            Object.Destroy(sender);
    }
}
