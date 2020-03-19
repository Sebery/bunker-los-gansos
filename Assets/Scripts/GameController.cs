using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Intro Components")]
    public GameObject introCanvas;
    public GameObject firstText;
    public GameObject continueText;
    public GameObject secondText;
    public GameObject continueText2;
    public GameObject thirdText;
    public GameObject continueText3;
    public GameObject fadeImage;
    public GameObject bgImage;
    public GameObject radioImage;
    public GameObject player;



    private void Start() {
        StartCoroutine(IntroPartOne());
    }

    public IEnumerator IntroPartOne() {
        firstText.SetActive(true);
        yield return new WaitForSeconds(3f);
        continueText.SetActive(true);
    }

    public void StartSecondPart() {
        firstText.SetActive(false);
        StartCoroutine(IntroPartTwo());
        continueText.SetActive(false);
    }

    public IEnumerator IntroPartTwo() {
        secondText.SetActive(true);
        yield return new WaitForSeconds(3f);
        continueText2.SetActive(true);
    }

    public void StartThirdPart() {
        secondText.SetActive(false);
        StartCoroutine(IntroPartThree());
        continueText2.SetActive(false);
    }

    public IEnumerator IntroPartThree() {
        thirdText.SetActive(true);
        yield return new WaitForSeconds(3f);
        continueText3.SetActive(true);
    }

    public void StartGame() {
        radioImage.SetActive(false);
        thirdText.SetActive(false);
        continueText3.SetActive(false);
        bgImage.SetActive(false);
        fadeImage.SetActive(true);
        player.SetActive(true);
    }

}
