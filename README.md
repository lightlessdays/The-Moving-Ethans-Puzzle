# The Moving Ethans Puzzle

Ethan is a pre-defined third person character in Unity that can perform numerous actions. In our gameplay, we will make the population of Ethans perform numerous actions randomly. These include:
1. Moving Forward
2. Moving Backward
3. Moving Left
4. Moving Right
5. Jumping
6. Crouching

Now, our goal is to design a genetic algorithm that will make a generation of Ethans travel the maximum distance on a strip by performing any one of the actions.

## Solution of the puzzle

Turns of the solution of the puzzle is genetic algorithm. We will create several generations of Ethans that will last 8 seconds each. In the end, we will have a generation with all Ethans peforming the same action. That would be our peak generation. Our first generation starts with all of the Ethans doing random actions.

![image](https://user-images.githubusercontent.com/97734029/187886477-c3830853-1363-4222-806c-2791d7e29675.png)

Some of them are moving forward, some of them are moving backwards, some right, while some left. Some are crouching and jumping on their spot. Each Ethan has a brain script attatched to him, which stores the distance travelled by each Ethan on the strip.

```
  distanceTravelled = Vector3.Distance(this.transform.position,startPosition);
```

Based on this distance travelled, we sort Ethans into a list.

```
  List<GameObject> sortedList = population.OrderBy(o => o.GetComponent<Brain>().distanceTravelled).ToList();
```

