<h1 align="center" >Kitchen Chaos 🕹️🎮</h1>


<h1 align="center" ><img src="https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/290ce5f8-474d-41ab-8395-65e4d1e1b5c7" alt="Logo" width="750" /></h1>


<h2>Kitchen Chaos : </h2> 

The Kitchen Chaos project is one of my favorite projects. It's a cooking game where players cook dishes following recipes and serve them to customers on time. The game features colorful graphics and simple controls to make it easy for players to jump in. Players have to manage their ingredients and time to ensure their dishes are cooked perfectly and served on time. The game is fast-paced and challenging, making it an enjoyable way to have fun and test your cooking skills as fun.


<h2> Here's how it looks : </h2> 

![FirstLook](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/51bdf272-8439-4960-8fbf-e3eff028e639)


Using C#, this game was created using Unity game engine, one of the most powerful game engines. For instance, the game uses a custom-built physics engine to simulate realistic movement and interaction between objects, and a custom shader system to create a unique visual style. 

Unity allows game developers to access a wide range of tools and features that make game development faster and more efficient. For example, its physics engine makes it easy to create realistic physics-based games with realistic physics simulations, while its shader system allows developers to create unique visual effects that are not possible with other game engines.


<h2> Player : </h2> 

![Player](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/d5e9bc00-aca9-4ee4-9c51-e3e7f9f49c69)

For the player instance, I used a duck and snowman like character and mixed it up to create this character.The character is designed to be simple and cartoonish, to make it more appealing. To make it more enjoyable for players, I also added a few animations. Finally, I added a few sound effects to make the environment playful.



<h2> Camera : </h2> 

![Camera](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/94259f51-74f5-4b0d-9411-5c494d04624b)

As in this game, the camera position is fixed and there is no movement of the camera, so the camera is placed at a fixed position. This fixed camera angle allows the player to have an uninterrupted view of the game environment, making it easier to monitor the action. It also creates a more cinematic experience as the player is able to take in the entire game environment.

A cinemachine tool is used to control the camera flow because it simplifies the process and easy to implement😅. Cinemachine also allows for a greater level of control over the camera, allowing the player to move the camera freely or have it transition from one angle to another. This helps to create a more immersive experience and allows for more dynamic camera movements.


<h2> Movements : </h2> 

![Movements](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/129fe4c6-5ee7-42d7-9ba2-f7b5f745b462)

The WSAD Keys or the arrow keys can be used to control the player and interact with the kitchen objects, and these keys can also be changed according to the player's preference. The player can use the keys to move around the kitchen, pick up objects, and interact with other objects in the game. They can also use the keys to perform actions like opening the counters and drawers for grabbing vegetables, or turning on and off appliances.

Default Keys Are: 
```
W : Move Up
S : Move Down
A : Move Left
D : Move Right
E : Interact
F : Alternate Interact
```

You can easily customize these buttons to suit your needs and play furiously!!


<h2> Recipes/Dishes: </h2>

![Recipes](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/df4b39ff-e1d1-4da2-b353-e083b19cccd5)

The recipes are easy to prepare, require minimal ingredients, and are healthy. As of now, there are four types of recipes that are to be delivered to customers.

```
1) Mega Burger : The Mega Burger is a fully loaded burger with all of the ingredients, such as Tomato
   Slices + Cabbage Slices + Cheese Cuts + Cooked Patty + Bread.
2) Cheese Burger: Grill the patties and then assemble the burger with cheese slices and bread.
3) Burger: Burger with a cooked patty between the bread, delicious.
4) Salad : A simple and healthy food item with only tomato slices and cabbage slices.

```

<h2> Cutting Counter: </h2> 

![Cut](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/8d7cdb46-777e-450c-a78c-505deb9e4e0e)


The cutting counter, as its name suggests, is used to cut vegetables, such as tomatoes and cabbage in to slices.

Cuts can be performed using the alternate interact key, which is set to "F". 

Slicing a fully slushy tomato requires 3 cuts and cutting a full cabbage into slices requires 5 cuts.

An animation of the knife chopping the tomatoes or cabbages is also added in a cutting counter. This makes it easier for players to understand the cutting process. The cutting counter also has sound effects to make it more realistic. 


<h2> Stove Counter: </h2> 

![Stove](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/41976a59-c2ac-4eaf-bc80-5018159bf408)


There is a stove counter where you can cook the paaties for the dishes easily. The stove counter is designed with burners that glow while cooking and a progress bar showing the fried status and also has a warning when the patties are about to burn.

Additionally, it features a sizzling sound and animated to make the experience fun.



<h2> Plate Counter: </h2> 

![Plate](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/7fca4d75-aa8a-44ce-9de2-66df197e28b3)




There is a Plate Counter where players can pick up a plate to arrange ingredients to prepare the dishes.

As the player picks up plates, the plate counter will spawn plates automatically and at most the counter can have 4 plates.


<h2> Trash Counter: </h2> 

![Trash](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/ee078d0a-d41d-4767-a0aa-5b73949345c8)



Trash counter which can be used as a dustbin. Whenever dishes get messed up or burned, they can be thrown in the trash.


<h2> Delivery Counter: </h2> 

![Del](https://github.com/MANISH-SAHANI/Kitchen-Chaos-Game/assets/91081774/c0a4179a-7da6-43b0-9cbb-2380e1333841)

When you prepare dishes or recipes for your customer, you can deliver them to them from the Delivery Counter. If the recipe delivery is successful, the popup displays as successful delivery, but if the recipe delivery is incorrect, it shows as unsuccessful delivery. With the popup, the customer receives the correct order every time, ensuring a seamless delivery experience. 

This delivery counter has a proper counter visual that rotates cotinuously.  The counter visual allows player to easily locate their order delivery area counter, making delivery easy.


<h2> Do you want to download the game?💫</h2>

You can easily download the .zip file included above or you can download it from the release section. Once you have downloaded the game, you can unzip it and run Kitchen Chaos.exe and you are ready to play. Enjoy!



