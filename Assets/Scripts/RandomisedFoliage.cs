using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomisedFoliage : MonoBehaviour
{
    [SerializeField] private Vector2 area;
    [SerializeField] private float height = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            float x = Random.Range(-area.x, area.x);
            float z = Random.Range(-area.y, area.y);
            RaycastHit hit;
            Physics.Raycast(transform.position + new Vector3(x, height, z), -Vector3.up, out hit, float.PositiveInfinity, 1 << 3);
            Transform child = transform.GetChild(i);
            child.position = hit.point + child.localPosition.y * Vector3.up;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }
    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position + height * Vector3.up, new Vector3(area.x, .01f, area.y));
    }
}
