namespace Birds
{
    public sealed class GameInitializer
    {
        public GameInitializer(ControllersDepo controllers, GameData gameData)
        {
            var sceneInitializer = new SceneInitializer(gameData.SceneData);
            var scoresBarController = new ScoresBarController(gameData, sceneInitializer);
            var timerController = new TimerController(gameData.GameProperties.GameTimeOnStart, sceneInitializer);
            var interactiveObjectsController = new InteractiveObjectsController(gameData);
            var gameProgressController = new GameProgressController(gameData.GameProperties.TimeToAddForBonus, interactiveObjectsController, scoresBarController, timerController);
            
            controllers.Add(sceneInitializer);
            controllers.Add(scoresBarController);
            controllers.Add(timerController);
            controllers.Add(interactiveObjectsController);
            controllers.Add(gameProgressController);
        }
    }
}

