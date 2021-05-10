using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class sonucManager : MonoBehaviour
{
    [SerializeField]
    private GameObject SonucImage;
    [SerializeField]
    private Text DogruText, YanlisText, PuanText;
    [SerializeField]
    private GameObject Cark, GeriDonBtn, SureImage, PuanImage, DogruYanlisPaneli, Hapis, DogruYanlisIkonlari, Bonus;

    private void OnEnable()
    {
        SonucImage.transform.DOLocalMove(Vector3.zero, 0.5f).SetEase(Ease.OutBack);
        SonucImage.transform.GetComponent<CanvasGroup>().DOFade(1f, 0.5f);
    }
    public void SonuclariYazdir(int DogruSayisi, int YanlisSayisi, int Puan)
    {
        EkraniTemizle();
        DogruText.text = DogruSayisi.ToString();
        YanlisText.text = YanlisSayisi.ToString();
        PuanText.text = Puan.ToString();
    }
    void EkraniTemizle()
    {
        Cark.SetActive(false);
        GeriDonBtn.SetActive(false);
        SureImage.SetActive(false);
        PuanImage.SetActive(false);
        DogruYanlisPaneli.SetActive(false);
        Hapis.SetActive(false);
        DogruYanlisIkonlari.SetActive(false);
        Bonus.SetActive(false);
    }
    public void TekraraOynaButonu()
    {
        SceneManager.LoadScene("GameLevel");
    }
}
