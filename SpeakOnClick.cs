using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SpeakOnClick : MonoBehaviour
{
    public AudioClip[] audioClips;
    public string[] audioCaptions;
    public AudioSource audioSource;
    public TextMeshProUGUI dialogBox;
    public GameObject panel;
    private bool textAnimPlaying;

    private float timeOfLastTouch;
    public GameObject tapIndicator;

    private void Start()
    {
        dialogBox.text = "";
    }

    private void Update()
    {
        if (!tapIndicator.activeSelf && Time.time - timeOfLastTouch > 15f)
        {
            tapIndicator.SetActive(true);
        }
    }

    private void OnMouseDown()
    {
        timeOfLastTouch = Time.time;
        if (tapIndicator.activeSelf) tapIndicator.SetActive(false);

        if (!textAnimPlaying && !panel.activeSelf)
        {
            int index = Random.Range(0, audioClips.Length);
            audioSource.PlayOneShot(audioClips[index]);

            dialogBox.text = $"Mashi: {audioCaptions[index]}";
            StartCoroutine(TextVisible());
        }
    }

    IEnumerator TextVisible()
    {
        textAnimPlaying = true;
        dialogBox.ForceMeshUpdate();
        int totalVisibleCharacters = dialogBox.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            dialogBox.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                break;
            }

            counter += 1;

            if (visibleCount > 0 && (dialogBox.text[visibleCount - 1] == '.' || dialogBox.text[visibleCount - 1] == ',' || dialogBox.text[visibleCount - 1] == '?')) yield return new WaitForSeconds(0.1f);
            else yield return new WaitForSeconds(0.05f);
        }
        StartCoroutine(DeleteText());
    }

    IEnumerator DeleteText()
    {
        yield return new WaitForSeconds(1.0f);
        textAnimPlaying = false;
        dialogBox.text = "";
    }
}
