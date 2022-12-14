using System;
using System.Collections.Generic;
using System.Data;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An update action that handles interactions between the actors.</para>
    /// <para>
    /// The responsibility of HandleCollisionsAction is to handle the situation when the snake 
    /// collides with the food, or the snake collides with its segments, or the game is over.
    /// </para>
    /// </summary>
    public class HandleGameOverCollisions : Action
    {
        private int count1 = 5;
        private int count2 = 10;

        private Point _direction1 = new Point(0, Constants.CELL_SIZE);

        private Point _direction2 = new Point(0, Constants.CELL_SIZE);


        public HandleGameOverCollisions() 
        {
        }

        public void Execute(Cast cast, Script script){


            Cycle player1 = (Cycle)cast.GetFirstActor("player1");
            Cycle player2 = (Cycle)cast.GetFirstActor("player2");
            Actor head1 = player1.GetHead();
            List<Actor> body1 = player1.GetBody();
            Actor head2 = player2.GetHead();
            List<Actor> body2 = player2.GetBody();



            // direction1 = player1.GetVelocity();
            // direction2 = player2.GetVelocity();

            if (count2 == 0) {

                Random r = new Random();
                int num = r.Next(2);
               
 
                    int x2 = _direction2.GetX();
                    int y2 = _direction2.GetY();
                    if (num < 1) {
                        _direction2 = new Point(y2, x2);
                    }
                    else {
                        _direction2 = new Point(-y2, -x2);
                    }}

                    this.count1 += 20;


            

            if (count1 == 0) {
               

                Random r = new Random();
                int num = r.Next(2);
                    int x1 = _direction1.GetX();
                    int y1 = _direction1.GetY();
                    if (num < 1) {
                        _direction1 = new Point(y1, x1);
                    }
                    else {
                        _direction1 = new Point(-y1, -x1);
                    }

    
                    this.count2 += 20;
                

            }
            


            foreach (Actor segment in body1)
            {
                Point _velocity = player2.GetVelocity();
                if (segment.GetPosition().Near(head2.GetPosition(), _velocity))
                {

                                    Random r = new Random();
                int num = r.Next(2);


                    int x2 = _direction2.GetX();
                    int y2 = _direction2.GetY();
                    if (num < 1) {
                        _direction2 = new Point(y2, x2);
                    }
                    else {
                        _direction2 = new Point(-y2, -x2);
                    }
  


                }
            }

            foreach (Actor segment in body2)
            {
                Point _velocity = player1.GetVelocity();
                if (segment.GetPosition().Near(head1.GetPosition(), _velocity))
                {

                Random r = new Random();
                int num = r.Next(2);
  
                    int x1 = _direction1.GetX();
                    int y1 = _direction1.GetY();
                    if (num < 1) {
                        _direction1 = new Point(y1, x1);
                    }
                    else {
                        _direction1 = new Point(-y1, -x1);
                    }


                }

            }

            this.count1 -= 1;
            this.count2 -= 1;


            player2.TurnHead(_direction2);
            player1.TurnHead(_direction1);
    
            
        // Actor message = cast.GetFirstActor("message");
        // string count = count1.ToString(); 
        // message.SetText(count);
            
        }

    }
}