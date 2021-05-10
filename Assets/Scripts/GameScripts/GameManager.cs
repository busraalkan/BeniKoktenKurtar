using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class GameManager : MonoBehaviour
{
    Sprite[] KokIcıImage = new Sprite[59];
    Sprite[] KokDisiImage = new Sprite[59];
    [SerializeField]
    private Image[] Cevaplar = new Image[6];
    [SerializeField]
    private Image UstSoru;
    [SerializeField]
    private Image AltSoru;
    [SerializeField]
    private GameObject Cark;
    [SerializeField]
    private GameObject SagBar, SolBar;
    [SerializeField]
    private GameObject DogruIkon, YanlisIkon, DogruYanlisFade, Bonus;
    [SerializeField]
    private Text DogruSayisiText, YanlisSayisiText, SureText, PuanText;
    [SerializeField]
    private AudioClip BaslangicSes, CarkSesi, BarSesi;
    int SoruIndeksi, RastgeleBelirtec;
    int PuanArtisMiktari, BonusSayisi, KacinciYanlis;
    bool CarkDurumu, CarkDonsunMu, CevapDogrulugu, CevapSecilsinMi;
    string BasilanButon;
    public int ToplamPuan, DogruSayisi, YanlisSayisi;
    Vector3 SolBarİlkKonum = new Vector3(-235, 77, 0);
    Vector3 SagBarİlkKonum = new Vector3(235, 77, 0);
    Vector3 SolBarİlkKapanis = new Vector3(-145, 77, 0);
    Vector3 SagBarİlkKapanis = new Vector3(145, 77, 0);
    Vector3 SolBarSonKapanis = new Vector3(-95, 77, 0);
    Vector3 SagBarSonKapanis = new Vector3(110, 77, 0);
    void Start()
    {
        Ses(BaslangicSes);
        BonusSayisi = 0;
        KacinciYanlis = 0;
        KokIcıImage = EgitimMenuManager.StaticKokIcıImages;
        KokDisiImage = EgitimMenuManager.StaticKokDisimages;
        CarkDurumu = true;
        CevapSecilsinMi = true;
        CarkDonsunMu = true;
        ResimleriYerlestir();
    }
    void ResimleriYerlestir()
    {
        SoruIndeksi = Random.Range(1, KokDisiImage.Length - 1);
        RastgeleBelirtec = Random.Range(0, 99);
        if (CarkDurumu)
        {
            if (RastgeleBelirtec < 33)
            {
                Cevaplar[0].sprite = KokDisiImage[SoruIndeksi];
                Cevaplar[1].sprite = KokDisiImage[SoruIndeksi - 1];
                Cevaplar[2].sprite = KokDisiImage[SoruIndeksi + 1];
            }
            else if (RastgeleBelirtec < 66)
            {
                Cevaplar[0].sprite = KokDisiImage[SoruIndeksi - 1];
                Cevaplar[1].sprite = KokDisiImage[SoruIndeksi];
                Cevaplar[2].sprite = KokDisiImage[SoruIndeksi + 1];
            }
            else if (RastgeleBelirtec < 99)
            {
                Cevaplar[0].sprite = KokDisiImage[SoruIndeksi - 1];
                Cevaplar[1].sprite = KokDisiImage[SoruIndeksi + 1];
                Cevaplar[2].sprite = KokDisiImage[SoruIndeksi];
            }
            UstSoru.sprite = KokIcıImage[SoruIndeksi];
        }
        else
        {
            if (RastgeleBelirtec < 33)
            {
                Cevaplar[3].sprite = KokDisiImage[SoruIndeksi];
                Cevaplar[4].sprite = KokDisiImage[SoruIndeksi - 1];
                Cevaplar[5].sprite = KokDisiImage[SoruIndeksi + 1];
            }
            else if (RastgeleBelirtec < 66)
            {
                Cevaplar[3].sprite = KokDisiImage[SoruIndeksi - 1];
                Cevaplar[4].sprite = KokDisiImage[SoruIndeksi];
                Cevaplar[5].sprite = KokDisiImage[SoruIndeksi + 1];
            }
            else if (RastgeleBelirtec < 99)
            {
                Cevaplar[3].sprite = KokDisiImage[SoruIndeksi - 1];
                Cevaplar[4].sprite = KokDisiImage[SoruIndeksi + 1];
                Cevaplar[5].sprite = KokDisiImage[SoruIndeksi];
            }
            AltSoru.sprite = KokIcıImage[SoruIndeksi];
        }
        CarkDurumu = !CarkDurumu;
    }
    public void CevapButonlarindanBirineBasildi()
    {
        BasilanButon = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.transform.GetChild(0).GetComponent<Image>().sprite.name;
        if (CevapSecilsinMi)
        {
            CevapSecilsinMi = false;
            CevapDogruMu();
        }
    }
    public void CevapDogruMu()
    {
        if (BasilanButon == KokDisiImage[SoruIndeksi].name)
        {
            DogruSayisi++;
            BonusSayisi++;
            if (BonusSayisi >= 5 && BonusSayisi <= 9)
            {
                PuanArtisMiktari = 30;
                Bonus.transform.DOScale(Vector3.one, 0.3f).SetEase(Ease.OutElastic);
            }
            else
            {
                PuanArtisMiktari = 20;
            }
            if (BonusSayisi > 9)
            {
                BonusSayisi = 0;
            }
            CevapDogrulugu = true;
            CarkiDondur();
        }
        else
        {
            YanlisSayisi++;
            Bonus.transform.DOScale(Vector3.zero, 0.3f).SetEase(Ease.InElastic);
            BonusSayisi = 0;
            CevapDogrulugu = false;
            KacinciYanlis++;
            BarlariKapat(KacinciYanlis);
            PuanArtisMiktari = -5;
        }
        ToplamPuan += PuanArtisMiktari;
        if (ToplamPuan <= 0)
        {
            ToplamPuan = 0;
        }
        PuanText.text = ToplamPuan.ToString();
        IkonlariCalistir();
        DogruSayisiText.text = DogruSayisi.ToString();
        YanlisSayisiText.text = YanlisSayisi.ToString();
    }
    void CarkiDondur()
    {
        if (CarkDonsunMu)
        {
            Ses(CarkSesi);
            SolBar.transform.DOLocalMove(SolBarİlkKonum, 0.5f);
            SagBar.transform.DOLocalMove(SagBarİlkKonum, 0.5f);
            KacinciYanlis = 0;
            Cark.transform.DORotate(Cark.transform.rotation.eulerAngles + new Vector3(0, 0, 180), 0.5f);
            CevapSecilsinMi = true;
            ResimleriYerlestir();
        }
    }
    void BarlariKapat(int YanlisAdeti)
    {
        if (YanlisAdeti == 1)
        {
            CevapSecilsinMi = true;
            SolBar.transform.DOLocalMove(SolBarİlkKapanis, 0.5f);
            SagBar.transform.DOLocalMove(SagBarİlkKapanis, 0.5f);
        }
        else if (YanlisAdeti == 2)
        {
            CevapSecilsinMi = false;
            SolBar.transform.DOLocalMove(SolBarSonKapanis, 0.5f);
            SagBar.transform.DOLocalMove(SagBarSonKapanis, 0.5f);
            Invoke("CarkiDondur", 1f);
        }
        Ses(BarSesi);
    }
    void IkonlariCalistir()
    {
        if (CevapDogrulugu)
        {
            DogruIkon.SetActive(true);
            YanlisIkon.SetActive(false);
        }
        else
        {
            DogruIkon.SetActive(false);
            YanlisIkon.SetActive(true);
        }
        DogruYanlisFade.GetComponent<CanvasGroup>().DOFade(1, 0.2f);
        Invoke("IkonlariKapat", 0.3f);
    }
    void IkonlariKapat()
    {
        DogruYanlisFade.GetComponent<CanvasGroup>().DOFade(0, 0.2f);
    }
    public void GeriDonButonu()
    {
        SceneManager.LoadScene("EgitimLevel");
    }
    void Ses(AudioClip Clip)
    {
        AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, 1f);
    }
}
