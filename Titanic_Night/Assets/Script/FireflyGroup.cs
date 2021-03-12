using UnityEngine;

public class FireflyGroup : MonoBehaviour
{

    public GameObject[] fireflys;
    public float maxLightIntensity = 50f;

    void Start()
    {
    }

    void Update()
    {
        Vector3 rotationAngle = new Vector3(0, Random.Range(0.2f, 0.8f), 0);
        this.transform.Rotate(rotationAngle);

        for (int index = 0; index < this.fireflys.Length; index++) {
            GameObject aFly = this.fireflys[index];
            flickering(aFly);
        }
    }


    private void flickering(GameObject fly) {
        Light light = (Light)(fly.GetComponent("Light"));
        float randomNumber = Random.Range(0.2f, 1.2f);
        light.intensity = this.maxLightIntensity * randomNumber;
        light.range = randomNumber;
    }


}
