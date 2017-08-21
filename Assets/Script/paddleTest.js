#pragma strict

var ball: GameObject;

function Start() {
    ball.SetActive(true);
    Debug.Log("True");
}

function hideBall() {
    if (ball.SetActive) {
        Debug.Log("True");
        ball.SetActive(false);
    }
    else {
        Debug.Log("False");
        ball.SetActive(true);
    }
}