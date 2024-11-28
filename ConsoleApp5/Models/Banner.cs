using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banner.Models
{
    public class Banner : ABanner, IBannerOperations
    {
        public void Clear()
        {
            for (int rowIndex = 0; rowIndex < RowNum; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < ColumnNum; columnIndex++)
                {
                    this[rowIndex, columnIndex] = Color.Black;
                }
            }

        }

        public void DrawLine(int rowIndex, Color drawingColor)
        {
            if (RowNum - 1 < rowIndex)
            {
                throw new Exception("index out of range");
            }
            for (int i = 0; i < ColumnNum; i++)
            {
                this[rowIndex, i] = drawingColor; 
            }
        }

        public void RotateToLeft()
        {
            for (int rowIndex = 0; rowIndex < RowNum; rowIndex++)
            {
                Color temp = this[rowIndex, 0];
                for (int columnIndex = 1; columnIndex < ColumnNum; columnIndex++)
                {
                    this[rowIndex, columnIndex - 1] = this[rowIndex, columnIndex];
                }
                this[rowIndex, ColumnNum - 1] = temp;
            }
        }

        public void RotateToRight()
        {
            for (int rowIndex = 0; rowIndex < RowNum; rowIndex++)
            {
                Color temp = this[rowIndex, ColumnNum - 1];
                for (int columnIndex = RowNum - 1; columnIndex > 0; columnIndex--)
                {
                    this[rowIndex, columnIndex] = this[rowIndex, columnIndex - 1];
                }
                this[rowIndex, 0] = temp;
            }
        }

        public void ShiftToLeft(Color fillColor)
        {
            for (int rowIndex = 0; rowIndex < RowNum; rowIndex++)
            {
                for (int columnIndex = 1; columnIndex < ColumnNum; columnIndex++)
                {
                    this[rowIndex, columnIndex - 1] = this[rowIndex, columnIndex];
                }
                this[rowIndex, ColumnNum - 1] = fillColor;
            }
        }

        public void ShiftToRight(Color fillColor)
        {
            for (int rowIndex = 0; rowIndex < RowNum; rowIndex++)
            {
                for (int columnIndex = RowNum - 1; columnIndex > 0; columnIndex--)
                {
                    this[rowIndex, columnIndex] = this[rowIndex, columnIndex - 1];
                }
                this[rowIndex, 0] = fillColor;
            }
        }
    }
}
