using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using UnityEngine.SceneManagement;

public class EgitimMenuManager : MonoBehaviour
{
    [SerializeField]
    private GameObject StartBtn, GeriDonBtn, FadePanel, KokIciPrefab, ScrollBar;
    [SerializeField]
    private Transform KokList;
    public static Sprite[] StaticKokIcıImages, StaticKokDisimages;
    [SerializeField]
    private Sprite[] KokIcıImages, KokDisiImages = new Sprite[59];
    [SerializeField]
    private Image KokDisiImage;
    [SerializeField]
    private AudioClip AlistirmaClip;
    [SerializeField]
    private Text AciklamaText;
    public static int denme;

    void Start()
    {
        KokIciPrefabUret();
        StaticKokIcıImages = KokIcıImages;
        StaticKokDisimages = KokDisiImages;
        FadePanel.GetComponent<CanvasGroup>().DOFade(0, 1f).OnComplete(BaslangicAyarlari);
    }
    void BaslangicAyarlari()
    {
        ScrollBar.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);
        StartBtn.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);
        GeriDonBtn.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);
        AciklamaText.GetComponent<RectTransform>().DOScale(1f, 1f).SetEase(Ease.OutBounce);
        Ses(AlistirmaClip);
        FadePanel.SetActive(false);
    }
    void KokIciPrefabUret()
    {
        for (int i = 0; i < KokIcıImages.Length; i++)
        {
            GameObject KokIciPrefabInstantiate = Instantiate(KokIciPrefab, KokList);
            KokIciPrefabInstantiate.GetComponent<KokIciButon>().ButonNumarasi = i;
            KokIciPrefabInstantiate.transform.GetChild(3).GetComponent<Image>().sprite = KokIcıImages[i];
            //KokDisiImage.sprite = KokDisiImages[0];
        }
    }
    public void KokDisiDegeriGetir(int ButonNumarasi)
    {
        KokDisiImage.sprite = KokDisiImages[ButonNumarasi];
    }
    public void GeriDonButonu()
    {
        SceneManager.LoadScene("MenuLevel");
    }
    public void OynaButonu()
    {
        SceneManager.LoadScene("GameLevel");
    }
    void Ses(AudioClip Clip)
    {
        AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, 1f);
    }
}
