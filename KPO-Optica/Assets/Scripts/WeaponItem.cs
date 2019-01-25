using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponItem : MonoBehaviour {

    private Transform playerPos;
    public GameObject equip;
    private Transform player;
    private static GameObject Tool;
    private static bool created;

    private void Start()
    {
        //playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        playerPos = GameObject.Find("Arm Right").transform;
    }

    public void Use() {
        if (created == false) {
            //Cast Instantiate naar Gameobjects
            Tool = Instantiate(equip, playerPos.position, equip.transform.rotation, playerPos.transform);
            created = true;
            gameObject.GetComponent<Image>().color = new Color32(173, 173, 173, 255);
        } else {
            //Spawn het item bij de speler (Tool)
            if (Tool != null) {
                //Verwijder de 2 aangemaakte clones
                Destroy(Tool);
                gameObject.GetComponent<Image>().color = new Color32(255, 255, 225, 225);
                created = false;
            } else {
                created = false;
            }
        }
    }
}
