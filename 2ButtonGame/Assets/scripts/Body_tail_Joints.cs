using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_tail_Joints : MonoBehaviour {

    public Eating_script eating;
    public GameObject header;
	public GameObject tailSecionPrefab;
    public Transform lastSection;
    public List<GameObject> tail;
    public GameObject Explotion;
    public GameObject Explotion_dead;
    public GameObject fade;
    public GameObject dragon;
    public GameObject joint;
    [Range(0,4)]
    public int meterBar;
    public bool recentlyRemoved = false;

	// Use this for initialization
	void Start () {
        lastSection = this.transform;
        header = GameObject.FindGameObjectWithTag("Head");
        eating = header.GetComponent<Eating_script> ();
        
	}

	public void AddJoint()
    {

        GameObject temp_pref = Instantiate(tailSecionPrefab,lastSection.position,Quaternion.Euler(0,0,0)) as GameObject;
        Body_tail tempTail = temp_pref.GetComponent<Body_tail> ();
        tempTail.setTarget(lastSection.transform);
        tail.Add(temp_pref);

        lastSection = temp_pref.transform;

        eating.Eat();

        if (tail.Count>= 0 && tail.Count <=4){
            tempTail.accuracy = 1.5f;
        } else if (tail.Count >=5){
            tempTail.accuracy =1f;
        }
    }
    public void RemoveJoint()
    {
        if (tail.Count > 0)
        {
            Instantiate(Explotion,tail[tail.Count-1].transform.position,Quaternion.identity);
            Destroy(tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
            if (tail.Count >= 1){
                lastSection = tail[tail.Count - 1].transform;
            }else if (tail.Count <= 0){
                lastSection = this.transform;
            }
            
            StartCoroutine(jointRemoved());
        }
        else
        {
            dragon.SetActive(false);
            Instantiate(Explotion_dead,transform.position, Quaternion.identity);
            fade.SetActive(true);

            joint.SetActive(false);

        }
    

    }

    IEnumerator jointRemoved ()
    {
        recentlyRemoved = true;
        yield return new WaitForSeconds(.5f);
        recentlyRemoved = false;
        StopCoroutine(jointRemoved());
    }
}
