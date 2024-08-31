using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicPlayer : MonoBehaviour {
    public static MusicPlayer instance;
    public AudioSource audioSource;
    public AudioClip[] audioClips;

    //[SerializeField] private float startTime = 120;
    [SerializeField] private float restartTime = 132;

    private bool isFading = false;

    void Awake() {
        if (instance == null) {
            audioSource = GetComponent<AudioSource>();
            instance = this;
            //audioSource.time = startTime;
            DontDestroyOnLoad(gameObject);
        }
        else {

            Destroy(gameObject);
        }


    }

    private void Update() {
        if (audioSource.clip != audioClips[0]) {
            return;
        }

        if (audioSource.time >= restartTime-1 && !isFading) {
            StartCoroutine(RestartClipWithFade(audioSource,1));
        }
    }

    IEnumerator RestartClipWithFade(AudioSource source, float fadeDuration) {
        isFading = true;

        float startVolume = source.volume;

        for (float t = 0; t < fadeDuration; t += Time.deltaTime) {
            source.volume = Mathf.Lerp(startVolume, 0.5f, t / fadeDuration);
            yield return null;
        }

        source.volume = 0.5f;
        source.time = 0;
        source.Play();


        for (float t = 0; t < fadeDuration; t += Time.deltaTime) {
            source.volume = Mathf.Lerp(0.5f, startVolume, t / fadeDuration);
            yield return null;
        }

        source.volume = startVolume;

        isFading = false;
    }
}
