using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Video;

public class DetectGameDesc : MonoBehaviour
{
    private GamePresentationManager _presentationManager;

    public SOLaPresentationDuJeu scriptable;
    void Start()
    {
        _presentationManager = GamePresentationManager.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        replaceDescGame();
        _presentationManager.animatorGameDesc.SetBool("ShouldShow", true);
        if(name == "ShadowBound")
        {
            GameManager.instance.AnimatorShadowBound.SetBool("ShouldStress", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        _presentationManager.animatorGameDesc.SetBool("ShouldShow", false);
        if (name == "ShadowBound")
        {
            GameManager.instance.AnimatorShadowBound.SetBool("ShouldStress", false);
        }
    }

    public void replaceDescGame()
    {
        _presentationManager.tmpName.text = scriptable.m_gameName;
        _presentationManager.tmpPeriode.text = scriptable.m_Periode;
        if (scriptable.m_isOnPC)
        {
            _presentationManager.ImageIsOnPC.sprite = _presentationManager.texturesPcMobile[0];
            _presentationManager.TextPC.text = "PC";
        }
        else
        {
            _presentationManager.ImageIsOnPC.sprite = _presentationManager.texturesPcMobile[1];
            _presentationManager.TextPC.text = "Mobile";
        }
        if(scriptable.m_UnityUsed)
        {
            _presentationManager.ImageUnityUsed.sprite = _presentationManager.texturesUnityUnreal[0];
        }
        else _presentationManager.ImageUnityUsed.sprite = _presentationManager.texturesUnityUnreal[1];
        _presentationManager.tmpLength.text = scriptable.m_length;
        _presentationManager.tmpNumberOfPeopleInvolved.text = scriptable.m_numberOfPeopleInvolved;
        _presentationManager.tmpMiscDesc.text = scriptable.m_miscDesc;
        _presentationManager.videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, scriptable.m_VideoClip);
        _presentationManager.videoPlayer.Play();
    }
}
