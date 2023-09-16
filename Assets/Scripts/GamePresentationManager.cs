using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Video;
using TMPro;
using UnityEngine.UI;

public class GamePresentationManager : MonoBehaviour
{
    public static GamePresentationManager instance { get; private set; }
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        instance = this;
    }
    public Animator animatorGameDesc;
    public TMP_Text tmpName;
    public TMP_Text tmpPeriode;
    public Image ImageIsOnPC;
    public TMP_Text TextPC;
    public Sprite[] texturesPcMobile;
    public TMP_Text tmpLength;
    public TMP_Text tmpNumberOfPeopleInvolved;
    public Image ImageUnityUsed;
    public Sprite[] texturesUnityUnreal;
    public TMP_Text tmpMiscDesc;
    public VideoPlayer videoPlayer;
}
