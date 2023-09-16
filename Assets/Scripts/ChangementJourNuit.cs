using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;
using RenderSettings = UnityEngine.RenderSettings;

public class ChangementJourNuit : MonoBehaviour
{

    public Material mat;
    public Light lumiere;
    public Color couleur;

    private void OnTriggerEnter(Collider other)
    {
        RenderSettings.skybox = mat;
        lumiere.color = couleur;
    }
}
