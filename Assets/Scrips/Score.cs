using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    public Sprite[] digits;
    public static int score;
    public int digit;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if(digit==0){
            GetComponent<SpriteRenderer>().sprite=digits[score%10];
        }else if(digit==1){
            if(score>9){
                GetComponent<SpriteRenderer>().sprite = digits[(score/10) % 10];
            }
		}
		else if (digit == 2)
		{
			if (score > 99)
			{
				GetComponent<SpriteRenderer>().sprite = digits[(score / 100) % 10];
			}
		}
	}
}
