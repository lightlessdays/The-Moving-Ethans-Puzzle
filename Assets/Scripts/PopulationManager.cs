using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class PopulationManager : MonoBehaviour {

	public GameObject botPrefab;
	public int populationSize = 50;
	List<GameObject> population = new List<GameObject>();
	public static float elapsed = 0;
	public float trialTime = 5;
	int generation = 1;

	GUIStyle guiStyle = new GUIStyle();
	void OnGUI()
	{
		guiStyle.fontSize = 25;
		guiStyle.normal.textColor = Color.black;
		GUI.BeginGroup (new Rect (10, 10, 250, 150));
		GUI.Label(new Rect (10,0,200,30), "Gen: " + generation, guiStyle);
		GUI.Label(new Rect (10,25,200,30), string.Format("Time: {0:0.00}",elapsed), guiStyle);
		GUI.Label(new Rect (10,50,200,30), "Population: " + population.Count, guiStyle);
		GUI.EndGroup ();
	}


	// Use this for initialization
	void Start () {
		for(int i = 0; i < populationSize; i++)
		{
			Vector3 startingPos = new Vector3(this.transform.position.x + Random.Range(-2,2),
												this.transform.position.y,
												this.transform.position.z + Random.Range(-2,2));

			GameObject b = Instantiate(botPrefab, startingPos, this.transform.rotation);
			b.GetComponent<Brain>().Init();
			population.Add(b);
		}
	}


	/*
	 * Breed Method takes in two parents and instantiates a bot based on their dna using the combine method.
	 */
	GameObject Breed(GameObject parent1, GameObject parent2)
	{
		Vector3 startingPos = new Vector3(this.transform.position.x + Random.Range(-2,2),
												this.transform.position.y,
												this.transform.position.z + Random.Range(-2,2));
		GameObject offspring = Instantiate(botPrefab, startingPos, this.transform.rotation);
		Brain b = offspring.GetComponent<Brain>();
		
			b.Init();
			b.dna.Combine(parent1.GetComponent<Brain>().dna,parent2.GetComponent<Brain>().dna);
		return offspring;
	}

	/*
	 * This is to create a new generation. It uses the usual genetic algorithm. Sort the list from least fittest to most fittest and then breed the fittest ones and discard the less fit ones.
	 */
	void BreedNewPopulation()
	{
		List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<Brain>().distanceTravelled).ToList();
		
		population.Clear();
		for (int i = (int) (sortedList.Count / 2.0f) - 1; i < sortedList.Count - 1; i++)
		{
    		population.Add(Breed(sortedList[i], sortedList[i + 1]));
    		population.Add(Breed(sortedList[i + 1], sortedList[i]));
		}
		//destroy all parents and previous population
		for(int i = 0; i < sortedList.Count; i++)
		{
			Destroy(sortedList[i]);
		}
		generation++;
	}
	
	// Update is called once per frame
	void Update () {
		elapsed += Time.deltaTime;
		if(elapsed >= trialTime)
		{
			BreedNewPopulation();
			elapsed = 0;
		}
	}
}

