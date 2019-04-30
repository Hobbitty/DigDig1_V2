using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransform : MonoBehaviour
{
    public string sceneName;
    Animator animator;

    void Start()
    {
        animator = transform.GetComponent<Animator>();
    }

    public void SceneTrigger()
    {
        StartCoroutine(LoadSceneAfterTransition());
    }

    private IEnumerator LoadSceneAfterTransition()
    {
        animator.SetBool("SceneCutEnd", true);
        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene(sceneName);
    }
}
