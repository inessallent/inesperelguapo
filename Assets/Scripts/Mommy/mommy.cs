using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mommy : MonoBehaviour
{
    public AudioClip revealClip1; // Primer audio
    public AudioClip appearClip2; // Segundo audio
    public GameObject mommyModel; // Momia
    public GameObject[] players; // Array de jugadores

    private AudioSource audioSource;
    private bool isMoving = false;

    public float moveSpeed = 5f; // Velocidad de la momia

    public static mommy Instance { get; private set; }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();
        }

        if (mommyModel == null)
        {
            Debug.LogError("mommyModel GameObject is not assigned.");
        }
    }

    void Start()
    {
        if (mommyModel != null)
        {
            mommyModel.SetActive(false); // Ocultar la momia
        }
        StartMommySequence();
    }

    public void StartMommySequence()
    {
        StartCoroutine(RevealSequence());
    }

    private IEnumerator RevealSequence()
    {
        // Mover a los jugadores primero
        foreach (GameObject player in players)
        {
            player.GetComponent<playerMovementMommy>().MoveTo(80.9f);
        }

        // Esperar a que los jugadores lleguen a su posición
        yield return new WaitUntil(() => PlayersHaveReachedPosition());

        // Reproducir el primer audio
        if (revealClip1 != null && audioSource != null)
        {
            audioSource.clip = revealClip1;
            audioSource.Play();

            // Esperar a que el primer audio termine de reproducirse
            yield return new WaitForSeconds(revealClip1.length);
        }

        // Hacer visible la momia
        if (mommyModel != null)
        {
            mommyModel.SetActive(true);
            // Rotar la momia para que se levante
            mommyModel.transform.rotation = Quaternion.Euler(0, 180, 0);
        }

        // Reproducir el segundo audio
        if (appearClip2 != null && audioSource != null)
        {
            audioSource.clip = appearClip2;
            audioSource.Play();

            // Esperar a que el segundo audio termine de reproducirse
            yield return new WaitForSeconds(appearClip2.length);
        }

        // Mover a los jugadores de nuevo
        foreach (GameObject player in players)
        {
            player.GetComponent<playerMovementMommy>().MoveTo(104, true);
        }
    }

    private bool PlayersHaveReachedPosition()
    {
        foreach (GameObject player in players)
        {
            if (player.GetComponent<playerMovementMommy>().IsMoving)
            {
                return false;
            }
        }
        return true;
    }

    // Método llamado cuando los jugadores alcanzan su posición final
    public void OnPlayersReachedFinalPosition()
    {
        // Coloca aquí el código que necesites ejecutar cuando los jugadores alcanzan su posición final
    }

    // Método llamado cuando los jugadores alcanzan su posición inicial
    public void OnPlayersReachedInitialPosition()
    {
        // Coloca aquí el código que necesites ejecutar cuando los jugadores alcanzan su posición inicial
    }
}
