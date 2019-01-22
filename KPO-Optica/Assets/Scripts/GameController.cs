using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class GameController : MonoBehaviour
{


    public Text questionDisplayText;
    public Text scoreDisplayText;
    public Text timeRemainingDisplayText;
    public SimpleObjectPool answerButtonObjectPool;
    public Transform answerButtonParent;
    public GameObject questionDisplay;
	public GameObject RoundFailDisplay;
	public GameObject RoundWinDisplay;
	public GameObject UIDisplay;
	public GameObject Key;

    private DataController dataController;
    private RoundData currentRoundData;
    private QuestionData[] questionPool;
	private Transform player;

	private bool isRoundActive;
    private float timeRemaining;
    private int questionIndex;
    private int playerScore;
    private List<GameObject> answerButtonGameObjects = new List<GameObject>();

    // Use this for initialization
    void Start()
    {
		player = GameObject.FindGameObjectWithTag("Player").transform;
		dataController = FindObjectOfType<DataController>();
		currentRoundData = dataController.GetCurrentRoundData();
		questionPool = currentRoundData.questions;
        timeRemaining = currentRoundData.timeLimitInSeconds;
        UpdateTimeRemainingDisplay();

        playerScore = 0;
        questionIndex = 0;

        ShowQuestion();
        isRoundActive = true;

    }

    private void ShowQuestion()
    {
        RemoveAnswerButtons();
        QuestionData questionData = questionPool[questionIndex];
        questionDisplayText.text = questionData.questionText;

        for (int i = 0; i < questionData.answers.Length; i++)
        {
            GameObject answerButtonGameObject = answerButtonObjectPool.GetObject();
            answerButtonGameObjects.Add(answerButtonGameObject);
            answerButtonGameObject.transform.SetParent(answerButtonParent);

            AnswerButton answerButton = answerButtonGameObject.GetComponent<AnswerButton>();
            answerButton.Setup(questionData.answers[i]);
        }
    }

    private void RemoveAnswerButtons()
    {
        while (answerButtonGameObjects.Count > 0)
        {
            answerButtonObjectPool.ReturnObject(answerButtonGameObjects[0]);
            answerButtonGameObjects.RemoveAt(0);
        }
    }

    public void AnswerButtonClicked(bool isCorrect)
    {
        if (isCorrect)
        {
            playerScore += currentRoundData.pointsAddedForCorrectAnswer;
			scoreDisplayText.text = "Aantal goed: " + playerScore.ToString();
		}

		if (questionPool.Length > questionIndex + 1)
        {
            questionIndex++;
            ShowQuestion();
        }
        else
        {
		EndRound();

        }

    }

    public void EndRound()
    {

		if (questionPool.Length == playerScore)
		{
			RoundWinDisplay.SetActive(true);
			isRoundActive = false;
			UIDisplay.SetActive(false);
			Instantiate(Key, player.transform.position, Quaternion.identity); // spawn the button so that the player can interact with it
			Invoke("HideScreen", 2f);
			

		}
		else
		{
			Debug.Log("fail");
            RoundFailDisplay.SetActive(true);
            isRoundActive = false;
            UIDisplay.SetActive(false);
			Invoke("ResetGame", 2f);
		}
    }

	public void HideScreen()
	{
		RoundWinDisplay.SetActive(false);
		questionDisplay.SetActive(false);
	}

	public void ResetGame()
	{
        RoundFailDisplay.SetActive(false);
        questionDisplay.SetActive(false);
        DestroyAll("Flashlight");
        DestroyAll("Torch");
        Scene scene = SceneManager.GetActiveScene();
        SceneManager.LoadScene(scene.name);
    }

    private void UpdateTimeRemainingDisplay()
    {
        timeRemainingDisplayText.text = "Tijd: " + Mathf.Round(timeRemaining).ToString();
    }

    void DestroyAll(string tag) {
        GameObject[] item = GameObject.FindGameObjectsWithTag(tag);
        for (int i = 0; i < item.Length; i++) {
            Destroy(item[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
		if (isRoundActive)
        {
            timeRemaining -= Time.deltaTime;
            UpdateTimeRemainingDisplay();

            if (timeRemaining <= 0f)
            {
                EndRound();
            }

        }
    }
}
