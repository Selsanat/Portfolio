using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnventCallerFade : MonoBehaviour
{
    public Transform TransformTeleport;
    private GameManager _gameManager;

    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    private void Teleport()
    {
        if (_gameManager.jeu == GameManager.e_jeu.Ebony)
        {
            _gameManager.Player.transform.position = TransformTeleport.position;
        }
    }
    private void TeleportBack()
    {
        if (_gameManager.jeu == GameManager.e_jeu.Ebony)
        {
            _gameManager.ButtonsEbony.gameObject.SetActive(false);
            _gameManager.Player.transform.position = _gameManager.TransformTpBack.position;
        }
    }
    private void ZoomIn()
    {
        _gameManager.AnimatorCamera.SetBool("ShouldZoom",true);
        StartCoroutine(WaitBeforeUI());
    }
    private void ZoomOut()
    {
        _gameManager.AnimatorCamera.SetBool("ShouldZoom", false);
        _gameManager.ButtonsEbony.gameObject.SetActive(false);
        StartCoroutine(WaitbeforeReleaseControls());
    }
    
    IEnumerator WaitbeforeReleaseControls()
    {
        yield return new WaitForSeconds(1.5f);
        _gameManager.InCombat = false;
    }
    IEnumerator WaitBeforeUI()
    {
        yield return new WaitForSeconds(1.5f);
        _gameManager.ButtonsEbony.gameObject.SetActive(true);
    }

}
