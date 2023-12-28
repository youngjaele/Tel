using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScene : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI startText;

    private bool isTextVisible = true;
    private float flash = 0.5f;

    private void Awake()
    {
        StartCoroutine(FlashText());
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            SceneManager.LoadScene("MainScene");
            Time.timeScale = 1.0f;
        }
    }

    IEnumerator FlashText()
    {
        while (true)
        {
            yield return new WaitForSeconds(flash);
            isTextVisible = !isTextVisible;
            startText.enabled = isTextVisible;
        }
    }
}
