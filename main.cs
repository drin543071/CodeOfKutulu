
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
          public static  int y_p=1;
    
          public static bool CheckStep = false;
    static void Main(string[] args)
    {
        string[] inputs;
        int width = int.Parse(Console.ReadLine());
        int height = int.Parse(Console.ReadLine());
           var maps = new List<Maps>();      
        for (int i = 0; i < height; i++)
        {
            string line = Console.ReadLine();
       
            for(int j=0; j< line.Length; j++)
            {
                 switch(line[j])
            {
                case '.':
                    {
                      var cube = new Maps();
                      cube.s = "."; //empty
                      cube.x = j;
                      cube.y = i;
                      maps.Add(cube);
                    }break;
                case '#': {
                      var cube = new Maps();
                      cube.s = "#"; //wall
                      cube.x = j;
                      cube.y = i;
                      maps.Add(cube);
                    }break;
                case 'w':
                    {}break;
                case 'U':
                        {}break;
            }
            }
            
        }

        inputs = Console.ReadLine().Split(' ');
        int sanityLossLonely = int.Parse(inputs[0]); // how much sanity you lose every turn when alone, always 3 until wood 1
        int sanityLossGroup = int.Parse(inputs[1]); // how much sanity you lose every turn when near another player, always 1 until wood 1
        int wandererSpawnTime = int.Parse(inputs[2]); // how many turns the wanderer take to spawn, always 3 until wood 1
        int wandererLifeTime = int.Parse(inputs[3]); // how many turns the wanderer is on map after spawning, always 40 until wood 1

        // game loop
        
        //variable
     
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
              var mobE = new EXPLORER();
              mobE.pos_x = x;
              mobE.pos_y = y;
              mobE.id = id;
              MobeExplorer.Add(mobE);

             }
                
                }
            
                    
           //старт игры
           if(startG == false)
           { 
            x_p = 1;
            y_p = 1;
            startG = true;
              } //конец обработки старта игры

              //обработка препятствий
            
              
             
              if(startG&&CheckStep==false)
              {
                Console.WriteLine("MOVE "+x_p+" "+y_p);
         }else if(startG&&CheckStep){
              Console.WriteLine("WAIT");
         }
           
     }   
 
    }
   public static void Step()
   {
         
            
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
   class Maps
   {
   public int x {get;set;}
   public int y {get;set;}
   public string s {get;set;}
   }      
 
}