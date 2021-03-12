using UnityEngine;


class Ship : MonoBehaviour {

    public string shipName = "TITANIC";

    public int shipBuildYear = 1911;

    public float rotateSpeed = 1.2f;

    public bool anchorOn = false;



    public GameObject center;



    void Awake() {
        Debug.Log("Ship (" + shipName + ") is just generated into the game");
    }


    void Start() {
        Debug.Log("Ship (" + shipName + ") is started to run in the game");
    }


    // Update is called every 0.04 second (around)
    void Update() {
        if (!anchorOn) {
            Vector3 line = new Vector3(0f, 1f, 0f);  // Can NOT say "this.line"
            RotateAround(line);
        }
    }


    void RotateAround(Vector3 line) {
        transform.RotateAround( this.center.transform.position, line, rotateSpeed*Time.deltaTime );
    }


}
