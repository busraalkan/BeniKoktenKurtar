using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    [SerializeField]
    private Text SureText;
    [SerializeField]
    private GameObject SonucPaneli;
    [SerializeField]
    private AudioClip OyunSonuSesi;
    int KalanSure;
    bool TimerAktifligi;
    sonucManager SonucManagerObje;
    GameManager GameManagerObje;
    void Start()
    {
        GameManagerObje = Object.FindObjectOfType<GameManager>();
        KalanSure = 60;
        TimerAktifligi = true;
        StartCoroutine(TimerRoutine());
    }

    IEnumerator TimerRoutine()
    {
        while (TimerAktifligi)
        {
            yield return new WaitForSeconds(1f);
            if (KalanSure < 10)
            {
                SureText.text = "0" + KalanSure.ToString();
                SureText.color = Color.red;
            }
            else
            {
                SureText.text = KalanSure.ToString();
            }
            if (KalanSure <= 0)
            {
                Ses(OyunSonuSesi);
                SureText.text = "";
                StopAllCoroutines();
                SonucPaneli.SetActive(true);
                SonucManagerObje = Object.FindObjectOfType<sonucManager>();
                SonucManagerObje.SonuclariYazdir(GameManagerObje.DogruSayisi, GameManagerObje.YanlisSayisi, GameManagerObje.ToplamPuan);
            }
            KalanSure--;
        }
        void Ses(AudioClip Clip)
        {
            AudioSource.PlayClipAtPoint(Clip, Camera.main.transform.position, 1f);
        }
    }
}
