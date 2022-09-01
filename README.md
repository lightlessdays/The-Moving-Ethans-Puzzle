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

We then discard half of the list and breed the remaining half. This algorithm will keep on producing offsprings of only the most desirable members of the generation. This would lead to a production of a generation of only most desirable members.

By the second generation, we can see that the members jumping and crouching on their spot decrease.

![Second Generation](https://user-images.githubusercontent.com/97734029/187888537-632671b6-2945-4f0a-9a99-9a87749eda8e.png)

By the third generation, we can observe that the members going backwards decrease.

![Third Generation](https://user-images.githubusercontent.com/97734029/187888830-79780198-2279-491b-9816-55824a678146.png)

By the fourth or fifth generation, we will have a population of the most desirable members- that only move forward... because moving forward will get them to cover the maximum distance on the strip.

![Fourth Generation](https://user-images.githubusercontent.com/97734029/187889109-fd62685e-a9e3-4e95-82ca-8fefeb28ca7c.png)

It must be noted that more the members, the less the number of generations required to reach the apex generation (or the generation with members of the most desirable traits).
