using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    //eenmalig voor elke deur te openen per level
    public bool AccesLevel { get; set; }

    //Vastleggen welke levels behaald zijn (overworld & storybook)
    public static bool Castle1; 
    public static bool Castle2;
    public static bool Castle3;
    public static bool Castle4;
    public static bool Castle5;
    }
