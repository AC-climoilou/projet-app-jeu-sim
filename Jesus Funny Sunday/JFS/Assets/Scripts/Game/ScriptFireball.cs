using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptFireball : MonoBehaviour
{
    [SerializeField]
    private float minIntensite;


    [SerializeField]
    private float maxIntensite;

    [SerializeField]
    private float vitesse;

    [SerializeField]
    private float currentIntensite;

    bool intensiteMonte;

    Material mat;

    Sprite sprite;

    

    public void Start()
    {
        mat = GetComponent<MeshRenderer>().material;

        //L'intensite est la valeur a distance egal du minimum et du maximum
        currentIntensite = (minIntensite + maxIntensite) / 2;

        intensiteMonte = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (intensiteMonte)
        {
            currentIntensite += Time.deltaTime * vitesse;
            if (currentIntensite > maxIntensite)
            { 
                intensiteMonte = false; 
            }
        }
        else if (!intensiteMonte)
        {
            currentIntensite -= Time.deltaTime * vitesse;
            if (currentIntensite < minIntensite)
            {
                intensiteMonte = true;
            }
        }
        mat.SetFloat("_intensity", currentIntensite);
    }
}
