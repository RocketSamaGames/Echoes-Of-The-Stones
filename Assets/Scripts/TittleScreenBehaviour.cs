using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TittleScreenBehaviour : MonoBehaviour
{
    public Animator canvasAnimator;
    public GameObject panel;

    private float delayLoad = 3f;
    private float delayDisablePanel = 1.8f;

    private void Start()
    {
        Cursor.visible = true; 
        Cursor.lockState = CursorLockMode.None;
        StartCoroutine(DisablePanel());
    }

    public void StartGame()
    {
        panel.SetActive(true);
        canvasAnimator.Play("FadeOut");
        StartCoroutine(LoadGame());
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    private IEnumerator LoadGame()
    {
        yield return new WaitForSeconds(delayLoad);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private IEnumerator DisablePanel()
    {
        yield return new WaitForSeconds(delayDisablePanel);
        panel.SetActive(false);
    }
}
