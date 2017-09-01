using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour {

    public AudioClip point;
	public AudioClip wing;
    public AudioSource die;
    public AudioSource hit;

    public Sprite[] postures;
    public GameObject tubePrefab;
    public GameObject score;
    public LevelManager levelManager;
    List<GameObject> tubes = new List<GameObject>();
    int frames = 0;

	// Use this for initialization
	void Start () {
        Score.score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Rigidbody2D bird = GetComponent<Rigidbody2D>();
        if (bird.velocity.y > 0.5f){
            GetComponent<SpriteRenderer>().sprite=postures[2]; //flying;
        }
        else if (bird.velocity.y < -0.5f){
            GetComponent<SpriteRenderer>().sprite = postures[1]; //falling
        }
        else{
            GetComponent<SpriteRenderer>().sprite = postures[0]; //normal
        }
        if(Input.GetKeyDown(KeyCode.Space)||Input.GetMouseButton(0)){
            bird.velocity = new Vector2(0f, 7f);
            AudioSource.PlayClipAtPoint(wing, transform.position);
        }
        frames++;
        for (int i = 0; i < tubes.Count;i+=3){
            Vector3 newPosition = new Vector3(tubes[i].transform.position.x - 0.07f, tubes[i].transform.position.y, tubes[i].transform.position.z);
            tubes[i].transform.position = newPosition;
            newPosition.y = tubes[i + 1].transform.position.y;
            tubes[i + 1].transform.position = newPosition;
            newPosition.y = tubes[i + 2].transform.position.y;
            tubes[i + 2].transform.position = newPosition;
        }
        if (frames%70==0){
            float y = Random.Range(2.5f, 7.5f);
            GameObject temp=Instantiate(tubePrefab,new Vector3(4,y,0),new Quaternion());
            tubes.Add(temp);
            temp = Instantiate(tubePrefab, new Vector3(4f, y - 11.5f, 0f), new Quaternion());
            temp.transform.Rotate(new Vector3(0,0,180));
            tubes.Add(temp);
            temp = Instantiate(score, new Vector3(4f, y - 5.75f, 0f), new Quaternion());
            tubes.Add(temp);
        }
        RemoveInvisible();
	}

    private void OnTriggerExit2D(Collider2D collision)
    {
        Score.score++;
        AudioSource.PlayClipAtPoint(point, transform.position);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.ToString().Contains("tube"))
        {
            hit.Play();
        }
        else
        {
            die.Play();
        }
        levelManager.LoadLevel("Lose");
    }

    void RemoveInvisible(){
        for (int i = 0; i != tubes.Count;i++){
            if (tubes[i].transform.position.x < -4f){
                Destroy(tubes[i]);
                tubes.Remove(tubes[i]);
                i--;
            }
        }
    }
}
