using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace SnakeGame
{
    class Game
    {
        List<GameObject> g_objects;
        public bool isAlive;
        public Snake snake;
        public Food food;
        public Wall wall;

        public Game()
        {
            g_objects = new List<GameObject>();
            snake = new Snake(20, 10, '*', ConsoleColor.White);
            food = new Food(0, 0, 'o', ConsoleColor.Red);
            wall = new Wall('#', ConsoleColor.Green);
            wall.LoadLevel();
            while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                food.Generate();
            g_objects.Add(snake);
            g_objects.Add(food);
            g_objects.Add(wall);

            isAlive = true;
        }

        public void Start()
        {
            ConsoleKeyInfo keyInfo = Console.ReadKey();
            Thread thread = new Thread(MoveSnake);
            thread.Start();
            while (isAlive && keyInfo.Key != ConsoleKey.Escape)
            {
                keyInfo = Console.ReadKey();
                snake.ChangeDirection(keyInfo);
            }
            Console.Clear();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.SetCursorPosition(30, 40);
            Console.WriteLine("GAME OVER!");
            }
        public void MoveSnake()
        {
            while(isAlive)
            {
                snake.Move();
                if(snake.IsCollisionWithObject(food))
                {
                    snake.body.Add(new Point(0,0));
                    while (food.IsCollisionWithObject(snake) || food.IsCollisionWithObject(wall))
                        food.Generate();
                    if (snake.body.Count % 3 == 0)
                        wall.NextLevel();
                }
                if(snake.IsCollisionWithObject(wall))
                {
                    isAlive = false;
                }
                Draw();
                Thread.Sleep(100);
            }
        }
            public void Draw()
            {
                Console.Clear();
                foreach (GameObject g in g_objects)
                    g.Draw();
            }
        }
    }