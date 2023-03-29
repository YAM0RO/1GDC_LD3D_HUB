using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractNPC : MonoBehaviour
{
    public GameObject PanelInteract;
    public GameObject DialogBox;
    public GameObject DialogBox2;
    public GameObject Player;
    public GameObject CameraNPC;
    private AudioSource _audio;
    public AudioClip[] NPCSounds;
    public DebugMouse _mouseMNGR;
    private bool isPanelActive = false;

    private bool AcceptTask = false;

    void Start()
    {
        isPanelActive = false;
        AcceptTask = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPanelActive)
        {
            if(Input.GetKey(KeyCode.E) && !AcceptTask)
            {
                PanelInteract.SetActive(false);
                DialogBox.SetActive(true);
                CameraNPC.SetActive(true);
                _mouseMNGR.LockMouse = false;
                Player.SetActive(false);
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

        if (isPanelActive)
        {
            if (Input.GetKey(KeyCode.E) && AcceptTask)
            {
                PanelInteract.SetActive(false);
                DialogBox2.SetActive(true);
                CameraNPC.SetActive(true);
                _mouseMNGR.LockMouse = false;
                Player.SetActive(false);
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
        CameraNPC.SetActive(false);
        _mouseMNGR.LockMouse = true;
        Player.SetActive(true);
        AcceptTask = true;
    }

    public void MouseDebug()
    {
        _mouseMNGR.LockMouse = true;
        Cursor.lockState = CursorLockMode.Locked;
    }
}
