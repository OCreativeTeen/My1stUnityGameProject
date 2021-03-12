using System.Collections.Generic;
using UnityEngine;

public class GrowingFireflyGroup : MonoBehaviour
{

    public float maxLightIntensity = 100f;
    public int maxnumber = 30;
    public GameObject firstFirefly;
    public GameObject growingArea;

    private List<GameObject> fireflies = new List<GameObject>();


    void Start()
    {
    }


    void Update()
    {
        if (fireflies.Count < maxnumber) {
            GameObject newFirefly = growAFirefly();
            this.fireflies.Add(newFirefly);
        }
    }


    private GameObject growAFirefly() {
        GameObject newFirefly = Instantiate(this.firstFirefly);
        newFirefly.transform.parent = this.transform;

        Vector3 growingAreaScale = this.growingArea.transform.localScale;
        Vector3 delta = new Vector3(growingAreaScale.x * Random.Range(-0.4f, 0.4f),
                                      growingAreaScale.y * Random.Range(-0.4f, 0.4f),
                                      growingAreaScale.z * Random.Range(-0.4f, 0.4f));
        newFirefly.transform.position = this.growingArea.transform.position + delta;

        return newFirefly;
    }

    private void flickering(GameObject fly) {
        Light light = (Light)(fly.GetComponent("Light"));
        float randomNumber = Random.Range(0.1f, 1.2f);
        light.intensity = this.maxLightIntensity * randomNumber;
        light.range = randomNumber;
    }

    private void rotating(GameObject fly) {
        fly.transform.RotateAround(growingArea.transform.position, Vector3.up, Random.Range(1f,10f)*Time.deltaTime);
    }


}
