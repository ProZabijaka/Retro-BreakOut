using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float minHorizontal = 1f;
    [SerializeField] float maxHorizontal = 15f;
    [SerializeField] float ScreenWidthInUnits = 16f;
    float MousePosInUnits;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        MousePosInUnits = (Input.mousePosition.x / Screen.width * ScreenWidthInUnits);
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(MousePosInUnits,minHorizontal,maxHorizontal);
        transform.position = paddlePos;
    }
}
