using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{

    public Sprite[] cardFace;
    public Sprite cardBack;
    public GameObject[] cards;
    public TextMeshProUGUI remainingText;

    private bool _init = false;
    private int _matches = 8;

    // Update is called once per frame
    void Update()
    {
        if (!_init)
            initializeCards();
        if (Input.GetMouseButtonUp(0))
            checkCards();
    }

    void initializeCards(){
        // cycle through all cards and assign each value twice (create a pair)
        for (int id = 0; id < 2; id++){
            // assign one of 8 different possible pictures
            for (int i = 1; i < 9; i++){

                bool test = false;
                int choice = 0;

                // find a not initialized card
                while (!test) {
                    choice = Random.Range(0, cards.Length);
                    test = !(cards[choice].GetComponent<Card>().initialized);
                }
                //assign picture i to it
                cards[choice].GetComponent<Card>().cardValue = i;
                cards[choice].GetComponent<Card>().initialized = true;
            }
        }
        foreach (GameObject card in cards)
            card.GetComponent<Card>().setupGraphics();
        
        if (!_init)
          _init = true;
    }

    void checkCards(){
        List<int> openCards = new List<int>();

        for ( int i = 0; i < cards.Length; i++){
            //if there is only one card facing up, add it to openCards
            if (cards[i].GetComponent<Card>().state == 1){
                openCards.Add(i);
            }
        }

        //if two cards are facing up, check if they show same picture
        if (openCards.Count==2){
            cardComparison (openCards);
        }
    }

    void cardComparison(List<int>openCards){
        // Disable all user actions until after comparison
        Card.GAME_INTERRUPTED = true;
        int state = 0;

        //check if open cards show the same picture
        if (cards[openCards[0]].GetComponent<Card>().cardValue == cards[openCards[1]].GetComponent<Card>().cardValue){
            state = 2; 
            _matches --;
            remainingText.text = "Remaining Pairs " + _matches;
            // all pairs found
            if (_matches == 0)
                SceneManager.LoadScene("Menu");
        }

        for (int i = 0; i < openCards.Count; i++){
            cards[openCards[i]].GetComponent<Card>().state = state;
            cards[openCards[i]].GetComponent<Card>().falseCheck();
        }
    }

    public Sprite getCardBack(){
        return cardBack;
    }

    public Sprite getCardFace(int i){
        return cardFace[i - 1];
    }
}