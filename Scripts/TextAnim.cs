using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextAnim : MonoBehaviour
{
    public TextMeshProUGUI textbox;
    public float timeBetweenChars;

    private void OnEnable()
    {
        StartCoroutine(TextVisible());
    }

    public IEnumerator TextVisible()
    {
        textbox.ForceMeshUpdate();
        int totalVisibleCharacters = textbox.textInfo.characterCount;
        int counter = 0;

        while (true)
        {
            int visibleCount = counter % (totalVisibleCharacters + 1);
            textbox.maxVisibleCharacters = visibleCount;

            if (visibleCount >= totalVisibleCharacters)
            {
                break;
            }

            counter += 1;


            if (visibleCount > 0 && (textbox.text[visibleCount - 1] == '.' || textbox.text[visibleCount - 1] == ',')) yield return new WaitForSeconds(timeBetweenChars * 5);
            else yield return new WaitForSeconds(timeBetweenChars);
        }
    }
}
