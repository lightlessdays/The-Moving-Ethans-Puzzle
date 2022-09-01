using System.Collections.Generic;
using UnityEngine;

/*
 * Variables *
 *      dnaLength -> the number of genes in this dna.
 *      maxValue -> the number of values a particular gene can hold.
 *      genes -> list of all genes. the length of this list is dnaLength and the maximum value of particular number in this list is maxValue-1.
 */

/*
 * Methods *
 *      SetRandom() -> the setRandom method randomly assigns the values of genes in the genes list.
 *      SetInt() -> this method is used to set a hardcoded value at a particular position in genes list.
 *      GetGene() -> this method returns the gene at a particular position in the genes list.
 *      Combine() -> this takes in two genes and combines them to form an offspring.
 *      Mutate() -> this randomly produces a completely new offspring, not based on any parent.
 */

/*
 * Constructors *
 * This class has one public constructor that takes in two arguments-
 *      l -> dnaLength
 *      v -> maxValues
 */
public class DNA {

	List<int> genes = new List<int>();
	int dnaLength = 0;
	int maxValues = 0;

	public DNA(int l, int v)
	{
		dnaLength = l;
		maxValues = v;
		SetRandom();
	}

	public void SetRandom()
	{
		genes.Clear();
		for(int i = 0; i < dnaLength; i++)
		{
			genes.Add(Random.Range(0, maxValues));
		}
	}

	public void SetInt(int pos, int value)
	{
		genes[pos] = value;
	}

	public void Combine(DNA d1, DNA d2)
	{
		for(int i = 0; i < dnaLength; i++)
		{
			genes[i] = (Random.Range(5, 10) > 5) ? d1.genes[i] : d2.genes[i];
			/*
			if(i < dnaLength/2.0)
			{
				int c = d1.genes[i];
				genes[i] = c;
			}
			else
			{
				int c = d2.genes[i]; 
				genes[i] = c;
			}
			*/
		}
	}

	public void Mutate()
	{
		genes[Random.Range(0,dnaLength)] = Random.Range(0, maxValues);
	}

	public int GetGene(int pos)
	{
		return genes[pos];
	}

}
