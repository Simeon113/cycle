using System.Collections.Generic;
using Unit05.Game.Casting;
using Unit05.Game.Services;


namespace Unit05.Game.Scripting
{
    /// <summary>
    /// <para>An output action that draws all the actors.</para>
    /// <para>The responsibility of DrawActorsAction is to draw each of the actors.</para>
    /// </summary>
    public class DrawActorsAction : Action
    {
        private VideoService _videoService;

        /// <summary>
        /// Constructs a new instance of ControlActorsAction using the given KeyboardService.
        /// </summary>
        public DrawActorsAction(VideoService videoService)
        {
            this._videoService = videoService;
        }

        /// <inheritdoc/>
        public void Execute(Cast cast, Script script)
        {
            Cycle player1 = (Cycle)cast.GetFirstActor("player1");
            Cycle player2 = (Cycle)cast.GetFirstActor("player2");
            List<Actor> segments1 = player1.GetSegments();
            List<Actor> segments2 = player2.GetSegments();
            List<Actor> messages = cast.GetActors("messages");
            
            _videoService.ClearBuffer();
            _videoService.DrawActors(segments1);
            _videoService.DrawActors(segments2);
            _videoService.DrawActors(messages);
            _videoService.FlushBuffer();
        }
    }
}