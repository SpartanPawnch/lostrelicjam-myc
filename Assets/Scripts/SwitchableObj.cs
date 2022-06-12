using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Sprites;
public class SwitchableObj : MonoBehaviour
{
    [SerializeField] private MeshRenderer mesh3d;
    [SerializeField] private SpriteRenderer sprite2d;

    [SerializeField] private GameObject character;
    [SerializeField] private GameState gameState;
    private bool use3d = false;

    // Start is called before the first frame update
    void Start()
    {
        mesh3d.enabled = use3d;
        sprite2d.enabled = !use3d;
    }

    // Update is called once per frame
    void Update()
    {
        use3d = !gameState.inTopdown;
        mesh3d.enabled = use3d;
        sprite2d.enabled = !use3d;
    }

    void SwitchDisplay()
    {
        use3d = !use3d;
        mesh3d.enabled = use3d;
        sprite2d.enabled = !use3d;
    }

    // Collect the mushroom when the player makes contact
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == character)
        {
            gameState.MushroomsHeld++;
            GameObject.Destroy(this.gameObject);
        }
    }
}
