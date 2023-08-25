using MG_58_2020.Models;
using System;
using System.Collections.Generic;

namespace MG_58_2020
{
    public class GameController
    {

        public int Width { get;private set; }
        public int Height { get; private set; }
        public int pogodjeno;
        public Field[,] fields { get; private set; }
        private Card firstMove;
        private Card secondMove;
        public GameController(int Width,int Height)
        {
            this.Width= Width;
            this.Height = Height;
            pogodjeno = 0;
            fields = new Field[Height,Width];

            List<int> list = new List<int>();
            int maxNumber = Width / 2 * Height;
            for (int j = 0; j < 2; j++)
                for (int i = 0; i < maxNumber; i++)
                    list.Add(i);

            Random rand = new Random((int)DateTime.Now.Ticks);
            int index;
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    index = rand.Next(list.Count);
                    fields[i, j] = new Field(list[index]);
                    list.Remove(list[index]);
                }
            firstMove = secondMove = null;
        }

        public GameControllerResponse playMove(int x,int y)
        {
            GameControllerResponse response = new GameControllerResponse();
            if (fields[y,x].Opened)
            {
                response.responseType = ResponseType.ALREADY_OPENED;
                return response;
            }
            if (firstMove == null)
            {
                response.responseType = ResponseType.OPENED_ONE;
                fields[y, x].Opened = true;
                firstMove = new Card(fields[y, x],x,y);
                response.card1 = firstMove;
                return response;
            }
            secondMove = new Card(fields[y, x],x,y);
            secondMove.Opened = true;

            if (firstMove.ImageIndex == secondMove.ImageIndex)
            {
                response.responseType = ResponseType.RIGHT_GUESS;
                fields[y, x].Opened = true;
                pogodjeno += 2;
            }
            else
            {
                response.responseType = ResponseType.WRONG_GUESS;
                fields[firstMove.y, firstMove.x].Opened = false;
                fields[secondMove.y, secondMove.x].Opened = false;
            }
            response.card1 = firstMove;
            response.card2 = secondMove;
            return response;
        }

        public void CloseAll()
        {
            firstMove = null;
            secondMove = null;
        }

        public void Assign(Field[,] newFields)
        {
            for (int i = 0; i < Height; i++)
                for (int j = 0; j < Width; j++)
                {
                    fields[i, j] = (Field)newFields[i, j].Clone();
                }
        }

        public void Restore(IMemento memento)
        {
            Assign(memento.fields);

            GameControllerResponse response = memento.response;

            pogodjeno = memento.pogodjeno;

            switch (response.responseType)
            {
                case ResponseType.OPENED_ONE:
                    firstMove = (Card) response.card1.Clone();
                    secondMove = null;
                    break;
                case ResponseType.RIGHT_GUESS:
                    firstMove = null;
                    secondMove = null;
                    break;
            }
        }

        public bool GameFinished
        {
            get
            {
                return pogodjeno == Width * Height;
            }
        }
    }
}