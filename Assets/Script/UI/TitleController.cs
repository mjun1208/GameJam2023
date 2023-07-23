using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TitleController : MonoBehaviour
{
    [SerializeField] private Image image;
    [SerializeField] private float duration = 1;

    [SerializeField] private Button button;

    private bool load;

    void Start()
    {
        image.color = Color.white;

        button.onClick.AddListener(Play);
    }

    void Play()
    {
        if (load)
            return;

        load = true;
        StartCoroutine(TitleFadeOut());
    }

    IEnumerator TitleFadeOut()
    {
        image.color = Color.white;


        var startTime = Time.time;
        var endTime = startTime + duration;

        while (endTime > Time.time)
        {
            var normalized = (Time.time - startTime) / duration;
            image.color = Color.white * (1 - normalized);
            yield return null;
        }

        SceneManager.LoadScene("SampleScene");
    }
}
