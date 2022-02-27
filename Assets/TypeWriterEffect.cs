using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TypeWriterEffect : MonoBehaviour
{
    public float delaySpeed = 0.01f;
    [TextArea]
    public string fullText;
    public bool textCompleted = false;
    private string currentText;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(ShowText());
    }

    IEnumerator ShowText()
    {
        for (int i = 0; i < fullText.Length + 1; i++)
        {
            currentText = fullText.Substring(0, i);
            this.GetComponent<TMP_Text>().text = currentText;
            if (i == fullText.Length)
            {
                textCompleted = true;
            }
            yield return new WaitForSeconds(delaySpeed);
        }
    }
}
