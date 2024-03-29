﻿using MG_58_2020.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;

namespace MG_58_2020
{
    public partial class MemoryGameForm : Form
    {
        // Udaljenost mreze od okvira prozora
        public int leftDistance, rightDistance, topDistance, bottomDistance;
        public int lineWidth;
        public int fieldWidth, fieldHeight;
        public int numberOfFieldsX, numberOfFieldsY;
        public Pen pen;

        public bool firstMoveInGame;

        public string podela;

        public string ImeIgraca
        {
            get
            {
                return imeIgracaTextBox.Text;
            }
        }

        // Slike
        public List<Image> images;
        public List<Image> icons;
        public List<Image> dividedImage;
        public Image unopenedImage;

        public bool gameInProgress;
        public string uploadedImage = string.Empty;

        public MyTimer timer;

        public GameController gameController;

        public Card cardToDraw;

        public int numberOfMoves = 0;

        public bool secondMove = false;

        private IServiceFactory serviceFactory;

        private Caretaker caretaker;
        private GameControllerResponse response;

        public MemoryGameForm()
        {
            InitializeComponent();

            int screenWidth, screenHeight;
            screenWidth = this.ClientRectangle.Width;
            screenHeight = this.ClientRectangle.Height;

            lineWidth = 1;

            leftDistance = (int)Math.Round(screenWidth * 0.03); // 3%
            rightDistance = (int)Math.Round(screenWidth * 0.15); // 15%
            topDistance = (int)Math.Round(screenHeight * 0.03); // 3%
            bottomDistance = (int)Math.Round(screenHeight * 0.03); // 3%

            numberOfFieldsX = 3 * 2;
            numberOfFieldsY = 3;

            CalculateFieldDimensions();

            Color color = Color.FromArgb(255, 0, 0, 0);
            pen = new Pen(color, lineWidth);

            LoadIcons();
            images = icons;
            dividedImage = null;

            gameInProgress = false;

            radioButton332.Checked = true;
            podela = "3x3x2";
            radioButtonIkonice.Checked = true;
            timer = new MyTimer(timerLabel);

            unopenedImage = Image.FromFile(RelativePath(Path.Combine(Program.ResourcesFolder, "Neotvoreno.bmp")));

            loadImageButton.Visible = false;
            loadedImageLabel.Visible = false;

            serviceFactory = new ServiceFactory();
            undoButton.Enabled = false;
            redoButton.Enabled = false;

            caretaker = new Caretaker(this);
        }
        public void PaintGrid(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;

            int dX, dY = topDistance;
            for (int i = 0; i < numberOfFieldsY; i++)
            {
                dX = leftDistance;
                for (int j = 0; j < numberOfFieldsX; j++)
                {
                    g.DrawRectangle(this.pen, dX, dY, fieldWidth, fieldHeight);
                    dX += fieldWidth;
                }
                dY += fieldHeight;
            }
            this.Paint -= PaintGrid;
        }

        public void PaintImages(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (images == null)
                return;
            int dX, dY = topDistance + lineWidth - 1;
            for (int i = 0; i < numberOfFieldsY; i++)
            {
                dX = leftDistance + lineWidth - 1;
                for (int j = 0; j < numberOfFieldsX; j++)
                {
                    int jCalculated = j;
                    if (j >= numberOfFieldsX / 2)
                        jCalculated = j - numberOfFieldsX / 2;
                    int index = i * numberOfFieldsX / 2 + jCalculated;
                    g.DrawImage(images[index], dX, dY, fieldWidth - lineWidth, fieldHeight - lineWidth);
                    dX += fieldWidth;
                }
                dY += fieldHeight;
            }

            this.Paint -= PaintImages;
        }

        private void radioButtonIkonice_CheckedChanged(object sender, EventArgs e)
        {
            loadImageButton.Visible = false;
            loadedImageLabel.Visible = false;
            images = icons;
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            Invalidate();
        }
        private void radioButtonMojaSlika_CheckedChanged(object sender, EventArgs e)
        {
            loadImageButton.Visible = true;
            loadedImageLabel.Visible = true;
            images = dividedImage;
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            Invalidate();
        }
        public void PaintNeotvoreno(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (images == null)
                return;
            int dX, dY = topDistance;
            Image image = unopenedImage;
            for (int i = 0; i < numberOfFieldsY; i++)
            {
                dX = leftDistance;
                for (int j = 0; j < numberOfFieldsX; j++)
                {
                    g.DrawImage(image, dX + lineWidth, dY + lineWidth, fieldWidth - lineWidth, fieldHeight - lineWidth);
                    dX += fieldWidth;
                }
                dY += fieldHeight;
            }

            this.Paint -= PaintNeotvoreno;
        }

        public void PaintCards(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            if (images == null)
                return;
            Image image;
            bool opened;
            int dX, dY = topDistance + lineWidth - 1;
            for (int i = 0; i < numberOfFieldsY; i++)
            {
                dX = leftDistance + lineWidth - 1;
                for (int j = 0; j < numberOfFieldsX; j++)
                {
                    int jCalculated = j;
                    if (j >= numberOfFieldsX / 2)
                        jCalculated = j - numberOfFieldsX / 2;
                    opened = gameController.fields[i, j].Opened;
                    if (opened)
                    {
                        int index = gameController.fields[i, j].ImageIndex;
                        image = images[index];
                    }
                    else
                    {
                        image = unopenedImage;
                    }
                    
                    g.DrawImage(image, dX, dY, fieldWidth - lineWidth, fieldHeight - lineWidth);
                    dX += fieldWidth;
                }
                dY += fieldHeight;
            }

            this.Paint -= PaintCards;
        }

        public void PaintCard(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            int dX, dY;
            dX = leftDistance + cardToDraw.x * (fieldWidth) + lineWidth;
            dY = topDistance + cardToDraw.y * (fieldHeight) + lineWidth;
            Image image;
            if (cardToDraw.Opened)
            {
                image = images[cardToDraw.ImageIndex];
            }
            else
            {
                image = unopenedImage;
            }
            g.DrawImage(image, dX, dY, fieldWidth - lineWidth, fieldHeight - lineWidth);
            this.Paint -= PaintCard;
        }

        private void finishGameButton_Click(object sender, EventArgs e)
        {
            gameInProgress = false;
            timer.Stop();
            setEnabled(true);
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            Invalidate();
        }

        private void radioButton332_CheckedChanged(object sender, EventArgs e)
        {
            numberOfFieldsX = 3 * 2;
            numberOfFieldsY = 3;
            CalculateFieldDimensions();
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            podela = "3x3x3";
            Invalidate();
        }

        private void radioButton342_CheckedChanged(object sender, EventArgs e)
        {
            numberOfFieldsX = 3 * 2;
            numberOfFieldsY = 4;
            CalculateFieldDimensions();
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            podela = "3x4x2";
            Invalidate();
        }

        private void radioButton442_CheckedChanged(object sender, EventArgs e)
        {
            numberOfFieldsX = 4 * 2;
            numberOfFieldsY = 4;
            CalculateFieldDimensions();
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            podela = "4x4x2";
            Invalidate();
        }

        private void MemoryGameForm_ResizeEnd(object sender, EventArgs e)
        {
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            this.Invalidate();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            caretaker.Undo();
            undoButton.Enabled = caretaker.CanUndo;
            redoButton.Enabled = caretaker.CanRedo;
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            caretaker.Redo();
            undoButton.Enabled = caretaker.CanUndo;
            redoButton.Enabled = caretaker.CanRedo;
        }

        public IMemento Save()
        {
            Field[,] fields = new Field[gameController.Height, gameController.Width];
            for (int i = 0; i < gameController.Height; i++)
                for (int j = 0; j < gameController.Width; j++)
                {
                    fields[i, j] = (Field)gameController.fields[i, j].Clone();
                }

            return new ConcreteMemento
            {
                fields = fields,
                response = this.response,
                pogodjeno = gameController.pogodjeno
            };
        }

        public void Restore(IMemento memento)
        {
            gameController.Restore(memento);
            this.Paint += PaintCards;
            this.Paint += PaintGrid;
            Invalidate();
            Refresh();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            this.Paint += PaintImages;
            this.Paint += PaintGrid;
            this.Invalidate();
            this.Refresh();
        }

        private void Form1_click(object sender, MouseEventArgs e)
        {
            if (!gameInProgress)
                return;
            Point location = e.Location;
            if (location.X < leftDistance + 1 || location.X > (numberOfFieldsX + 1) * lineWidth + numberOfFieldsX * fieldWidth)
                return;
            if (location.Y < topDistance + 1 || location.Y > (numberOfFieldsY + 1) * lineWidth + numberOfFieldsY * fieldHeight)
                return;
            double XinTable = location.X - leftDistance;
            int x = (int)Math.Floor(XinTable / (fieldWidth + lineWidth));
            double YinTable = location.Y - topDistance;
            int y = (int)Math.Floor(YinTable / (fieldHeight + lineWidth));

            response = gameController.playMove(x, y);
            switch (response.responseType)
            {
                case ResponseType.ALREADY_OPENED:
                    return;
                case ResponseType.OPENED_ONE:
                    cardToDraw = response.card1;
                    this.Paint += PaintCard;
                    if(firstMoveInGame)
                    {
                        firstMoveInGame = false;
                        this.Paint += PaintCards;
                        this.Paint += PaintGrid;
                        Invalidate();
                        Refresh();
                    }
                    else
                    {
                        Invalidate(GetRectangle(x, y));
                    }
                    
                    caretaker.Backup();
                    break;
                case ResponseType.WRONG_GUESS:
                    cardToDraw = response.card2;
                    this.Paint += PaintCard;
                    Invalidate(GetRectangle(cardToDraw.x, cardToDraw.y));
                    Task.Run(async () =>
                    {
                        await Task.Delay(TimeSpan.FromSeconds(0.5));
                        cardToDraw = (Card)response.card1.Clone();
                        cardToDraw.Opened = false;
                        this.Paint += PaintCard;
                        Invalidate(GetRectangle(cardToDraw.x, cardToDraw.y));
                        await Task.Delay(TimeSpan.FromMilliseconds(1));
                        cardToDraw = (Card)response.card2.Clone();
                        cardToDraw.Opened = false;
                        this.Paint += PaintCard;
                        Invalidate(GetRectangle(cardToDraw.x, cardToDraw.y));
                        await Task.Delay(TimeSpan.FromMilliseconds(1));
                        gameController.CloseAll();
                    });
                    break;
                case ResponseType.RIGHT_GUESS:
                    caretaker.Backup();
                    cardToDraw = response.card2;
                    this.Paint += PaintCard;
                    Invalidate(GetRectangle(x, y));
                    gameController.CloseAll();
                    break;
                default:
                    return;
            }

            undoButton.Enabled = true;

            PlaySound();

            if (secondMove)
            {
                ++this.numberOfMoves;
                secondMove = false;
            }
            else
            {
                secondMove = true;
            }

            this.movesLabel.Text = this.numberOfMoves.ToString(); 

            if(gameController.GameFinished)
            {
                this.timer.Stop();

                var resultService = serviceFactory.GetResultService();
                resultService.InsertNewResult(new CreateScoreResult
                {
                    BrojPoteza = numberOfMoves,
                    Ime = ImeIgraca,
                    Slika = uploadedImage,
                    Vreme = "00:" + timer.TimeString,
                    Podela = podela
                });

                GameFinished gameFinished = new GameFinished();
                gameFinished.form = this;
                gameFinished.FillDataGridView();
                gameFinished.StartPosition = FormStartPosition.CenterScreen;
                gameFinished.FormBorderStyle = FormBorderStyle.FixedDialog;
                gameFinished.ShowDialog();

                this.Paint += PaintCards;
                this.Paint += PaintGrid;
                Invalidate();
                Refresh();

                undoButton.Enabled = false;
                redoButton.Enabled = false;
                caretaker.Reset();
            }
        }


        private void newGameButton_Click(object sender, EventArgs e)
        {
            if (images == null)
                return;
            if (imeIgracaTextBox.Text.Length < 3)
            {
                Form popUpForm = new UserNameRequired();
                popUpForm.Text = "Obavestenje";
                popUpForm.StartPosition = FormStartPosition.CenterScreen;
                popUpForm.ShowDialog();
                return;
            }
            gameInProgress = true;
            timer.Restart();

            gameController = new GameController(numberOfFieldsX, numberOfFieldsY);
            setEnabled(false);


            this.Paint += PaintGrid;
            this.Paint += PaintNeotvoreno;
            Invalidate();

            firstMoveInGame = true;
        }
        private void loadImageButton_Click(object sender, EventArgs e)
        {
            OpenFileDialog fileDialog = new OpenFileDialog();
            fileDialog.Filter = "Image files (*.jpg, *.jpeg, *.jpe, *.jfif, *.png, *.bmp)|*.jpg;*.jpeg;*.jpe;*.jfif;*.png;*.bmp";
            fileDialog.FilterIndex = 3;
            fileDialog.RestoreDirectory = true;
            if (fileDialog.ShowDialog() == DialogResult.OK)
            {
                loadedImageLabel.Text = Path.GetFileName(fileDialog.FileName);
                dividedImage = DivideImage(fileDialog.FileName, numberOfFieldsX/2, numberOfFieldsY);
                images = dividedImage;
                uploadedImage=Path.GetFileName(fileDialog.FileName);
                this.Paint += PaintImages;
                this.Paint += PaintGrid;
                Invalidate();
            }
        }

        public void setEnabled(bool b)
        {
            radioButton332.Enabled = radioButton342.Enabled = radioButton442.Enabled = b;
            radioButtonIkonice.Enabled = radioButtonMojaSlika.Enabled = b;
            loadImageButton.Enabled = b;
            imeIgracaTextBox.Enabled = b;
        }
    }
}