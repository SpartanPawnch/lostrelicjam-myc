using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class SwitchableObj : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh3d;
    [SerializeField] private SpriteRenderer sprite2d;
    private bool use3d = true;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Swap"))
            SwitchDisplay();
    }

    void SwitchDisplay()
    {
        use3d = !use3d;
        mesh3d.enabled = use3d;
        sprite2d.enabled = !use3d;
    }
}
