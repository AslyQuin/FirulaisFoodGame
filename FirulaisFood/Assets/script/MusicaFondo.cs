using UnityEngine;

public class MusicaFondo : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip musicaTranquila;
    public AudioClip musicaOscura;

    private bool esOscuro = false; // Estado actual del ambiente

    void Start()
    {
        audioSource.clip = musicaTranquila; // Comenzar con la música tranquila
        audioSource.loop = true;
        audioSource.Play();
    }

    public void CambiarMusica()
    {
        esOscuro = !esOscuro; // Alterna entre tranquilo y oscuro

        if (esOscuro)
        {
            audioSource.clip = musicaOscura;
        }
        else
        {
            audioSource.clip = musicaTranquila;
        }

        audioSource.Play(); // Reproduce la nueva música
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.M)) // Cambia la música con la tecla M
        {
            CambiarMusica();
        }
    }
}