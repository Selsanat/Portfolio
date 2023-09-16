using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitboxSword : MonoBehaviour
{
    private GameManager _gameManager;
    private string link;
    private void Start()
    {
        _gameManager = GameManager.instance;
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Game")
        {
             link = other.GetComponent<DetectGameDesc>().scriptable.m_linkWeb;
            /*Application.OpenURL(link);*/
            SOLaPresentationDuJeu ScriptableJeu = other.GetComponent<DetectGameDesc>().scriptable;
            _gameManager.jeu = ScriptableJeu.m_jeu;
        if (ScriptableJeu.m_jeu == GameManager.e_jeu.Ebony)
            {
                Ebony();
            }
            if (ScriptableJeu.m_jeu == GameManager.e_jeu.OnlyLoneWay)
            {
                OnlyLoneWay();
            }
            if (ScriptableJeu.m_jeu == GameManager.e_jeu.FranxPrix)
            {
                FranxPrix();
            }
            if (ScriptableJeu.m_jeu == GameManager.e_jeu.ShadowBound)
            {
                ShadowBound();
            }

        }
        
    }

    private void Ebony()
    {
        _gameManager.InCombat = true;
        _gameManager.AnimatorFade.SetTrigger("Fade");
    }
    private void OnlyLoneWay()
    {
        Application.OpenURL(link);
    }
    private void FranxPrix()
    {
        Application.OpenURL(link);
    }
    private void ShadowBound()
    {
        _gameManager.InCombat = true;
        _gameManager.AnimatorCamera.SetBool("ShouldZoomShadowBound", true);
        _gameManager.AnimatorCartes.SetBool("ShouldShow",true);
    }
    public void BouttonAttaque()
    {
        Application.OpenURL(link);
        BouttonFuir();
    }
    public void BouttonFuir()
    {
        print("Fuir");
        
        _gameManager.AnimatorFade.SetTrigger("FadeBack");
    }
}
