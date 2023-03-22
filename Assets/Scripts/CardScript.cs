/*
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardScript : MonoBehaviour{
    // no card is allowed to be flipped
    public static bool DO_NOT = false;
    [SerializeField]
    private int _state;
    [SerializeField]
    private int _cardValue;
    [SerializeField]
    private bool _initialized = false;
    Sprite cardBack;
    Sprite cardFront;
    private GameObject gameManager;

    void Start(){
        _state = 0;
        gameManager = GameObject.FindGameObjectWithTag("Manager");
    }

    public void flipCard(){
        if (_state == 0)
            _state = 1;
        if (_state == 1)
            _state = 0;

        //check if card is showing its back(1) or front(0)
        if (_state == 0 && !DO_NOT)
            gameManager.GetComponent<Image>().sprite = cardBack;
        else if (_state == 1 && !DO_NOT) 
            gameManager.GetComponent<Image>().sprite = cardFront;
    }

    public int cardValue{
        get => _cardValue; 
        set => _cardValue = value; 
    }

    //get or set state value
    public int state{
        get => _state;
        set => _state = value;
    }

    //get or set @initialized
    public bool initialized{
        get {return _initialized;}
        set {_initialized = value;}
    }

    // initializing all Graphics
    public void setGraphics(){
        cardBack = gameManager.GetComponent<GameManager>().getCardBack();
        cardFront = gameManager.GetComponent<GameManager>().getCardFront(_cardValue);

        flipCard();
    }

    public void checkWindowForMatch(){
        StartCoroutine(pause());
    }
    IEnumerator pause(){
        yield return new WaitForSeconds(1);
        //no match (_state = 0)
        if (_state == 0)
            GetComponent<Image>().sprite = cardBack;
        // match (_state = 1)
        else if (_state == 1)
            GetComponent<Image>().sprite = cardFront;
        DO_NOT = false;
    }
}
*/
