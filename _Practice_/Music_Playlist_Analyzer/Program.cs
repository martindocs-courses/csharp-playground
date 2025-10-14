using MusicPlaylistAnalyzer.Services;
using MusicPlaylistAnalyzer.Utilities;

var mainMenu = new MenuList();
var userInteractions = new UserInteraction(new UserOptions());

var menu = new Menu(mainMenu, userInteractions);
menu.MenuUI();



