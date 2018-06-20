


using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;

/**
 * Survive the wrath of Kutulu
 * Coded fearlessly by JohnnyYuge & nmahoude (ok we might have been a bit scared by the old god...but don't say anything)
 **/
class Player
{
        public static int x_p = 1;
          public static  int x_y=1;
         
    static void Main(string[] args)
    {
        string[] inputs;
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
        }
        inputs = Console.ReadLine().Split(' ');
        int sanityLossLonely = int.Parse(inputs[0]); // how much sanity you lose every turn when alone, always 3 until wood 1
        int sanityLossGroup = int.Parse(inputs[1]); // how much sanity you lose every turn when near another player, always 1 until wood 1
        int wandererSpawnTime = int.Parse(inputs[2]); // how many turns the wanderer take to spawn, always 3 until wood 1
        int wandererLifeTime = int.Parse(inputs[3]); // how many turns the wanderer is on map after spawning, always 40 until wood 1

        // game loop
        
        //variable
        var rand = new Random();
        bool startG = false;
        List MobeWanderer = new List<WANDERER>();
        
        while (true)
        {
            int entityCount = int.Parse(Console.ReadLine()); // the first given entity corresponds to your explorer
            for (int i = 0; i < entityCount; i++)
            {
               var line = Console.ReadLine().Split(' ');
                    var id = int.Parse(line[1]);
                int x = int.Parse(line[2]);
                int y = int.Parse(line[3]);
         
                 var entityType = line[0];
             if(entityType == "WANDERER")
             {
              WANDERER mob = new WANDERER();
              mob.pos_x = x;
              mob.pox_y = y;
              mob.id = id;
              MobeWanderer.add(mob);
              
             }
                
                }
            
                    //обработка препятствий
           //старт игры
           if(startG == false)
           {
              Step(rand,width,height);
           
              startG = true;
              } //конец обработки старта игры
              
              
         Console.WriteLine("MOVE "+x_p+" "+x_y);
           
     }   
    }
   public static void Step(Random rand2,int width2,int height2)
   {
           x_p = rand2.Next(1,width2-1);
            x_y = rand2.Next(1,height2-1);
     //   Thread.Sleep(1000);
            
   }
   }
   class WANDERER
   {
    int pos_x {get;set;}
    int pos_y {get;set;}
    int id {get;set;}
   }