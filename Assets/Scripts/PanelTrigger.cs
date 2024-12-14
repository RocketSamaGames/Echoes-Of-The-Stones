using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanelTrigger : MonoBehaviour
{
    public Animator canvasAnimator;

    private float delayBeforeLoad = 5.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("El jugador a tocado el panel");
            canvasAnimator.Play("FadeOut");
            StartCoroutine(LoadScreenTittle());
        }
    }

    private IEnumerator LoadScreenTittle()
    {
        yield return new WaitForSeconds(delayBeforeLoad);
        SceneManager.LoadScene("TittleScreen");
    }
}
