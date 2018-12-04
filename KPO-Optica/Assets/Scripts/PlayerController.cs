using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float speed = 10f;
    private Vector3 target;

    void Start() {
        target = transform.position;
    }

    void Update() {
        //Bekijk of de speler de muis heeft ingedrukt en of er geen gameobject in de weg staat tijdens het klikken
        if (Input.GetMouseButton(0) && !UnityEngine.EventSystems.EventSystem.current.IsPointerOverGameObject()) {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            target.z = transform.position.z;
        }
        transform.position = Vector3.MoveTowards(transform.position, target, speed * Time.deltaTime);
    }
}