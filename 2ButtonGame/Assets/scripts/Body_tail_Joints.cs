using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Body_tail_Joints : MonoBehaviour {

    public Eating_script eating;
    public GameObject header;
	public GameObject tailSecionPrefab;
    public Transform lastSection;
    public List<GameObject> tail;

	// Use this for initialization
	void Start () {
        lastSection = this.transform;
        header = GameObject.FindGameObjectWithTag("Head");
        eating = header.GetComponent<Eating_script> ();
	}
	
	public void AddJoint()
    {

        GameObject temp_pref = Instantiate(tailSecionPrefab,lastSection.position,Quaternion.Euler(0,0,0)) as GameObject;
        Tail tempTail = temp_pref.GetComponent<Tail> ();
        tempTail.setTarget(lastSection.transform);
        tail.Add(temp_pref);

        lastSection = temp_pref.transform;

        eating.Eat();

        
    }
    public void RemoveJoint()
    {
        if (tail.Count > 0)
        {
            Destroy(tail[tail.Count - 1]);
            tail.RemoveAt(tail.Count - 1);
            if (tail.Count >= 1){
                lastSection = tail[tail.Count - 1].transform;
            }else if (tail.Count <= 0){
                lastSection = this.transform;
            }
        }
        else
        {
            //game over, lose life etc.
            Debug.Log("Game over / lose life");
        }
    

    }
}
