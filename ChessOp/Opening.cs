using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;

namespace ChessOp
{
    public class Move
    {
        public Image Piece;
        public string Notation;
        public string onePiece = "";
        public string InitialPos = "";
        public string EndingPos = "";
        public bool isTaking;
        public string display = "";

        public Move(string notation) 
        { 
            Notation = notation;
            onePiece += Notation[0].ToString();
            InitialPos += Notation[1].ToString() + Notation[2].ToString();

            if (Notation[3] == 'x')
            {
                isTaking = true;
                EndingPos += Notation[4].ToString() + Notation[5].ToString();
            }
            else
            {
                EndingPos += Notation[3].ToString() + Notation[4].ToString();
            }

            if (isTaking)
            {
                display = "x" + display;

                if (onePiece == "P")
                {
                    display = InitialPos[0].ToString() + display;
                }
            }

            
            if (onePiece != "P")
                display = onePiece + display;

            display += EndingPos;

            Piece = new Image();
        }

        public Move(Image image, string notation)
        {
            Piece = image;

            Notation = notation;
            onePiece += Notation[0].ToString();
            InitialPos += Notation[1].ToString() + Notation[2].ToString();

            if (Notation[3] == 'x')
            {
                isTaking = true;
                EndingPos += Notation[4].ToString() + Notation[5].ToString();
            }
            else
            {
                EndingPos += Notation[3].ToString() + Notation[4].ToString();
            }

            if (isTaking)
            {
                display = "x" + display;

                if (onePiece == "P")
                {
                    display = InitialPos[0].ToString() + display;
                }
            }


            if (onePiece != "P")
                display = onePiece + display;

            display += EndingPos;

            
        }

        public override string ToString()
        {
            return display;
        }

        public int GetCol(string move)
        {
            return (move[0] - 97);
        }

        public int GetRow(string move) 
        {
            return 7 - (move[1] - 49);
        }
    }

    public class Opening
    {
        public List<Move> Moves = new List<Move>();
        public string Name;
        public bool Side;

        public Opening(List<Move> moves, string name, bool side) 
        { 
            Moves = moves;
            Name = name;
            Side = side;
        }

        public override string ToString() { return Name; }
    }
}
