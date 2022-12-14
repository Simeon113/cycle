using Unit05.Game.Casting;
using Unit05.Game.Directing;
using Unit05.Game.Scripting;
using Unit05.Game.Services;
using Unit05.Game;


namespace Unit05
{
    /// <summary>
    /// The program's entry point.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Starts the program using the given arguments.
        /// </summary>
        /// <param name="args">The given arguments.</param>
        static void Main(string[] args)
        {
            int x1 = Constants.MAX_X / 2;
            int x2 = Constants.MAX_X / 4;
            int y = Constants.MAX_Y / 2;

            Point point1 = new Point(x1, y);
            Point point2 = new Point(x2, y);
            // create the cast


            Cast cast = new Cast();
            cast.AddActor("player1", new Cycle(point1, Constants.RED));
            cast.AddActor("player2", new Cycle(point2, Constants.GREEN));

            // create the services
            KeyboardService keyboardService = new KeyboardService();
            VideoService videoService = new VideoService(false);
            
           
            // create the script
            Script script = new Script();
            script.AddAction("input", new ControlActorsAction(keyboardService));
            script.AddAction("update", new HandleCollisionsAction());
            script.AddAction("update", new MoveActorsAction());
        
            script.AddAction("output", new DrawActorsAction(videoService));

            // start the game
            Director director = new Director(videoService);
            director.StartGame(cast, script);
        }
    }
}