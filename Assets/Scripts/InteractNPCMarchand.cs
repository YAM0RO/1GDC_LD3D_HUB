using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPCMarchand : MonoBehaviour
{
    public GameObject PanelInteract;
    public GameObject DialogBox;
    private AudioSource _audio;
    public GameObject Player;
    public GameObject CameraNPC;
    public AudioClip[] NPCSounds;
    public AudioClip MarchandSound;
    public AudioClip BuySound;
    public DebugMouse _mouseMNGR;
    private bool isPanelActive = false;

    void Start()
    {
        isPanelActive = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPanelActive)
        {
            if(Input.GetKey(KeyCode.E))
            {
                PanelInteract.SetActive(false);
                DialogBox.SetActive(true);
                CameraNPC.SetActive(true);
                Player.SetActive(false);
                _mouseMNGR.LockMouse = false;
                int index = Random.Range(0, NPCSounds.Length);
                _audio.clip = NPCSounds[index];
                _audio.Play();
                _audio.PlayOneShot(MarchandSound);
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            PanelInteract.SetActive(false);
        }

        if (isPanelActive)
        {
            if (Input.GetKey(KeyCode.E))
            {
                PanelInteract.SetActive(false);
                _mouseMNGR.LockMouse = false;
                int index = Random.Range(0, NPCSounds.Length);
                _audio.clip = NPCSounds[index];
                _audio.Play();
                Cursor.lockState = CursorLockMode.None;
            }
        }
        else
        {
            PanelInteract.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            PanelInteract.SetActive(true);
            isPanelActive = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPanelActive = false;
        }
    }

    public void CloseBox()
    {
        Cursor.lockState = CursorLockMode.Locked;
        DialogBox.SetActive(false);
        _mouseMNGR.LockMouse = true;
        Player.SetActive(true);
        CameraNPC.SetActive(false);
    }

    public void MouseDebug()
    {
        _mouseMNGR.LockMouse = true;
        Cursor.lockState = CursorLockMode.Locked;
    }

    public void AchatSFX()
    {
        _audio.PlayOneShot(BuySound);
    }
}
