using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;

public class DataController : MonoBehaviour
{
    public RoundData[] allRoundData;
	private int SceneNumber;

    // Use this for initialization
    void Start()
    {
        DontDestroyOnLoad(gameObject);
    }

	void Update()
	{

	}
    public RoundData GetCurrentRoundData()
    {
		Scene scene = SceneManager.GetActiveScene();
		string GetButtonNumber = scene.name.Substring(6);
		Int32.TryParse(GetButtonNumber, out SceneNumber);
		Debug.Log(SceneNumber);
		return allRoundData[SceneNumber];
    }

}