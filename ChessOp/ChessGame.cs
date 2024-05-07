using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Media.Imaging;

namespace ChessOp
{
    class ChessGame
    {
        List<Image> list = new List<Image>() { };
        public Grid Board;

        //BlackPieces
        public Image BPawn1 = new Image();
        public Image BPawn2 = new Image();
        public Image BPawn3 = new Image();
        public Image BPawn4 = new Image();
        public Image BPawn5 = new Image();
        public Image BPawn6 = new Image();
        public Image BPawn7 = new Image();
        public Image BPawn8 = new Image();

        public Image BRook1 = new Image();
        public Image BRook2 = new Image();
        public Image BKnight1 = new Image();
        public Image BKnight2 = new Image();
        public Image BBishop1 = new Image();
        public Image BBishop2 = new Image();
        public Image BQueen = new Image();
        public Image BKing = new Image();

        //WhitePieces
        public Image WPawn1 = new Image();
        public Image WPawn2 = new Image();
        public Image WPawn3 = new Image();
        public Image WPawn4 = new Image();
        public Image WPawn5 = new Image();
        public Image WPawn6 = new Image();
        public Image WPawn7 = new Image();
        public Image WPawn8 = new Image();

        public Image WRook1 = new Image();
        public Image WRook2 = new Image();
        public Image WKnight1 = new Image();
        public Image WKnight2 = new Image();
        public Image WBishop1 = new Image();
        public Image WBishop2 = new Image();
        public Image WQueen = new Image();
        public Image WKing = new Image();

        public void InitialisePieces()
        {
            
            BPawn1.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn2.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn3.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn4.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn5.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn6.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn7.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));
            BPawn8.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bpawn.png", UriKind.Relative));


            BRook1.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Brook.png", UriKind.Relative));
            BRook2.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Brook.png", UriKind.Relative));
            BKnight1.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bknight.png", UriKind.Relative));
            BKnight2.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bknight.png", UriKind.Relative));
            BBishop1.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bbishop.png", UriKind.Relative));
            BBishop2.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bbishop.png", UriKind.Relative));
            BQueen.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bqueen.png", UriKind.Relative));
            BKing.Source = new BitmapImage(new Uri(@"/images/BlackPieces/Bking.png", UriKind.Relative));


            WPawn1.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn2.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn3.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn4.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn5.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn6.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn7.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));
            WPawn8.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wpawn.png", UriKind.Relative));

            WRook1.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wrook.png", UriKind.Relative));
            WRook2.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wrook.png", UriKind.Relative));
            WKnight1.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wknight.png", UriKind.Relative));
            WKnight2.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wknight.png", UriKind.Relative));
            WBishop1.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wbishop.png", UriKind.Relative));
            WBishop2.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wbishop.png", UriKind.Relative));
            WQueen.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wqueen.png", UriKind.Relative));
            WKing.Source = new BitmapImage(new Uri(@"/images/WhitePieces/Wking.png", UriKind.Relative));
        }
        public void SetWhiteBoard()
        {
            //BlackPieces
            Grid.SetRow(BPawn1, 1);
            Grid.SetColumn(BPawn1, 0);
            Grid.SetRow(BPawn2, 1);
            Grid.SetColumn(BPawn2, 1);
            Grid.SetRow(BPawn3, 1);
            Grid.SetColumn(BPawn3, 2);
            Grid.SetRow(BPawn4, 1);
            Grid.SetColumn(BPawn4, 3);
            Grid.SetRow(BPawn5, 1);
            Grid.SetColumn(BPawn5, 4);
            Grid.SetRow(BPawn6, 1);
            Grid.SetColumn(BPawn6, 5);
            Grid.SetRow(BPawn7, 1);
            Grid.SetColumn(BPawn7, 6);
            Grid.SetRow(BPawn8, 1);
            Grid.SetColumn(BPawn8, 7);

            Grid.SetRow(BRook1, 0);
            Grid.SetColumn(BRook1, 0);
            Grid.SetRow(BRook2, 0);
            Grid.SetColumn(BRook2, 7);
            Grid.SetRow(BKnight1, 0);
            Grid.SetColumn(BKnight1, 1);
            Grid.SetRow(BKnight2, 0);
            Grid.SetColumn(BKnight2, 6);
            Grid.SetRow(BBishop1, 0);
            Grid.SetColumn(BBishop1, 2);
            Grid.SetRow(BBishop2, 0);
            Grid.SetColumn(BBishop2, 5);
            Grid.SetRow(BQueen, 0);
            Grid.SetColumn(BQueen, 3);
            Grid.SetRow(BKing, 0);
            Grid.SetColumn(BKing, 4);

            //WhitePieces
            Grid.SetRow(WPawn1, 6);
            Grid.SetColumn(WPawn1, 0);
            Grid.SetRow(WPawn2, 6);
            Grid.SetColumn(WPawn2, 1);
            Grid.SetRow(WPawn3, 6);
            Grid.SetColumn(WPawn3, 2);
            Grid.SetRow(WPawn4, 6);
            Grid.SetColumn(WPawn4, 3);
            Grid.SetRow(WPawn5, 6);
            Grid.SetColumn(WPawn5, 4);
            Grid.SetRow(WPawn6, 6);
            Grid.SetColumn(WPawn6, 5);
            Grid.SetRow(WPawn7, 6);
            Grid.SetColumn(WPawn7, 6);
            Grid.SetRow(WPawn8, 6);
            Grid.SetColumn(WPawn8, 7);

            Grid.SetRow(WRook1, 7);
            Grid.SetColumn(WRook1, 0);
            Grid.SetRow(WRook2, 7);
            Grid.SetColumn(WRook2, 7);
            Grid.SetRow(WKnight1, 7);
            Grid.SetColumn(WKnight1, 1);
            Grid.SetRow(WKnight2, 7);
            Grid.SetColumn(WKnight2, 6);
            Grid.SetRow(WBishop1, 7);
            Grid.SetColumn(WBishop1, 2);
            Grid.SetRow(WBishop2, 7);
            Grid.SetColumn(WBishop2, 5);
            Grid.SetRow(WQueen, 7);
            Grid.SetColumn(WQueen, 3);
            Grid.SetRow(WKing, 7);
            Grid.SetColumn(WKing, 4);

            foreach (Image image in Board.Children)
                image.Opacity = 1;
        }

        public void InitializeWhiteBoard()
        {
            Board.Children.Add(BPawn1);
            Board.Children.Add(BPawn2);
            Board.Children.Add(BPawn3);
            Board.Children.Add(BPawn4);
            Board.Children.Add(BPawn5);
            Board.Children.Add(BPawn6);
            Board.Children.Add(BPawn7);
            Board.Children.Add(BPawn8);

            Board.Children.Add(BRook1);
            Board.Children.Add(BRook2);
            Board.Children.Add(BKnight1);
            Board.Children.Add(BKnight2);
            Board.Children.Add(BBishop1);
            Board.Children.Add(BBishop2);
            Board.Children.Add(BQueen);
            Board.Children.Add(BKing);

            Board.Children.Add(WPawn1);
            Board.Children.Add(WPawn2);
            Board.Children.Add(WPawn3);
            Board.Children.Add(WPawn4);
            Board.Children.Add(WPawn5);
            Board.Children.Add(WPawn6);
            Board.Children.Add(WPawn7);
            Board.Children.Add(WPawn8);

            Board.Children.Add(WRook1);
            Board.Children.Add(WRook2);
            Board.Children.Add(WKnight1);
            Board.Children.Add(WKnight2);
            Board.Children.Add(WBishop1);
            Board.Children.Add(WBishop2);
            Board.Children.Add(WQueen);
            Board.Children.Add(WKing);
        }

        public void SetBlackBoard()
        {
            //BlackPieces
            Grid.SetRow(BPawn1, 6);
            Grid.SetColumn(BPawn1, 7);
            Grid.SetRow(BPawn2, 6);
            Grid.SetColumn(BPawn2, 6);
            Grid.SetRow(BPawn3, 6);
            Grid.SetColumn(BPawn3, 5);
            Grid.SetRow(BPawn4, 6);
            Grid.SetColumn(BPawn4, 4);
            Grid.SetRow(BPawn5, 6);
            Grid.SetColumn(BPawn5, 3);
            Grid.SetRow(BPawn6, 6);
            Grid.SetColumn(BPawn6, 2);
            Grid.SetRow(BPawn7, 6);
            Grid.SetColumn(BPawn7, 1);
            Grid.SetRow(BPawn8, 6);
            Grid.SetColumn(BPawn8, 0);

            Grid.SetRow(BRook1, 7);
            Grid.SetColumn(BRook1, 7);
            Grid.SetRow(BRook2, 7);
            Grid.SetColumn(BRook2, 0);
            Grid.SetRow(BKnight1, 7);
            Grid.SetColumn(BKnight1, 6);
            Grid.SetRow(BKnight2, 7);
            Grid.SetColumn(BKnight2, 1);
            Grid.SetRow(BBishop1, 7);
            Grid.SetColumn(BBishop1, 5);
            Grid.SetRow(BBishop2, 7);
            Grid.SetColumn(BBishop2, 2);
            Grid.SetRow(BQueen, 7);
            Grid.SetColumn(BQueen, 4);
            Grid.SetRow(BKing, 7);
            Grid.SetColumn(BKing, 3);

            //WhitePieces
            Grid.SetRow(WPawn1, 1);
            Grid.SetColumn(WPawn1, 7);
            Grid.SetRow(WPawn2, 1);
            Grid.SetColumn(WPawn2, 6);
            Grid.SetRow(WPawn3, 1);
            Grid.SetColumn(WPawn3, 5);
            Grid.SetRow(WPawn4, 1);
            Grid.SetColumn(WPawn4, 4);
            Grid.SetRow(WPawn5, 1);
            Grid.SetColumn(WPawn5, 3);
            Grid.SetRow(WPawn6, 1);
            Grid.SetColumn(WPawn6, 2);
            Grid.SetRow(WPawn7, 1);
            Grid.SetColumn(WPawn7, 1);
            Grid.SetRow(WPawn8, 1);
            Grid.SetColumn(WPawn8, 0);

            Grid.SetRow(WRook1, 0);
            Grid.SetColumn(WRook1, 7);
            Grid.SetRow(WRook2, 0);
            Grid.SetColumn(WRook2, 0);
            Grid.SetRow(WKnight1, 0);
            Grid.SetColumn(WKnight1, 6);
            Grid.SetRow(WKnight2, 0);
            Grid.SetColumn(WKnight2, 1);
            Grid.SetRow(WBishop1, 0);
            Grid.SetColumn(WBishop1, 5);
            Grid.SetRow(WBishop2, 0);
            Grid.SetColumn(WBishop2, 2);
            Grid.SetRow(WQueen, 0);
            Grid.SetColumn(WQueen, 4);
            Grid.SetRow(WKing, 0);
            Grid.SetColumn(WKing, 3);

            foreach (Image image in Board.Children)
                image.Opacity = 1;
        }

        public void InitialiseBlackBoard()
        {
            Board.Children.Add(BPawn1);
            Board.Children.Add(BPawn2);
            Board.Children.Add(BPawn3);
            Board.Children.Add(BPawn4);
            Board.Children.Add(BPawn5);
            Board.Children.Add(BPawn6);
            Board.Children.Add(BPawn7);
            Board.Children.Add(BPawn8);

            Board.Children.Add(BRook1);
            Board.Children.Add(BRook2);
            Board.Children.Add(BKnight1);
            Board.Children.Add(BKnight2);
            Board.Children.Add(BBishop1);
            Board.Children.Add(BBishop2);
            Board.Children.Add(BQueen);
            Board.Children.Add(BKing);

            Board.Children.Add(WPawn1);
            Board.Children.Add(WPawn2);
            Board.Children.Add(WPawn3);
            Board.Children.Add(WPawn4);
            Board.Children.Add(WPawn5);
            Board.Children.Add(WPawn6);
            Board.Children.Add(WPawn7);
            Board.Children.Add(WPawn8);

            Board.Children.Add(WRook1);
            Board.Children.Add(WRook2);
            Board.Children.Add(WKnight1);
            Board.Children.Add(WKnight2);
            Board.Children.Add(WBishop1);
            Board.Children.Add(WBishop2);
            Board.Children.Add(WQueen);
            Board.Children.Add(WKing);
        }

        public Image GetPiece(int col, int row)
        {
            Image x = (Image)Board.Children
                .Cast<UIElement>()
                .Last(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == row);    

            return x;
        }

        public Image GetPieceTaken(int col, int row)
        {
            Image x = (Image)Board.Children
                .Cast<UIElement>()
                .First(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == row && e.Opacity == 0);

            return x;
        }

        public Image GetPieceOn(int col, int row)
        {
            Image x = (Image)Board.Children
                .Cast<UIElement>()
                .Last(e => Grid.GetColumn(e) == col && Grid.GetRow(e) == row && e.Opacity == 1);

            return x;
        }

        public void MovePiece(int StartCol, int StartRow, int EndCol, int EndRow)
        {
            Image Piece = GetPiece(StartCol, StartRow);
            Piece.Opacity = 1;

            Grid.SetColumn(Piece, EndCol);
            Grid.SetRow(Piece, EndRow);

        }

        public void MovePieceByID(Image Piece, int EndCol, int EndRow)
        {
            Piece.Opacity = 1;

            Grid.SetColumn(Piece, EndCol);
            Grid.SetRow(Piece, EndRow);

        }
    }
}
