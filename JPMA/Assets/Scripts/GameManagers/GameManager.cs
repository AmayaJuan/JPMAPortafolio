using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager gm;
    public static bool inGame;
    public Text timeText;
    public GameObject ready;

    float currentTime = 300f;
    Walu walu;

    void Awake()
    {
        if (gm == null)
            gm = this;
        else if (gm != this)
            Destroy(gameObject);

        walu = FindObjectOfType<Walu>();
    }

    void Start()
    {
        StartCoroutine(StartGame());
    }

	void Update ()
    {
        if (inGame)
        {
            if (currentTime > 0)
                currentTime -= Time.deltaTime;

            if (currentTime == 0)
            {
                inGame = false;
                Debug.Break();
            }
            if (currentTime <= 30)
            {
                if (Mathf.RoundToInt(currentTime) % 2 == 0)
                    timeText.color = new Color(1, 0, 0, 1);
                else
                    timeText.color = new Color(1, 0, 0, .2f);
            }

            timeText.text = currentTime.ToString("f0");
        }
    }

    public IEnumerator StartGame()
    {
        yield return new WaitForSeconds(3);
        ready.SetActive(false);
        inGame = true;
    }
}
