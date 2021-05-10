using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CerceveRengiManager : MonoBehaviour
{
    Color Colour;
    int RastgeleDeger;
    void Start()
    {
        RenkDegistir();
        this.gameObject.GetComponent<Image>().color = Colour;
    }

  void RenkDegistir()
    {
        RastgeleDeger = Random.Range(0, 1000);
        if (RastgeleDeger <= 200)
        {
            Colour = Color.magenta;
        }
        else if (RastgeleDeger <= 400)
        {
            Colour = Color.green;
        }
        else if (RastgeleDeger <= 600)
        {
            Colour = Color.black;
        }
        else if (RastgeleDeger <= 800)
        {
            Colour = Color.yellow;
        }
        else if (RastgeleDeger <= 1000)
        {
            Colour = Color.red;
        }
    }
}
