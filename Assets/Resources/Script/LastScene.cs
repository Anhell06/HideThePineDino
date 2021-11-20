using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LastScene : MonoBehaviour
{
    TMP_Text endString;
    string endText;

    void Start()
    {
        endText = PlayerPrefs.GetString("lose");
        endString.text = endText;
        StartCoroutine("EndScene");
    }

    private IEnumerable EndScene()
    {
        yield return new WaitForSeconds(10f);
        SceneManager.LoadScene(0);
    }
}
