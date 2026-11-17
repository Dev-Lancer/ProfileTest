Name: Nhat Minh Duong
Student Number 100971208
Project: Saw it
Drive link for build: https://drive.google.com/drive/folders/17JXU79FOXw_hz4jbKI62D7Mls55qNALi?usp=sharing 
Gameplay: you will become an android equipped with 4 arm saw blade to cut everything and your main goal is to score the highest amount of projectile coming toward you and hit the quota or you will be scrapped and turn in to a block of junk metal
1. After the implementation using factory pattern to handle all projectiles spawning I can see that the game rarely spike up in GPU usage the the average performance cost seems lower than before implementation, and It has slightly high fps than the before implemented version,
2. I used factory pattern to reduce the memory and GPU usage for projectiles spawning in the project. When I set up the factory to handle all the spawning in I can manage the projectile randomness and modify it easily also it won't cost that much memory and in the future I can add more types of projectiles to the game if I want to.
3. When I implement it, I can see the GPU usage average had a decent reduction and the spike occur less frequently and the spike won't jump as high as the before implemented one. How I did it was put it on a stress test by spawning in 60 object per second with 2 different spawning way the first one which is a normal spawner and the second one will use factory pattern to spawn it in and I can  see that the improvement showed in the profile by a lot. By having better structure and architecture and clean execution.
