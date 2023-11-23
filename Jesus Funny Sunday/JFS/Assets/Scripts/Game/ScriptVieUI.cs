using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptVieUI : MonoBehaviour
{
    [SerializeField]
    private float lifeUnitSize;


    private float size = 0;


    public void addLife()
    {
        size += lifeUnitSize;
        gameObject.transform.localScale = new Vector2(size, 1);
    }

    public void instaKill()
    {
        gameObject.transform.localScale = new Vector2(0, 0);
    }
}
