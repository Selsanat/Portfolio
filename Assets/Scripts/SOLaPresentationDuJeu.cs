using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.Video;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/InfosJeuPresentation", order = 1)]
public class SOLaPresentationDuJeu : ScriptableObject
{
    
    public GameManager.e_jeu m_jeu;
    public string m_gameName;
    public string m_Periode;
    public bool m_isOnPC;
    public string m_length;
    public string m_numberOfPeopleInvolved;
    public bool m_UnityUsed;
    public string m_miscDesc;
    public string m_VideoClip;
    public string m_linkWeb;
}

