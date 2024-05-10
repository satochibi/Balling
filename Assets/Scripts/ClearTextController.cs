using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;


public class ClearTextController : MonoBehaviour
{
    [SerializeField] UIDocument uiDoc;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        GameObject[] whitePins = GameObject.FindGameObjectsWithTag("WhitePinTag");
        GameObject[] bluePins = GameObject.FindGameObjectsWithTag("BluePinTag");
        GameObject[] redPins = GameObject.FindGameObjectsWithTag("RedPinTag");

        if (whitePins.Length == 0 && bluePins.Length == 0 && redPins.Length == 0)
        {

            var label = uiDoc.rootVisualElement.Q<Label>("ClearLabel");

            label.text = "GameClear!!" + "\n" + "TotalScore: " +
                GameObject.Find("GameManager").GetComponent<GameManagerController>().GetTotalScore();
            if (Input.GetMouseButton(0))
            {
                SceneManager.LoadScene("GameScene");

            }

        }
    }
}
