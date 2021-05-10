using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KokIciButon : MonoBehaviour
{
    [SerializeField]
    private Image KokDegeriImage;
    public int ButonNumarasi;
    EgitimMenuManager egitimMenuManagerObje;
    private void Start()
    {
        egitimMenuManagerObje = FindObjectOfType<EgitimMenuManager>();
    }
    public void Buton()
    {
        egitimMenuManagerObje.KokDisiDegeriGetir(ButonNumarasi);
    }

}
