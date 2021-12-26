namespace Birds
{
    public class GameInitializer
    {
        public GameInitializer(ControllersProxy controllers, GameData gameData)
        {
            var sceneInitializer = new SceneInitializer(gameData);
            var scoresBarController = new ScoresBarController(gameData, sceneInitializer);

            controllers.Add(sceneInitializer);
            controllers.Add(scoresBarController);
        }
    }
}

