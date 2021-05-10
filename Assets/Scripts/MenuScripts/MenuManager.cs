using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using DG.Tweening;

public class MenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject HakkimdaPaneli;
    bool HakkimdaPaneliAktifligi;
    private void Start()
    {
        HakkimdaPaneliAktifligi = false;
    }
    public void BaslaButonu()
    {
        SceneManager.LoadScene("EgitimLevel");
    }
    public void HakkimdaButonu()
    {
        if (!HakkimdaPaneliAktifligi)
        {
            HakkimdaPaneli.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
        }
        else
        {
            HakkimdaPaneli.GetComponent<CanvasGroup>().DOFade(0f, 0.5f);
        }
        HakkimdaPaneliAktifligi = !HakkimdaPaneliAktifligi;
    }
    public void CikisButonu()
    {
        Application.Quit();
    }
}
