using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using static UnityEngine.Rendering.DebugUI;

public class DialogueDebut : MonoBehaviour
{
    [SerializeField] private TMP_Text m_Text;
    [SerializeField] private string[] ListeTexts;
    private Animator m_Animator;
    void Start()
    {
        m_Text.text = string.Empty;
        m_Animator = GetComponent<Animator>();
        m_Animator.Play("FadeIn");
    }

    void grotest()
    {
        StartCoroutine(EcritTextes(ListeTexts));
    }
    IEnumerator EcritTextes(string[] textes)
    {
        foreach(string texte in textes)
        {
            yield return EcritTexte(texte);
            for(int i = 0; i < 4; i++)
            {
                if(i%2 == 0)
                {
                    m_Text.text += "_";
                }
                else
                {
                    m_Text.text= m_Text.text.Remove(m_Text.text.Length-1);
                }
                yield return new WaitForSeconds(0.5f);
            }
            for(int i = 0; i<texte.Length; i++)
            {
                m_Text.text = m_Text.text.Remove(m_Text.text.Length - 1);
                yield return new WaitForSeconds(.0025f);
            }
            yield return new WaitForSeconds(.5f);
        }
        m_Animator.Play("FadeOut");
    }
    IEnumerator EcritTexte(string texte)
    {
        foreach (char letter in texte)
        {
            m_Text.text += letter;
            yield return new WaitForSeconds(.025f);
        }
    }
}
