using GameBehaviour;
using GameInterfaces;
using Microsoft.Extensions.DependencyInjection;

var diServices = new ServiceCollection()
    .AddSingleton<IMineFieldGenerator, MineFieldGenerator>()
    .AddSingleton<IGameStateTracker, GameStateTracker>()
    .AddSingleton<INavigator, Navigator>()
    .AddSingleton<IPlayerFeedbackProvider, PlayerFeedbackProvider>()
    .AddSingleton<IGameController, GameController>()
    .AddSingleton<IInputProvider, ConsoleInputProvider>()
    .BuildServiceProvider();

var gameController = diServices.GetService<IGameController>();

gameController?.Initialize();

gameController?.Run();
