using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupMoney : MonoBehaviour
{
    public int MoneyGain;
    public GameObject InteractLabel;
    private MeshRenderer _rend;
    private AudioSource _audio;
    private BoxCollider _col;
    public AudioClip PickupSound;
    private bool IsInsideTrigger = false;

    private void Start()
    {
        IsInsideTrigger = false;
        _rend = GetComponent<MeshRenderer>();
        _audio = GetComponent<AudioSource>();
        _col = GetComponent<BoxCollider>();
    }

    void Update()
    {
        if (IsInsideTrigger)
        {
            if (Input.GetKey(KeyCode.E))
            {
                InteractLabel.SetActive(false);
                _rend.enabled = false;
                _col.enabled = false;
                _audio.PlayOneShot(PickupSound);
                MoneyManager.MoneyAmmount += MoneyGain;
                IsInsideTrigger = false;
            }
        }
        else
        {
            InteractLabel.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            InteractLabel.SetActive(true);
            IsInsideTrigger = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            IsInsideTrigger = false;
        }
    }
}
