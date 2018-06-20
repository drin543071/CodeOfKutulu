


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
          public static int ChangeX;
          public static int ChangeY;
          public static bool CheckStep = false;
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
        var MobeWanderer = new List<WANDERER>();
        var MobeExplorer = new List<EXPLORER>();
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
              var mob = new WANDERER();
            mob.pos_x = x;
            mob.pos_y = y;
            mob.id = id;
              MobeWanderer.Add(mob);

             }
              if(entityType == "EXPLORER")
             {
              var mob = new WANDERER();
              mob.pos_x = x;
              mob.pos_y = y;
              mob.id = id;
              MobeWanderer.Add(mob);

             }
                
                }
            
                    
           //старт игры
           if(startG == false)
           {
              Step(width,height);
           
              startG = true;
              } //конец обработки старта игры

              //обработка препятствий
              /* foreach (WANDERER  mob in MobeWanderer)
               {
              
                 if(MobeExplorer[1].pos_x-1 == mob.pos_x || MobeExplorer[1].pos_x-2 == mob.pos_x)
                 {
                      CheckStep = true;
                      ChangeX = MobeExplorer[1].pos_x + 5;
                      ChangeY = MobeExplorer[1].pos_y;
                      Step(rand,1,1);
                 }
               }*/
              
               foreach (EXPLORER me in MobeExplorer)
               {

                 if(me.pos_x == x_p && me.pos_y == x_y)
                  {
                 Step(width,height);
                 if(CheckStep)
                 CheckStep=false;
                  }
               }
              
         Console.WriteLine("MOVE "+x_p+" "+x_y);
           
     }   
    }
   public static void Step(int width2,int height2)
   {
          if(CheckStep==false)
          {
            Random rand2 = new Random();
           x_p = rand2.Next(1,width2-1);
            x_y = rand2.Next(1,height2-1);
          }
          else if(CheckStep)
          {
              x_p = ChangeX;
              x_y = ChangeY;

          }
            
   }
   }
   class WANDERER
   {
    public  int pos_x {get;set;}
   public  int pos_y{get;set;}
   public  int id{get;set;}
   }
     class EXPLORER
   {
    public  int pos_x {get;set;}
   public  int pos_y{get;set;}
   public  int id{get;set;}
   }          
 
