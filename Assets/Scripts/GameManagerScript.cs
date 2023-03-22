/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class GameManager : MonoBehaviour
{
    public Sprite[] cardFront;
    public Sprite cardBack;
    public GameObject [] cards;
    public TextMeshProUGUI remainingMatchesText;
    private bool init = false;
    private int remainingMatches = 8;

    // Update is called once per frame
    void Update(){
        if (!init)
            initializeCards();
        if (Input.GetMouseButtonUp(0))
            checkCards();
    }

    void initializeCards(){
        // cycle through all cards and assign each value twice (create a pair)
        for (int id = 0; id < 2; id++ ){
            // assign one of 8 different possible pictures
            for (int i = 1; i < 9; i++ ) {
                bool test = false;
                int choice = 0;
                // find a not initialized card
                while (!test){
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<CardScript>().initialized);
                }
                //assign picture i to it
                cards[choice].GetComponent<CardScript>().cardValue = i;
                cards[choice].GetComponent<CardScript>().initialized = true;
            }
        }
        foreach (GameObject card in cards)
            card.GetComponent<CardScript>().setGraphics();
        if (!init)
            init = true;
    }

    void checkCards(){
        List<int> openCards = new List<int> ();

        for (int i = 0; i < cards.Length; i++ ){
            //if there is only one card facing up, add it to openCards
            if (cards[i].GetComponent<CardScript>().state == 1){
                openCards.Add(i);
            }
            //if two cards are facing up, check if they show same picture
            if (openCards.Count == 2)
                compareCards(openCards);
        }
    }

    void compareCards(List<int> openCards){
        // Disable all further user actions until after comparison
        CardScript.DO_NOT = true;
        int x = 0;
        //check if open cards show the same picture
        if (cards[openCards[0]].GetComponent<CardScript>().cardValue == cards[openCards[1]].GetComponent<CardScript>().cardValue) {
            x = 2; 
            remainingMatches --;
            remainingMatchesText.text = "RemainingMatches: " + remainingMatches;

            // all pairs found
            if(remainingMatches == 0)
                SceneManager.LoadScene("Menu");
        }

        for (int i = 0; i < openCards.Count; i ++){
            cards[openCards[i]].GetComponent<CardScript>().state = x;
            cards[openCards[i]].GetComponent<CardScript>().checkWindowForMatch();
        }
    }

    public Sprite getCardBack(){
        return cardBack;
    }

    public Sprite getCardFront(int i){
        return cardFront[i - 1];
    }


}
*/
