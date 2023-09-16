using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance { get; private set; }

    public enum e_jeu { Ebony, FranxPrix, OnlyLoneWay, ShadowBound };
    public Animator AnimatorFade;
    public bool InCombat = false;
    public GameObject Player;
    public e_jeu jeu;
    public Animator AnimatorCamera;
    public Animator AnimatorCartes;
    public Canvas ButtonsEbony;
    public Transform TransformTpBack;
    public DissolveController DissolveController;
    public Animator AnimatorShadowBound;
    void Awake()
    {
        if (instance != null && instance != this)
            Destroy(gameObject);    // Suppression d'une instance précédente (sécurité...sécurité...)

        instance = this;
    }
}
