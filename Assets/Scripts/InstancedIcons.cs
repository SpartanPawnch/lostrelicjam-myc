using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstancedIcons : MonoBehaviour
{
    [SerializeField] private GameState gameState;
    [SerializeField] private GameObject target;
    [SerializeField] private int count = 9;
    [SerializeField] private int lineLength = 5;
    private List<CanvasRenderer> copies = new List<CanvasRenderer>();
    // Start is called before the first frame update
    void Start()
    {
        RectTransform rectTransform = target.GetComponent<RectTransform>();
        float stepSizeX = rectTransform.rect.width * rectTransform.localScale.x;
        float stepSizeY = rectTransform.rect.height * rectTransform.localScale.y;

        copies.Add(target.GetComponent<CanvasRenderer>());
        for (int i = 1; i < count; i++)
        {
            float offsetX = stepSizeX * (i % lineLength);
            float offsetY = stepSizeY * (i / lineLength);
            GameObject obj = Instantiate(target);
            obj.transform.SetParent(gameObject.transform);
            obj.transform.position = target.transform.position - new Vector3(offsetX, offsetY, .0f);
            copies.Add(obj.GetComponent<CanvasRenderer>());
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < copies.Count; i++)
        {
            if (i < gameState.plantedCount)
                copies[i].SetColor(Color.white);
            else if (i == gameState.plantedCount && gameState.MushroomsHeld > 0)
                copies[i].SetColor(Color.green);
            else
                copies[i].SetColor(new Color(.2f, .2f, .2f, 1.0f));
        }
    }
}
