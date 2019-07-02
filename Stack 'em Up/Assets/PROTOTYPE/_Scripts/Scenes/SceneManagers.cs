using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagers : MonoBehaviour {

    public static SceneManagers instance = null;
    public Animator sceneTransitionAnimator; //For scene transitions

    private void Start()
    {
        if(instance == null)
        {
            instance = this;
        }
        if(instance != this)
        {
            Destroy(this);
        }
        DontDestroyOnLoad(this.gameObject);
    }

    public void ToBattle()
    {
        SceneManager.LoadScene(1);
    }

    public void ToOverWorld()
    {
        SceneManager.LoadScene(0);
    }

    public void MoveToScene(int sceneNo)
    {
        SceneManager.LoadScene(sceneNo);
    }

    public IEnumerator SceneTransitionToScene(string sceneName)
    {
        sceneTransitionAnimator.SetTrigger("End");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(sceneName);
    }
}
