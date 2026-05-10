using System.Text.RegularExpressions;

namespace TPCWare.BlazorChessTutor.Models
{
    public enum SquareColor
    {
        White,
        Black
    }

    internal static partial class ChessboardSquare
    {
        [GeneratedRegex(@"^[a-l]{1}[1-8]{1}$")]
        private static partial Regex SquareLabelRegex();

        internal static int GetIndex(string squareLabel)
        {
            // check if label is a 2 chars string where the firts one is in the a-l range
            // and the second char is from 1 to 8
            if (SquareLabelRegex().IsMatch(squareLabel))
            {
                return (squareLabel[0] - 'a' + 1) + (squareLabel[1] - '1') * 8;
            }
            else
            {
                throw new ArgumentException("Invalid square label");
            }
        }

        internal static int GetIndex(int squareRow, int squareCol)
        {
            if (squareRow >= 1 && squareRow <= 8 && squareCol >= 1 && squareCol <= 8)
            {
                return (squareRow - 1) * 8 + squareCol;
            }
            else
            {
                throw new ArgumentException("Invalid row or column index");
            }
        }

        internal static string GetLabel(int squareIndex)
        {
            string colLabels = "abcdefgh";
            string rowLabels = "12345678";

            if (squareIndex >= 1 && squareIndex <= 64)
            {
                return colLabels[(squareIndex - 1) % 8].ToString() + rowLabels[(squareIndex - 1) / 8];
            }
            else
            {
                throw new ArgumentException("Invalid square index");
            }
        }

        internal static string GetLabel(int squareRow, int squareCol)
        {
            if (squareRow >= 1 && squareRow <= 8 && squareCol >= 1 && squareCol <= 8)
            {
                return GetLabel((squareRow - 1) * 8 + squareCol);
            }
            else
            {
                throw new ArgumentException("Invalid row or column index");
            }
        }

        internal static (int squareRow, int squareCol) GetRowCol(int squareIndex)
        {
            int squareCol = (squareIndex - 1) % 8;
            int squareRow = (squareIndex - 1) / 8;

            return (squareRow, squareCol);
        }

        internal static (int squareRow, int squareCol) GetRowCol(string squareLabel)
        {
            return GetRowCol(GetIndex(squareLabel));
        }

        internal static SquareColor GetColor(int squareRow, int squareCol)
        {
            int rowParity = squareRow % 2;
            int colParity = squareCol % 2;
            return ((rowParity + colParity) % 2) == 1 ? SquareColor.White : SquareColor.Black;
        }

        internal static SquareColor GetColor(int squareIndex)
        {
            var (squareRow, squareCol) = GetRowCol(squareIndex);
            return GetColor(squareRow, squareCol);
        }

        internal static SquareColor GetColor(string squareLabel)
        {
            return GetColor(GetIndex(squareLabel));
        }
    }
}