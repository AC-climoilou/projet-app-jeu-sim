using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScript : MonoBehaviour
{
    public GameObject background;
    public GameObject camera;
    private Transform tr;
    // Start is called before the first frame update
    void Start()
    {
        tr = camera.GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        background.transform.position = new Vector3(tr.position.x, tr.position.y+4.9f, 0.50f);
    }
}
