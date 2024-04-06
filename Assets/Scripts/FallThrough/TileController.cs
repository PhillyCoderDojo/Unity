using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TileController : MonoBehaviour
{
    public Material startColour;
    Renderer rend;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        rend.sharedMaterial = startColour;
    }
}