using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponItem : MonoBehaviour {

    private Transform playerPos;
    public GameObject equip;
    public GameObject LightOrShadow;
    private Transform player;
    private static GameObject Tool;
    private static GameObject Light;
    private static bool created;
    private void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
    }

    public void Use() {
        if (created == false) {
            //Cast Instantiate naar Gameobjects
            Tool = Instantiate(equip, playerPos.position, equip.transform.rotation, playerPos.transform);
            Light = Instantiate(LightOrShadow, playerPos.position, LightOrShadow.transform.rotation, playerPos.transform);
            created = true;
            //Verwijder item inventaris slot
            Destroy(gameObject);
        } else {
            //Spawn het item bij de speler (Tool)
            if (Tool != null) {
                Instantiate(Tool, playerPos.position, Quaternion.identity);
                //Verwijder de 2 aangemaakte clones
                Destroy(Tool);
                Destroy(Light);
                created = false;
            } else {
                created = false;
            }
        }
    }
}
