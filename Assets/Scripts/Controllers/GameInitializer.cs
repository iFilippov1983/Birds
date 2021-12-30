namespace Birds
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var sceneInitializer = new SceneInitializer(gameData);
            var scoresBarController = new ScoresBarController(gameData, sceneInitializer);
            var timerController = new TimerController(gameData.GameProperties, sceneInitializer);
            var interactiveObjectsController = new InteractiveObjectsController(gameData);
            var gameProgressController = new GameProgressController(gameData.GameProperties, interactiveObjectsController, scoresBarController, timerController);
            
            controllers.Add(sceneInitializer);
            controllers.Add(scoresBarController);
            controllers.Add(timerController);
            controllers.Add(interactiveObjectsController);
            controllers.Add(gameProgressController);
        }
    }
}

