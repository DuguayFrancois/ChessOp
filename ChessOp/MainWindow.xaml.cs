using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Drawing;
using System.Data.Common;
using System.Reflection;

namespace ChessOp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        List<Image> list = new List<Image>() { };
        ChessGame game = new ChessGame();

        List<string> CountMoves = new List<string>();
        List<Move> WhiteMoves = new List<Move>();
        List<Move> BlackMoves = new List<Move>();
 
        int current = 0;

        List<Opening> Openings = new List<Opening>();
        List<Move> MoveOrder = new List<Move>();

        bool side; //true = White, false = black

        public MainWindow()
        {
            InitializeComponent();
            OrderCourt();
            game.InitialisePieces();
            game.SetWhiteBoard();
            game.InitializeWhiteBoard();
        }

        public void OrderCourt()
        {
            game.Board = Board;

            List<Move> CaroKann = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn3, "Pc7c6"), new Move(game.WPawn4, "Pd2d4"), new Move(game.BPawn4, "Pd7d5"),
                        new Move(game.WPawn5, "Pe4e5"), new Move(game.BPawn3, "Pc6c5"), new Move(game.WPawn3, "Pc2c3"), new Move(game.BKnight1, "Nb8c6"),
                        new Move(game.WKnight2, "Ng1f3"), new Move(game.BBishop1, "Bc8g4"), new Move(game.WBishop2, "Bf1e2"), new Move(game.BPawn5, "Pe7e6")];
                
            List<Move> CaroKannExchange = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn3, "Pc7c6"), new Move(game.WPawn4, "Pd2d4"), new Move(game.BPawn4, "Pd7d5"),
                        new Move(game.WPawn5, "Pe4xd5"), new Move(game.BPawn3, "Pc6xd5"), new Move(game.WBishop2, "Bf1d3"), new Move(game.BKnight1, "Nb8c6"),
                        new Move(game.WPawn2, "Pc2c3"), new Move(game.BKnight2, "Ng8f6")];

            List<Move> Sicilian = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn3, "Pc7c5"), new Move(game.WKnight2, "Ng1f3"), new Move(game.BPawn4, "Pd7d6"),
                        new Move(game.WPawn4, "Pd2d4"), new Move(game.BPawn3, "Pc5xd4"), new Move(game.WKnight2, "Nf3xd4"), new Move(game.BKnight1, "Nb8c6"),
                        new Move(game.WKnight1, "Nb1c3"), new Move(game.BKnight2, "Ng8f6"), new Move(game.WBishop1, "Bc1g5")];

            List<Move> Scotch = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn5, "Pe7e5"), new Move(game.WKnight2, "Ng1f3"), new Move(game.BKnight1, "Nb8c6"),
                                new Move(game.WPawn4, "Pd2d4"), new Move(game.BPawn5, "Pe5xd4"), new Move(game.WKnight2, "Nf3xd4")];

            List<Move> RuyLopez = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn4, "Pe7e5"), new Move(game.WKnight2, "Ng1f3"), new Move(game.BKnight1, "Nb8c6"),
                                new Move(game.WBishop2, "Bf1b5"), new Move(game.BPawn1, "Pa7a6"), new Move(game.WBishop2, "Bb5a4")];

            List<Move> Berlin = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn5, "Pe7e5"), new Move(game.WKnight2, "Ng1f3"), new Move(game.BKnight1, "Nb8c6"),
                                new Move(game.WBishop2, "Bf1b5"), new Move(game.BKnight2, "Ng8f6"), new Move(game.WPawn4, "Pd2d3")];

            List<Move> Italian = [new Move(game.WPawn5, "Pe2e4"), new Move(game.BPawn5, "Pe7e5"), new Move(game.WKnight2, "Ng1f3"), new Move(game.BKnight1, "Nb8c6"),
                                new Move(game.WBishop2, "Bf1c4"), new Move(game.BBishop2, "Bf8c5"), new Move(game.WPawn3, "Pc2c3")];

            Openings.Add(new Opening(Berlin, "Berlin Defense", false));
            Openings.Add(new Opening(CaroKann, "Caro-Kann Defense: Advance, Botvinnik-Carls Defense", false));
            Openings.Add(new Opening(CaroKannExchange, "Caro-Kann Defense: Exchange Variation", false));
            Openings.Add(new Opening(Italian, "Italian Game", true));
            Openings.Add(new Opening(Scotch, "Scotch Game", true));
            Openings.Add(new Opening(RuyLopez, "Ruy López Opening: Morphy Defense", true));
            Openings.Add(new Opening(Sicilian, "Sicilian Defense: Open", false));

            lb.ItemsSource = Openings;
        }
        private void lbxMoves_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            
            var item = ItemsControl.ContainerFromElement(lbxMoves, e.OriginalSource as DependencyObject) as ListBoxItem;

            if (item != null)
            {
                
                int? sm = lbxMoves.ItemContainerGenerator.IndexFromContainer(item);
                int chosenMove;
                if (sm is not null)
                {
                    if (side)
                    {
                        chosenMove = sm.Value * 2;
                        Move move;

                        if (chosenMove >= current)
                        {
                            for (int i = current; i <= chosenMove; i++)
                            {
                                move = MoveOrder[i];

                                if (move.isTaking)
                                    game.GetPieceOn(move.GetCol(move.EndingPos), move.GetRow(move.EndingPos)).Opacity = 0;

                                game.MovePieceByID(move.Piece,
                                            move.GetCol(move.EndingPos), move.GetRow(move.EndingPos));
                            }

                            current = chosenMove + 1;

                        }

                        else if (chosenMove < current)
                        {
                            for (int i = current - 1; i > chosenMove; i--)
                            {
                                move = MoveOrder[i];
                                game.MovePieceByID(move.Piece,
                                            move.GetCol(move.InitialPos), move.GetRow(move.InitialPos));

                                if (move.isTaking)
                                    game.GetPieceTaken(move.GetCol(move.EndingPos), move.GetRow(move.EndingPos)).Opacity = 1;
                            }

                            current = chosenMove + 1;
                        }
                    }

                    else
                    {
                        chosenMove = sm.Value * 2;
                        Move move;

                        if (chosenMove >= current)
                        {
                            for (int i = current; i <= chosenMove; i++)
                            {
                                move = MoveOrder[i];

                                if (move.isTaking)
                                    game.GetPieceOn(7 - move.GetCol(move.EndingPos), 7 - move.GetRow(move.EndingPos)).Opacity = 0;

                                game.MovePieceByID(move.Piece,
                                            7 - move.GetCol(move.EndingPos), 7 - move.GetRow(move.EndingPos));
                            }

                            current = chosenMove + 1;

                        }

                        else if (chosenMove < current)
                        {
                            for (int i = current - 1; i > chosenMove; i--)
                            {
                                move = MoveOrder[i];
                                game.MovePieceByID(move.Piece,
                                            7 - move.GetCol(move.InitialPos), 7 - move.GetRow(move.InitialPos));

                                if (move.isTaking)
                                    game.GetPieceTaken( 7 - move.GetCol(move.EndingPos), 7 - move.GetRow(move.EndingPos)).Opacity = 1;
                            }

                            current = chosenMove + 1;
                        }
                    }

                }
            }
        }

        private void lbxMovesBlack_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {

            var item = ItemsControl.ContainerFromElement(lbxMovesBlack, e.OriginalSource as DependencyObject) as ListBoxItem;

            if (item != null)
            {

                int? sm = lbxMovesBlack.ItemContainerGenerator.IndexFromContainer(item);
                int chosenMove;
                if (sm is not null)
                {
                    if (side)
                    {
                        chosenMove = sm.Value * 2 + 1;
                        Move move;

                        if (chosenMove >= current)
                        {
                            for (int i = current; i <= chosenMove; i++)
                            {
                                move = MoveOrder[i];

                                if (move.isTaking)
                                    game.GetPieceOn(move.GetCol(move.EndingPos), move.GetRow(move.EndingPos)).Opacity = 0;

                                game.MovePieceByID(move.Piece,
                                            move.GetCol(move.EndingPos), move.GetRow(move.EndingPos));
                            }

                            current = chosenMove + 1;

                        }

                        else if (chosenMove < current)
                        {
                            for (int i = current - 1; i > chosenMove; i--)
                            {
                                move = MoveOrder[i];
                                game.MovePieceByID(move.Piece,
                                            move.GetCol(move.InitialPos), move.GetRow(move.InitialPos));

                                if (move.isTaking)
                                    game.GetPieceTaken(move.GetCol(move.EndingPos), move.GetRow(move.EndingPos)).Opacity = 1;
                            }

                            current = chosenMove + 1;
                        }
                    }

                    else
                    {
                        chosenMove = sm.Value * 2 + 1;
                        Move move;

                        if (chosenMove >= current)
                        {
                            for (int i = current; i <= chosenMove; i++)
                            {
                                move = MoveOrder[i];

                                if (move.isTaking)
                                    game.GetPieceOn(7 - move.GetCol(move.EndingPos), 7 - move.GetRow(move.EndingPos)).Opacity = 0;

                                game.MovePieceByID(move.Piece,
                                            7 - move.GetCol(move.EndingPos), 7 - move.GetRow(move.EndingPos));
                            }

                            current = chosenMove + 1;

                        }

                        else if (chosenMove < current)
                        {
                            for (int i = current - 1; i > chosenMove; i--)
                            {
                                move = MoveOrder[i];
                                game.MovePieceByID(move.Piece,
                                            7 - move.GetCol(move.InitialPos), 7 - move.GetRow(move.InitialPos));

                                if (move.isTaking)
                                    game.GetPieceTaken(7 - move.GetCol(move.EndingPos), 7 - move.GetRow(move.EndingPos)).Opacity = 1;
                            }

                            current = chosenMove + 1;
                        }
                    }
                }
            }
        }

        private void SearchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            List<Opening> NewOpenings = new List<Opening>();
            //foreach (Opening opening in Openings) 
                //NewOpenings.Add(opening);

            foreach (Opening op in Openings)
            {
                if (op.Name.ToUpper().Contains(SearchBar.Text.ToUpper()))
                {
                    NewOpenings.Add(op);
                }
            }

            lb.ItemsSource = NewOpenings;
        }

        private void lb_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            var myOtherList = lb.Items.Cast<Opening>().ToList();
            var item = ItemsControl.ContainerFromElement(lb, e.OriginalSource as DependencyObject) as ListBoxItem;

            int? sm = lb.ItemContainerGenerator.IndexFromContainer(item);

            if (sm != null)
            {
                lbxMoves.ItemsSource = myOtherList[sm.Value].Moves;
                lbxMovesBlack.ItemsSource = myOtherList[sm.Value].Moves;
                lbxCount.ItemsSource = 
                MoveOrder = myOtherList[sm.Value].Moves;
                side = myOtherList[sm.Value].Side;
                current = 0;

                //White or Black
                if (side)
                    game.SetWhiteBoard();
                else
                    game.SetBlackBoard();

                //Set Moves in box
                WhiteMoves.Clear();
                BlackMoves.Clear();
                CountMoves.Clear();

                for (int i = 0; i < MoveOrder.Count; i++)
                {
                    if (i % 2 == 0)
                    {
                        WhiteMoves.Add(MoveOrder[i]);
                        CountMoves.Add((i / 2 + 1).ToString() + ".");
                    }
                    else
                        BlackMoves.Add(MoveOrder[i]);
                }
                lbxMoves.ItemsSource = WhiteMoves;
                lbxCount.ItemsSource = CountMoves;
                lbxMovesBlack.ItemsSource = BlackMoves;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Application.Current.Shutdown();
        }

        private void FlipButton_Click(object sender, RoutedEventArgs e)
        {
            side = !side;
            if (side)
            {
                game.SetWhiteBoard();
                
            }
            else
                game.SetBlackBoard();

            current = 0;
        }
    }
}