using System.Collections; 
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChanger : MonoBehaviour
{
    public string nextSceneName = "Anatomy Study";  // <-- put next scene name here
    public AudioSource assistantAudio;              // capsule sound
    public float extraDelay = 1f;                   // wait after audio

    void Start()
    {
        if (assistantAudio != null && assistantAudio.clip != null)
        {
            assistantAudio.Play();
            float wait = assistantAudio.clip.length + extraDelay;
            StartCoroutine(LoadNext(wait));
        }
        else
        {
            StartCoroutine(LoadNext(3f));
        }
    }

    IEnumerator LoadNext(float seconds)
    {
        yield return new WaitForSeconds(seconds);
        SceneManager.LoadScene(nextSceneName);
    }
}
