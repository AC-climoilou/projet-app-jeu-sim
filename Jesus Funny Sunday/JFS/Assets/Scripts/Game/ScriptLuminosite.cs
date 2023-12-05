using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptLuminosite : MonoBehaviour
{
    //0 a 1 control le canal alpha
    private float opacite;

    [SerializeField]
    private float vitesse;

    private bool fading;

    private Material materiel;



    // Start is called before the first frame update
    void Start()
    {
        fading = false;
        opacite = 0;
        materiel = GetComponent<MeshRenderer>().material;
    }

    // Update is called once per frame
    void Update()
    {
        if (fading == true)
        {
            opacite += Time.deltaTime * vitesse;
            materiel.SetFloat("_opacite", opacite);
            if (opacite > 1)
            {
                fading = false;
            }
        }
    }

    public void FadeToBlack() 
    {
        fading = true;
    }
}
