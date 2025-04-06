using UnityEngine;

public class InterfazControl : MonoBehaviour
{
    public GameObject spriteTomateTachado;
    public GameObject spriteBreadTachado;

    public AudioSource audioTachar;

    void Start()
    {
        if (spriteTomateTachado != null) spriteTomateTachado.SetActive(false);
        if (spriteBreadTachado != null) spriteBreadTachado.SetActive(false);
    }

    public void TacharSprite(string nombreObjeto)
    {
        if (nombreObjeto == "Tomate" && spriteTomateTachado != null)
        {
            spriteTomateTachado.SetActive(true);
            if (audioTachar != null) audioTachar.Play();
        }
        else if (nombreObjeto == "Bread" && spriteBreadTachado != null)
        {
            spriteBreadTachado.SetActive(true);
            if (audioTachar != null) audioTachar.Play();
        }
    }
}