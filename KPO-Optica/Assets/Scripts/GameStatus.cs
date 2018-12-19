using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour {

    //eenmalig voor elke deur te openen per level
    public bool AccesLevel { get; set; }

    //Vastleggen welke levels behaald zijn (overworld & storybook)
    public bool Castle1 { get; set; }
    public bool Castle2 { get; set; }
    public bool Castle3 { get; set; }
    public bool Castle4 { get; set; }
    public bool Castle5 { get; set; }
    }
