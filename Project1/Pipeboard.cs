using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace Project1
{
    internal class Pipeboard
    {
        Random rand = new Random();

        public const int GameBoardWidth = 5;
        public const int GameBoardHeight = 5;

        private PipePiece[,] boardSquares = new PipePiece[GameBoardWidth, GameBoardHeight];
        private List<Vector2> WaterTracker = new List<Vector2>();

        public Pipeboard()
        {
            ClearBoard();
        }
        public void ClearBoard()
        {
            for (int x = 0; x < GameBoardWidth; x++)
            {
                for (int y = 0; y < GameBoardHeight; y++)
                {
                    boardSquares[x, y] = new PipePiece("Empty");
                }
            }
            for (int y = 0; y < GameBoardHeight; y++)
            {
                for (int x = 0; x < GameBoardWidth; x++)
                {
                    RandomPiece(x, y);
                }
            }
        }
        public void RotatePiece(int x, int y, bool clockwise)
        {
            boardSquares[x, y].RotatePiece(clockwise);
        }

        public Rectangle GetSourceRect(int x, int y)
        {
            return boardSquares[x, y].GetSourceRect();
        }

        public string GetSquare(int x, int y)
        {
            return boardSquares[x, y].PieceType;
        }

        public void SetSquare(int x, int y, string pieceName)
        {
            boardSquares[x, y].SetPiece(pieceName);
        }

        public bool HasConnector(int x, int y, string direction)
        {
            return boardSquares[x, y].HasConnector(direction);
        }

        public void RandomPiece(int x, int y)
        {
            boardSquares[x, y].SetPiece(PipePiece.PieceTypes[rand.Next(0, PipePiece.MaxPlayablePieceIndex + 1)]);
        }
        public void FillFromAbove(int x, int y)
        {
            int rowLookup = y - 1;

            while (rowLookup >= 0)
            {
                if (GetSquare(x, rowLookup) != "Empty")
                {
                    SetSquare(x, y, GetSquare(x, rowLookup));
                    SetSquare(x, rowLookup, "Empty");
                    rowLookup = -1;
                }
                rowLookup--;
            }
        }
        public void GenerateNewPieces(bool dropSquares)
        {

            if (dropSquares)
            {
                for (int x = 0; x < Pipeboard.GameBoardWidth; x++)
                {
                    for (int y = Pipeboard.GameBoardHeight - 1; y >= 0; y--)
                    {
                        if (GetSquare(x, y) == "Empty")
                        {
                            FillFromAbove(x, y);
                        }
                    }
                }
            }

            for (int y = 0; y < Pipeboard.GameBoardHeight; y++)
            {
                for (int x = 0; x < Pipeboard.GameBoardWidth; x++)
                {
                    if (GetSquare(x, y) == "Empty")
                    {
                        RandomPiece(x, y);
                    }
                }
            }

        }
        public void ResetWater()
        {
            for (int y = 0; y < GameBoardHeight; y++)
            {
                for (int x = 0; x < GameBoardWidth; x++)
                {
                    boardSquares[x, y].RemoveSuffix("W");
                }
            }
        }
        public void FillPiece(int x, int y)
        {
            boardSquares[x, y].AddSuffix("W");
        }

        public void PropagateWater(int x, int y, string fromDirection)
        {
            if ((y >= 0) && (y < GameBoardHeight) && (x >= 0) && (x < GameBoardWidth))
            {
                if (boardSquares[x, y].HasConnector(fromDirection) && !boardSquares[x, y].Suffix.Contains("W"))
                {
                    FillPiece(x, y);
                    WaterTracker.Add(new Vector2(x, y));
                    foreach (string end in boardSquares[x, y].GetOtherEnds(fromDirection))
                    {
                        switch (end)
                        {
                            case "Left":
                                PropagateWater(x - 1, y, "Right");
                                break;
                            case "Right":
                                PropagateWater(x + 1, y, "Left");
                                break;
                            case "Top":
                                PropagateWater(x, y - 1, "Bottom");
                                break;
                            case "Bottom":
                                PropagateWater(x, y + 1, "Top");
                                break;
                        }
                    }
                }
            }
        }
        public List<Vector2> GetWaterChain(int y)
        {
            WaterTracker.Clear();
            PropagateWater(0, y, "Left");
            return WaterTracker;
        }
    }
}
