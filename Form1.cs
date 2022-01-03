using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsSimu
{
    class SimpleGridState
    {
        static int I = 0;
        public int Y { get; set; }
        public int X { get; set; }
        public int Idx { get; set; }
        public int Count { get; set; }

        public SimpleGridState(int y, int x)
        {
            Y = y;
            X = x;
            Idx = I++;
            Count = 0;
        }
        public void Inc()
        {
            Count++;
        }
        public void Reset()
        {
            Count = 0;
        }
    }
    class GridState
    {
        public int BOARD_ROWS = 3;
        public int BOARD_COLS = 4;
        public SimpleGridState WIN_STATE;
        public SimpleGridState LOSE_STATE;
        public List<SimpleGridState> Blocker = new List<SimpleGridState>();
        public SimpleGridState START_STATE;

        public int[,] board ;
        public SimpleGridState state;
        public bool isEnd = false;
        public bool determine = true;


        public GridState(SimpleGridState startstate)
        {
            board = new int[BOARD_ROWS, BOARD_COLS];
            this.board[1, 1] = -1;
            this.state = startstate;
            this.isEnd = false;
            this.determine = true;
            WIN_STATE = new SimpleGridState(0, BOARD_COLS - 1);
            LOSE_STATE = new SimpleGridState(1, BOARD_COLS - 1);
            START_STATE = new SimpleGridState(BOARD_ROWS - 1, 0);
            Blocker.Add(new SimpleGridState(1, 1));
        }
        public float giveReward()
        {
            if (this.state.Y == WIN_STATE.Y && this.state.X == WIN_STATE.X)
                return 1.0f;
            else
            if (this.state.Y == LOSE_STATE.Y && this.state.X == LOSE_STATE.X)
                return -1.0f;
            else
                return 0.0f;
        }
        public void isEndFunc()
        {
            if ((this.state.Y == WIN_STATE.Y && this.state.X == WIN_STATE.X) ||
                (this.state.Y == LOSE_STATE.Y && this.state.X == LOSE_STATE.X))
                this.isEnd = true;
        }
        public void reset ()
        {

        }
        public SimpleGridState nxtPosition(string action)
        {
            /*
            """
            action: up, down, left, right
            -------------
            0 | 1 | 2| 3|
            1 |
            2 |
            return next position
            """
            */
            SimpleGridState nxtState;
            if (this.determine)
            {
                if (action == "up")
                    nxtState = new SimpleGridState(this.state.Y - 1, this.state.X);
                else
                if (action == "down")
                    nxtState = new SimpleGridState(this.state.Y + 1, this.state.X);
                else
                if (action == "left")
                    nxtState = new SimpleGridState(this.state.Y, this.state.X - 1);
                else
                // if (action == "right")
                {
                    // TODO: was muss bei "right" als Parameter rein ?
                    // nxtState = new SimpleGridState(?,?);
                    // nxtState = new SimpleGridState(0,0);  ist falsch!
                    nxtState = new SimpleGridState(0, 0);
                }
                // #if next state legal
                if ((nxtState.Y >= 0) && (nxtState.Y < BOARD_ROWS))
                {
                    if ((nxtState.X >= 0) && (nxtState.X < BOARD_COLS))
                    {
                        bool isBlocker = false;
                        foreach (SimpleGridState block in Blocker)
                        {
                            if (nxtState.Y == block.Y && nxtState.X == block.X) // (1,1) ist die gesperrte Zelle 
                            {
                                isBlocker = true;
                            }
                        }
                        if (!isBlocker)
                            return nxtState;
                    }
                }
            }
            // der Reisende bleibt in der Zelle
            return this.state;
        }
    }

    // #region Agent_of_player
    class GridCell
    {
        public float val;
        public int cnt;
        public GridCell()
        {
            Reset();
        }
        public void Reset()
        {
            val = 0.0f;
            cnt = 0;
        }
    }
    class GridAgent
    {
        /*
        state_values{[0,0]=0.027, [0,1]=0.104, [0,2]=... }
        state_values sind am Anfang für alle Zellen 0. Nach jedem Durchlauf werden die
        durchlaufenden Zellen
        ausgehend von der Endzelle
		states = die Liste der Zellen vom Start zum Endpunkt 
					der Startpunkt {2,0} wird nicht mit gespeichert 
        */

        List<SimpleGridState> states = new List<SimpleGridState>();
        string[] actions = { "up", "down", "left", "right" };
        GridCell[,] state_values; // = new float[GridState.BOARD_ROWS, GridState.BOARD_COLS];
        public int RoundIdx = 0;
        GridState State;
        string message = "";
        int xlen = 100;
        int ylen = 100;

        public GridAgent()
        {
            this.State = new GridState(new SimpleGridState(2, 0));
            state_values = new GridCell[State.BOARD_ROWS, State.BOARD_COLS];

            // # initial state reward
            for (int i = 0; i < State.BOARD_ROWS; i++)
            {
                for (int j = 0; j < State.BOARD_COLS; j++)
                {
                    this.state_values[i, j] = new GridCell();
                    this.state_values[i,j].Reset();  // # set initial value to 0
                }
            }
        }

        private string chooseAction()
        {
            // # choose action with most expected value
            string action = "";
            
            var rand = new Random();
            // TODO:
            // ersetze int zahl = 0; mit einer Zufallszahl
            // Die Zufallszahl soll mit einer Methon von rand erzeugt werden, die eine zahl zwischen 0 und 3 zurück liefert 
            // Wähle die Richtige Methode mit den richtigen Parametern aus 
            int zahl = 0;

            // In this.actions sind 4 Werte :  string[] actions = { "up", "down", "left", "right" };
            // TODO
            // wähle die richtige Aktion anhand der Zufallszahl aus 
            // action = this.actions[ ? ];
            return action;
        }
        SimpleGridState takeAction(string action)
        {
            SimpleGridState position = this.State.nxtPosition(action);
            return position;
        }
        public void reset()
        {
            this.states = new List<SimpleGridState>();
            // this.State.Reset();
            this.State.state = this.State.START_STATE;
            this.State.isEnd = false;
            for (int i = 0; i < State.BOARD_ROWS; i++)
            {
                for (int j = 0; j < State.BOARD_COLS; j++)
                {
                    this.state_values[i, j].cnt = 0;  // # set initial value to 0
                }
            }
        }
        public string playone()
        {
            if (this.State.isEnd)
            {
                this.reset();
                RoundIdx += 1;
            }
            else
            {
                string action = this.chooseAction();
                // # append trace
                SimpleGridState nextPos = this.State.nxtPosition(action);
                this.states.Add(nextPos);
                message = $"current position {State.state.Y}/{State.state.X} action {action} nextPosition: {nextPos.Y}/{nextPos.X} ";
                // # by taking the action, it reaches the next state
                this.State.state = takeAction(action);
                this.state_values[State.state.Y, State.state.X].cnt++;
                // # mark is end
                this.State.isEndFunc();
            }
            return message;
        }
        
        (int,int) ComputeScreenPosition(int x, int y, int startx, int starty)
        {
            int screenx = startx + x * xlen;
            int screeny = starty + y * ylen;
            return (screenx, screeny);
        }
        private void DrawText(Graphics g, string drawString, int x, int y, Color color, int fontSize = 8)
        {
            System.Drawing.Graphics formGraphics = g;
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", fontSize);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            // formGraphics.Dispose();
        }

        public void Draw(Graphics g, int starty, int startx)
        {
            int textoffx = 30;
            int textoffy = 30;
            Pen penred = new Pen(Color.Red, 4);
            Pen pengreen = new Pen(Color.Green, 4);
            Pen pengray = new Pen(Color.Gray, 4);
            Pen penblue= new Pen(Color.BlueViolet, 4);

            DrawText(g, message, startx, starty - 20, Color.Red, 14);

            int y, x;
            // Values der Zellen malen 
            for (y = 0; y < State.BOARD_ROWS; y++)
            {
                for (x = 0; x < State.BOARD_COLS; x++)
                {
                    var pos = ComputeScreenPosition(x,y,startx, starty);
                    g.DrawRectangle(pengray, pos.Item1, pos.Item2, xlen, ylen);
                    string dreiNachkomma = $"{this.state_values[y, x].val}";
                    string cnt = this.state_values[y, x].cnt.ToString();
                    DrawText(g, dreiNachkomma, pos.Item1 + textoffx, pos.Item2 + textoffy, Color.Red, 11);
                    DrawText(g, cnt, pos.Item1 + textoffx + 15, pos.Item2 + textoffy + 15, Color.Red, 6);
                }
            }
            int recht_offx = 20;
            int recht_offy = 20;
            // Gesperrte Zellen kennzeichnen 
            foreach (SimpleGridState block in State.Blocker)
            {


                var blockpos = ComputeScreenPosition(block.Y, block.X, starty, startx);
                g.DrawRectangle(pengray, blockpos.Item2 + recht_offx, blockpos.Item1 + recht_offy, 50, 50);
            }

            // Positives Ziel kennzeichnen 
            var poszplus = ComputeScreenPosition(State.WIN_STATE.Y, State.WIN_STATE.X, starty, startx);
            // TODO: male ein Rechteck mit der Farbe pengreen in das grüne Ziel
             g.DrawRectangle(pengreen, poszplus.Item2 + recht_offx, poszplus.Item1 + recht_offy, 50, 50);


            // Start kennzeichnen 
            var posstart = ComputeScreenPosition(State.START_STATE.Y, State.START_STATE.X, starty, startx);
            // TODO: male ein Rechteck mit der Farbe penblue in die Startzelle 
            g.DrawRectangle(penblue, posstart.Item2 + recht_offx, posstart.Item1 + recht_offy, 50, 50);



            // Negatives Ziel kennzeichnen 
            var poszminus = ComputeScreenPosition(State.LOSE_STATE.Y, State.LOSE_STATE.X, starty, startx);
            // TODO: male ein Rechteck mit der Farbe penred in die Verlierer-Zelle (Verlierer in Englisch: Loose)
            // die Startposition ist schon in poszminus.Item1 und poszminus.Item2 !
            g.DrawRectangle(penred, poszminus.Item2 + recht_offx, poszminus.Item1 + recht_offy, 50, 50);

            // Aktuelle Zelle kennzeichnen 
            Pen pen = new Pen(Color.Gray, 2);
            int circle_offx = 15;
            int circle_offy = 15;
            var pos2 = ComputeScreenPosition(State.state.Y, State.state.X, starty, startx);
             g.DrawEllipse(pen, pos2.Item2 + circle_offx, pos2.Item1 + circle_offy, 50, 50);
            // TODO: male eine Ellipse mit der Farb pen in die aktuelle Zelle 
            // die Startposition ist schon in pos2.Item1 und pos2.Item2 !

            y = starty + State.BOARD_ROWS * ylen + 100;
            DrawText(g, $"Runde {RoundIdx}", 30, y, Color.Magenta, 20);
        }
    }

    public partial class Form1 : Form
    {
        GridAgent ag = null; 
        public bool DoSimulation = false;
        
        int SimulationTimer = 0;

        private int _fieldWidth = 800;
        private int _fieldHeight = 600;

        public Form1()
        {
            InitializeComponent();

            // Centers the form on the current screen
            CenterToScreen();

            // Set a game field size
            ClientSize = new Size(_fieldWidth, _fieldHeight);

            // #main 
            // TODO 
            // Aktuell hat das Gitter 3 Zeilen und 4 Spalten
            // das Gitter wird hier erzeugt.
            // Änder den Konstruktor so, dass man die Anzahl der Zeilen und der Spalten mit übergeben kann. Denn wir wollen 
            // das Gitter in verschiedenen Auflösungen haben.
            // Mache ein Gitter, dass 6 Zeilen und 9 Spalten hat!
            ag = new GridAgent();

            // Create a timer for the GameLoop method
            var timer = new Timer();
            timer.Tick += GameLoop;
            timer.Interval = 50;
            timer.Start();
        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            e.Graphics.Clear(Color.White);
            Graphics g = e.Graphics;
            Draw(g);
        }

        private void GameLoop(object sender, System.EventArgs e)
        {
            Update();
            Invalidate();
        }

        private void Update()
        {
            if (ag != null)
            {
                string msg = ag.playone();
                if (ag.RoundIdx > 50)
                {
                    ag.RoundIdx = 0;
                    ag.reset();
                }
            }
        }
    
        
        private void Draw(Graphics g)
        {
            if (ag!=null)
                ag.Draw(g, 50, 10);
        }

        private void DrawText(Graphics g , string drawString, int x, int y, Color color, int fontSize=8)
        {
            // System.Drawing.Graphics formGraphics = this.CreateGraphics();
            System.Drawing.Graphics formGraphics = g;
            System.Drawing.Font drawFont = new System.Drawing.Font("Arial", fontSize);
            System.Drawing.SolidBrush drawBrush = new System.Drawing.SolidBrush(System.Drawing.Color.Black);
            System.Drawing.StringFormat drawFormat = new System.Drawing.StringFormat();
            formGraphics.DrawString(drawString, drawFont, drawBrush, x, y, drawFormat);
            drawFont.Dispose();
            drawBrush.Dispose();
            // formGraphics.Dispose();
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        public void ResetSimulation()
        {
        }

        public void Start2_click()
        {
            DoSimulation = true;
        }
        public void Stop_click()
        {
            DoSimulation = false;
            ResetSimulation();
        }
    }
}

