using GameboardGUI;
using System.Diagnostics.Eventing.Reader;
using System.Drawing.Text;
using System.Text.Json.Serialization;
using System.Xml.Linq;
using Newtonsoft.Json;


namespace Project
{
    public partial class GameForm1 : Form
    {
        
        GameboardImageArray _gameBoardGui;

        int[,] gameBoardData = { {10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 10, 10, 10, 10, 10 },
        { 10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 0, 1, 10, 10, 10}, { 10, 10, 10, 1, 0, 10, 10, 10},
        { 10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 10, 10, 10, 10, 10} };
        string tileImageDirPath = Directory.GetCurrentDirectory() + @"\Images\";

        int[,] InitialBoard = { {10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 10, 10, 10, 10, 10 },
        { 10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 0, 1, 10, 10, 10}, { 10, 10, 10, 1, 0, 10, 10, 10},
        { 10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 10, 10, 10, 10, 10}, { 10, 10, 10, 10, 10, 10, 10, 10} };

        /// <summary>
        /// Method <c>GameForm1</c> This opens the form for the user
        /// </summary>
        public GameForm1()
        {
            InitializeComponent();

            Point top = new Point(10, 10);
            Point bottom = new Point(10, 10);

            try
            {
                _gameBoardGui = new GameboardImageArray(this, gameBoardData, top, bottom, 0, tileImageDirPath);
                _gameBoardGui.TileClicked += new GameboardImageArray.TileClickedEventDelegate(GameTileClicked);
                _gameBoardGui.UpdateBoardGui(gameBoardData);
            }

            catch (Exception ex)
            {
                DialogResult result = MessageBox.Show(ex.ToString(), "Game board size problem", MessageBoxButtons.OK);
                this.Close();
            }
        }

        //Every tile that is clicked, a message will be displayed and notify the player which one they selected
        private void GameTileClicked(object sender, EventArgs e)
        {
            int selectionRow = _gameBoardGui.GetCurrentRowIndex(sender);
            int selectionCol = _gameBoardGui.GetCurrentColumnIndex(sender);

            MessageBox.Show($"You just clicked the square at row {selectionRow + 1} and col {selectionCol + 1}");


            MovePiece(selectionRow, selectionCol);

            UpdateTurn();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void panel1_Paint(object sender, PaintEventArgs e)
        {
            Panel infoPanel = new Panel();
            this.Controls.Add(infoPanel);

            Label P1Label = new Label();
            infoPanel.Controls.Add(P1Label);

            TextBox P1TextBox = new TextBox();
            infoPanel.Controls.Add(P1TextBox);

            Label P2Label = new Label();
            infoPanel.Controls.Add(P2Label);

            TextBox P2TextBox = new TextBox();
            infoPanel.Controls.Add(P2TextBox);

            Label P1PiecesLabel = new Label();
            infoPanel.Controls.Add(P1PiecesLabel);

            Label P2PiecesLabel = new Label();
            infoPanel.Controls.Add(P2PiecesLabel);

            Label TurnLabel = new Label();
            infoPanel.Controls.Add(TurnLabel);

            Button StartGameButton = new Button();
            infoPanel.Controls.Add(StartGameButton);
        }

        // In the event the user does not enter a name for each player, it will default to "Player 1 and Player 2".
        // Then a messagebox is displayed and the textboxes cannot be edited hereafter
        private void StartGameButton_Click(object sender, EventArgs e)
        {
            string P1Name = P1TextBox.Text;
            string P2Name = P2TextBox.Text;

            if (string.IsNullOrWhiteSpace(P1Name))
            {
                P1Name = "Player #1";
            }

            if (string.IsNullOrWhiteSpace(P2Name))
            {
                P2Name = "Player #2";
            }

            MessageBox.Show($"Game started! Player 1: {P1Name}, Player 2: {P2Name}", "Game Started", MessageBoxButtons.OK, MessageBoxIcon.Information);

            P1TextBox.Enabled = false;
            P2TextBox.Enabled = false;
        }

        private const int EMPTY = 10;
        private const int PLAYER1 = 0;
        private const int PLAYER2 = 1;
        private int[,] GameBoard;
        private int CurrentPlayer;



        public bool ValidateMove(int row, int col)
        {
            bool captures = false;

            if (gameBoardData[row, col] != EMPTY)
            {
                return false;
            }

            // right
            for (int i = col + 1; i < 8; i++)
            {
                if (gameBoardData[row, i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[row, i] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // left
            for (int i = col - 1; i >= 0; i--)
            {
                if (gameBoardData[row, i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[row, i] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // up
            for (int i = row - 1; i >= 0; i--)
            {
                if (gameBoardData[i, col] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[i, col] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // Down
            for (int i = row + 1; i < 8; i++)
            {
                if (gameBoardData[i, col] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[i, col] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // up right
            for (int i = 1; (row - i >= 0) && (col + i) < 8; i++)
            {
                if (gameBoardData[row - i, col + 1] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[row - i, col + i] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // up left
            for (int i = 1; (row - i >= 0) && (col - i) >= 0; i++)
            {
                if (gameBoardData[row - i, col - i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[row - i, col - i] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // down right
            for (int i = 1; (row + i < 8) && (col + i < 8); i++)
            {
                if (gameBoardData[row + i, col + i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[row + i, col + i] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }

            // down left
            for (int i = 1; (row + i < 8) && (col - 1 >= 0); i++)
            {
                if (gameBoardData[row + i, col - i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (captures && gameBoardData[row + i, col - i] == CurrentPlayer)
                {
                    return true;
                }
                else
                {
                    break;
                }
            }


            return false;
        }

        private int OpponentPiece(int player)
        {
            if (player == PLAYER1)
            {
                return PLAYER2;
            }
            else
            {
                return PLAYER1;
            }
        }

        public void MovePiece(int row, int col)
        {
            if (!ValidateMove(row, col))
            {
                MessageBox.Show("Move is invalid!");
                return;
            }

            else
            {
                gameBoardData[row, col] = CurrentPlayer;

                FlipRight(row, col);
                FlipLeft(row, col);
                FlipUp(row, col);
                FlipDown(row, col);
                FlipUpRight(row, col);
                FlipUpLeft(row, col);
                FlipDownRight(row, col);
                FlipDownLeft(row, col);

                CurrentPlayer = OpponentPiece(CurrentPlayer);

                Scores();
                _gameBoardGui.UpdateBoardGui(gameBoardData);
            }


            if (EndGame())
            {
                MessageBox.Show("Game Over!", "Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void FlipRight(int row, int col)
        {
            bool captures = false;
            int i;

            for (i = col + 1; i < 8 && gameBoardData[row, i] != EMPTY; i++)
            {
                if (gameBoardData[row, i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[row, i] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i < 8 && gameBoardData[row, i] == CurrentPlayer)
            {
                for (int j = col + 1; j < i; j++)
                {
                    gameBoardData[row, j] = CurrentPlayer;
                }
            }
        }

        private void FlipLeft(int row, int col)
        {
            bool captures = false;
            int i;

            for (i = col - 1; i >= 0 && gameBoardData[row, i] != EMPTY; i--)
            {
                if (gameBoardData[row, i] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[row, i] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i >= 0 && gameBoardData[row, i] == CurrentPlayer)
            {
                for (int j = col - 1; j > i; j--)
                {
                    gameBoardData[row, j] = CurrentPlayer;
                }
            }
        }

        private void FlipUp(int row, int col)
        {
            bool captures = false;
            int i;

            for (i = row - 1; i >= 0 && gameBoardData[i, col] != EMPTY; i--)
            {
                if (gameBoardData[i, col] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[i, col] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i >= 0 && gameBoardData[i, col] == CurrentPlayer)
            {
                for (int j = row - 1; j > i; j--)
                {
                    gameBoardData[j, col] = CurrentPlayer;
                }
            }
        }

        private void FlipDown(int row, int col)
        {
            bool captures = false;
            int i;

            for (i = row + 1; i < 8 && gameBoardData[i, col] != EMPTY; i++)
            {
                if (gameBoardData[i, col] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[i, col] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i < 8 && gameBoardData[i, col] == CurrentPlayer)
            {
                for (int j = row + 1; j < i; j++)
                {
                    gameBoardData[j, col] = CurrentPlayer;
                }
            }
        }

        private void FlipUpRight(int row, int col)
        {
            bool captures = false;
            int i, j;

            for (i = row - 1, j = col + 1; i >= 0 && j < 8 && gameBoardData[i, j] != EMPTY; i--, j++)
            {
                if (gameBoardData[i, j] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[i, j] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i >= 0 && j < 8 && gameBoardData[i, j] == CurrentPlayer)
            {
                for (int k = row - 1, l = col + 1; k > i && l < j; k--, l++)
                {
                    gameBoardData[k, l] = CurrentPlayer;
                }
            }
        }

        private void FlipUpLeft(int row, int col)
        {
            bool captures = false;
            int i, j;

            for (i = row - 1, j = col - 1; i >= 0 && j >= 0 && gameBoardData[i, j] != EMPTY; i--, j--)
            {
                if (gameBoardData[i, j] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[i, j] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i >= 0 && j >= 0 && gameBoardData[i, j] == CurrentPlayer)
            {
                for (int k = row - 1, l = col - 1; k > i && l > j; k--, l--)
                {
                    gameBoardData[k, l] = CurrentPlayer;
                }
            }
        }

        private void FlipDownRight(int row, int col)
        {
            bool captures = false;
            int i, j;

            for (i = row + 1, j = col + 1; i < 8 && j < 8 && gameBoardData[i, j] != EMPTY; i++, j++)
            {
                if (gameBoardData[i, j] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[i, j] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i < 8 && j < 8 && gameBoardData[i, j] == CurrentPlayer)
            {
                for (int k = row + 1, l = col + 1; k < i && l < j; k++, l++)
                {
                    gameBoardData[k, l] = CurrentPlayer;
                }
            }
        }

        private void FlipDownLeft(int row, int col)
        {
            bool captures = false;
            int i, j;

            for (i = row + 1, j = col - 1; i < 8 && j >= 0 && gameBoardData[i, j] != EMPTY; i++, j--)
            {
                if (gameBoardData[i, j] == OpponentPiece(CurrentPlayer))
                {
                    captures = true;
                }
                else if (gameBoardData[i, j] == CurrentPlayer)
                {
                    break;
                }
            }

            if (captures && i < 8 && j >= 0 && gameBoardData[i, j] == CurrentPlayer)
            {
                for (int k = row + 1, l = col - 1; k < i && l > j; k++, l--)
                {
                    gameBoardData[k, l] = CurrentPlayer;
                }
            }
        }

        public void Scores()
        {
            int ScoreP1 = 0;
            int ScoreP2 = 0;

            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (gameBoardData[row, col] == PLAYER1)
                    {
                        ScoreP1++;
                    }
                    else if (gameBoardData[row, col] == PLAYER2)
                    {
                        ScoreP2++;
                    }
                }
            }
            P1PiecesLabel.Text = $"Player 1: {ScoreP1}";
            P2PiecesLabel.Text = $"Player 2: {ScoreP2}";
        }

        public bool EndGame()
        {
            bool CompleteBoard = true;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (gameBoardData[row, col] == EMPTY)
                    {
                        CompleteBoard = false;
                        break;
                    }
                }
                if (!CompleteBoard)
                {
                    break;
                }
            }
            if (CompleteBoard)
            {
                return true;
            }

            bool RemainingMove = false;
            for (int row = 0; row < 8; row++)
            {
                for (int col = 0; col < 8; col++)
                {
                    if (ValidateMove(row, col))
                    {
                        RemainingMove = true;
                        break;
                    }
                }
                if (RemainingMove)
                {
                    break;
                }
            }
            return !RemainingMove;
        }

        private void TurnLabel_Click(object sender, EventArgs e)
        {

        }

        private void UpdateTurn()
        {
            if (CurrentPlayer == PLAYER1)
            {
                TurnLabel.Text = "Turn: Player 1";
            }
            else
            {
                TurnLabel.Text = "Turn: Player 2";
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm aboutForm = new AboutForm();
            aboutForm.ShowDialog();
        }

        public class GameState
        {
            public string Name { get; set; }
            public DateTime SaveDate { get; set; }
            public string Player1Name { get; set; }
            public string Player2Name { get; set; }
        }

        private void NewGameMenu_Click(object sender, EventArgs e)
        {
            if (GameProgress())
            {
                if (ClickSaveGame())
                {
                    string saveName = GetSaveName();
                    SaveGame(saveName);
                }
            }
            StartNewGame();
        }

        private void ExitMenu_Click(object sender, EventArgs e)
        {
            if (GameProgress())
            {
                if (ClickSaveGame())
                {
                    string saveName = GetSaveName();
                    SaveGame(saveName);
                }
            }
            this.Close();
        }

        // This checks if the game has begun 
        private bool GameProgress()
        {
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (gameBoardData[i, j] != InitialBoard[i, j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private bool ClickSaveGame()
        {
            var result = MessageBox.Show("Do you want to save the current game?", "Save Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return result == DialogResult.Yes;
        }

        // Prompts user to enter name to save
        private string GetSaveName()
        {
            string userInput = Microsoft.VisualBasic.Interaction.InputBox("Enter a name to save the game:", "Save Game", "DefaultSaveName");

            if (string.IsNullOrEmpty(userInput))
            {
                return null;
            }
            return userInput;
        }

        private void SaveGame(string saveName)
        {
            List<GameState> gameStates = LoadAllGameStates();
            if (gameStates.Any(gs => gs.Name == saveName))
            {
                var result = MessageBox.Show($"A save named {saveName} already exists. Overwrite?", "Overwrite Save", MessageBoxButtons.YesNo);
                if (result != DialogResult.Yes)
                {
                    return;
                }
                gameStates.RemoveAll(gs => gs.Name == saveName);
            }

            GameState gameState = new GameState()
            {
                Name = saveName,
                SaveDate = DateTime.Now,
                Player1Name = P1TextBox.Text,
                Player2Name = P2TextBox.Text
            };
            gameStates.Add(gameState);
            SaveGameToJSON(gameState);
        }

        private void StartNewGame()
        {
            InitializeGameBoard();

            CurrentPlayer = PLAYER1;

            UpdateTurn();

            GameProgress();
        }

        private void InitializeGameBoard()
        {
            GameBoard = new int[8, 8];
            
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    GameBoard[i, j] = EMPTY;
                }
            }

            GameBoard[3, 3] = PLAYER1;
            GameBoard[4, 4] = PLAYER1;
            GameBoard[3, 4] = PLAYER2;
            GameBoard[4, 3] = PLAYER2;

            _gameBoardGui.UpdateBoardGui(GameBoard);

        }

        // Ensures if there is a max of 5 saves
        private void SaveGameToJSON(GameState gameState)
        {
            List<GameState> gameStates = LoadAllGameStates();
            gameStates.Add(gameState);

            while (gameStates.Count > 5)
            {
                gameStates.RemoveAt(0);
            }

            string json = JsonConvert.SerializeObject(gameStates);
            File.WriteAllText("GameData.json", json);
        }

        private List<GameState> LoadAllGameStates()
        {
            if (!File.Exists("GameData.json"))
            {
                return new List<GameState>();
            }

            string json = File.ReadAllText("GameData.json");
            return JsonConvert.DeserializeObject<List<GameState>>(json) ?? new List<GameState>();
        }

        private void SaveGameMenu_Click(object sender, EventArgs e)
        {
            string saveName = GetSaveName();
            if (!string.IsNullOrEmpty(saveName))
            {
                SaveGame(saveName);
            }
        }

        private void RestoreGameMenu_Click(object sender, EventArgs e)
        {
            List<GameState> savedGameStates = LoadAllGameStates();
            if (savedGameStates.Count == 0)
            {
                MessageBox.Show("No saved game states are available.", "Restore Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            GameState selectedState;
            if (savedGameStates.Count == 1)
            {
                selectedState = savedGameStates[0];
            }
            else
            {
                selectedState = UserSelectState(savedGameStates);
                if (selectedState == null)
                {
                    return;
                }
            }

            RestoreGameState(selectedState);
        }

        private GameState UserSelectState(List<GameState> savedGameStates)
        {
            string gameStateNames = string.Join("\n", savedGameStates.Select(gs => gs.Name));
            string selectedName = Microsoft.VisualBasic.Interaction.InputBox("Enter the name of the game state you wish to restore:\n" +  gameStateNames, "Select Game State", "");

            if (string.IsNullOrWhiteSpace(selectedName))
            {
                return null;
            }

            return savedGameStates.FirstOrDefault(gs => gs.Name.Equals(selectedName, StringComparison.OrdinalIgnoreCase));
        }

        private void RestoreGameState(GameState gameState)
        {
            if (gameState == null)
            {
                return;
            }
        }
    }
}
