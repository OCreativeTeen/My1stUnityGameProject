using UnityEngine;
using System.Collections;

public class AnimationScript : MonoBehaviour {

    public bool isAnimated = true;

    public bool isRotating = true;
    public bool isFloating = true;
    public bool isScaling = false;

    public Vector3 rotationAngle = new Vector3(0,90,0);
    public float rotationSpeed = 0.5f;

    public float floatSpeed = 0.04f;
    public float floatRate = 0.5f;

    private bool goingUp = true;
    private float floatTimer;
   
    public Vector3 startScale = new Vector3(0.5f, 0.5f, 0.5f);
    public Vector3 endScale = new Vector3(1f, 1f, 1f);

    private bool scalingUp = true;
    public float scaleSpeed = 1;
    public float scaleRate = 0.5f;
    private float scaleTimer;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
        if (isAnimated) {
            if (isRotating) {
                transform.Rotate(rotationAngle * rotationSpeed * Time.deltaTime);
            }
            if (isFloating) {
                floatTimer += Time.deltaTime;
                Vector3 moveDir = new Vector3(0.0f, 0.0f, floatSpeed);
                transform.Translate(moveDir);

                if (goingUp && floatTimer >= floatRate) {
                    goingUp = false;
                    floatTimer = 0;
                    floatSpeed = -floatSpeed;
                }
                else if(!goingUp && floatTimer >= floatRate) {
                    goingUp = true;
                    floatTimer = 0;
                    floatSpeed = +floatSpeed;
                }
            }
            if(isScaling) {
                scaleTimer += Time.deltaTime;
                if (scalingUp) {
                    transform.localScale = Vector3.Lerp(transform.localScale, endScale, scaleSpeed * Time.deltaTime);
                }
                else if (!scalingUp) {
                    transform.localScale = Vector3.Lerp(transform.localScale, startScale, scaleSpeed * Time.deltaTime);
                }
                if(scaleTimer >= scaleRate) {
                    if (scalingUp) { scalingUp = false; }
                    else if (!scalingUp) { scalingUp = true; }
                    scaleTimer = 0;
                }
            }
        }
	}
}
