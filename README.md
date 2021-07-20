## Number Guessing Game

A Web-based application - number guessing game.

Game rules:
<ul>
  <li>Program chooses a random secret number with 4 digits.</li>
  <li>All digits in the secret number are different.</li>
  <li>Player has 8 tries to guess the secret number.</li>
  <li>After each guess program displays a message with:
    <ul>
      <li>a number of matching digits but not on the right places</li>
      <li>a number of matching digits on exact places</li>
    </ul>
  </li>
</ul>

Game ends after 8 tries or if the correct number is guessed.


### GitHub repository
The repository includes a front-end and a back-end folder.

#### Back-end
The back-end is developed with .NET Core. The solution includes three projects - Core (game logic and leaderboard repository), Api (API endpoints) and Tests (unit tests). In order to run the API, open the solution in Visual Studio or Rider and run the solution.

#### Front-end
Front-end is done with React. Open the folder with VS Code, type ```npm i``` in the console to install node_modules and run the app with ```npm start```.
