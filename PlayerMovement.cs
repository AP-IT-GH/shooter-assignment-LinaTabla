using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMovement : MonoBehaviour
{
    public float xSpeed = 10f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = CrossPlatformInputManager.GetAxis("Horizontal");
        float xOffset = horizontal * Time.deltaTime * xSpeed;
        float xNewPos = xOffset + transform.localPosition.x;
        transform.localPosition = new Vector3(Mathf.Clamp(xNewPos, -10, 10), transform.localPosition.y, transform.localPosition.z);
    }
}
