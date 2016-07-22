using System;
using System.Collections.Generic;
using System.Text;

 namespace Nikita.Report.WinForm
{
    class MatrixRdlGenerator
    {
        private List<string> m_rowFields;
        private List<string> m_columnFields;
        private List<string> m_summarizedFields;
        private string m_rowHeight = "11pt";
        private string m_cellFormat = "c0";
        private string m_columnWidth = "0.75in";
        private string m_left = "5pt";
        private string m_top = "5pt";

        private int m_groupingCount = 0;
        private int m_textboxCount = 0;
        private string m_matrixName = "Matrix1";

        public List<string> RowFields
        {
            get { return m_rowFields; }
            set { m_rowFields = value; }
        }

        public List<string> ColumnFields
        {
            get { return m_columnFields; }
            set { m_columnFields = value; }
        }

        public List<string> SummarizedFields
        {
            get { return m_summarizedFields; }
            set { m_summarizedFields = value; }
        }

        public Rdl.MatrixType CreateMatrix()
        {
            Rdl.MatrixType matrix = new Rdl.MatrixType();
            matrix.Name = m_matrixName;
            matrix.Items = new object[]
                {
                    CreateColumnGroupings(),
                    CreateRowGroupings(),
                    CreateMatrixRows(),
                    CreateMatrixColumns(),
                    CreateCorner(),
                    m_left,
                    m_top,
                };
            matrix.ItemsElementName = new Rdl.ItemsChoiceType19[]
                {
                    Rdl.ItemsChoiceType19.ColumnGroupings,
                    Rdl.ItemsChoiceType19.RowGroupings,
                    Rdl.ItemsChoiceType19.MatrixRows,
                    Rdl.ItemsChoiceType19.MatrixColumns,
                    Rdl.ItemsChoiceType19.Corner,
                    Rdl.ItemsChoiceType19.Left,
                    Rdl.ItemsChoiceType19.Top,
                };
            return matrix;
        }

        private Rdl.CornerType CreateCorner()
        {
            Rdl.CornerType corner = new Rdl.CornerType();
            corner.Items = new object[]
                {
                    CreateReportItems(new object[] { CreateTextbox("", null) }),
                };
            return corner;
        }

        private Rdl.ColumnGroupingsType CreateColumnGroupings()
        {
            Rdl.ColumnGroupingsType columnGroupings = new Rdl.ColumnGroupingsType();
            int columnGroupingCount = m_columnFields.Count;
            if (m_summarizedFields.Count > 1)
                columnGroupingCount++;
            columnGroupings.ColumnGrouping = new Rdl.ColumnGroupingType[columnGroupingCount];
            for (int i = 0; i < m_columnFields.Count; i++)
                columnGroupings.ColumnGrouping[i] = CreateDynamicColumnGrouping(m_columnFields[i]);
            if (m_summarizedFields.Count > 1)
            {
                int staticColumnsIndex = columnGroupings.ColumnGrouping.Length - 1;
                columnGroupings.ColumnGrouping[staticColumnsIndex] = CreateStaticColumnGrouping();
            }
            return columnGroupings;
        }

        private Rdl.ColumnGroupingType CreateStaticColumnGrouping()
        {
            Rdl.ColumnGroupingType columnGrouping = new Rdl.ColumnGroupingType();
            columnGrouping.Items = new object[]
                 {
                     m_rowHeight,
                     CreateStaticColumns(),
                 };
            return columnGrouping;
        }

        private Rdl.StaticColumnsType CreateStaticColumns()
        {
            Rdl.StaticColumnsType staticColumns = new Rdl.StaticColumnsType();
            staticColumns.StaticColumn = new Rdl.StaticColumnType[m_summarizedFields.Count];
            for (int i = 0; i < m_summarizedFields.Count; i++)
            {
                staticColumns.StaticColumn[i] = CreateStaticColumn(m_summarizedFields[i]);
            }
            return staticColumns;
        }

        private Rdl.StaticColumnType CreateStaticColumn(string fieldName)
        {
            Rdl.StaticColumnType staticColumn = new Rdl.StaticColumnType();
            staticColumn.Items = new object[]
                 {
                     CreateReportItems(new object[] { CreateTextbox(fieldName, CreateHeaderStyle()) }),
                 };
            return staticColumn;
        }

        private Rdl.ColumnGroupingType CreateDynamicColumnGrouping(string fieldName)
        {
            Rdl.ColumnGroupingType columnGrouping = new Rdl.ColumnGroupingType();
            columnGrouping.Items = new object[]
                 {
                     m_rowHeight,
                     CreateDynamicColumnsRows(fieldName),
                 };
            return columnGrouping;
        }

        private Rdl.DynamicColumnsRowsType CreateDynamicColumnsRows(string fieldName)
        {
            Rdl.DynamicColumnsRowsType dynamicColumnsRows = new Rdl.DynamicColumnsRowsType();
            dynamicColumnsRows.Items = new object[]
                 {
                     CreateGrouping(fieldName),
                     CreateReportItems(new object[] { CreateTextbox("=Fields!" + fieldName + ".Value", CreateHeaderStyle()) }),
                 };
            return dynamicColumnsRows;
        }

        private Rdl.StyleType CreateHeaderStyle()
        {
            Rdl.StyleType style = new Rdl.StyleType();
            style.Items = new object[]
                 {
                     "#DAE9F3",
                     CreateBorderColorStyleWidth("#74A4D4"),
                     CreateBorderColorStyleWidth("Solid"),
                     "Tahoma",
                     "8pt",
                     "Center",
                     "Middle",
                     CreateBorderColorStyleWidth("0.5pt"),
                 };
            style.ItemsElementName = new Rdl.ItemsChoiceType5[]
                 {
                     Rdl.ItemsChoiceType5.BackgroundColor,
                     Rdl.ItemsChoiceType5.BorderColor,
                     Rdl.ItemsChoiceType5.BorderStyle,
                     Rdl.ItemsChoiceType5.FontFamily,
                     Rdl.ItemsChoiceType5.FontSize,
                     Rdl.ItemsChoiceType5.TextAlign,
                     Rdl.ItemsChoiceType5.VerticalAlign,
                     Rdl.ItemsChoiceType5.BorderWidth,
                 };
            return style;
        }

        Rdl.BorderColorStyleWidthType CreateBorderColorStyleWidth(string s)
        {
            Rdl.BorderColorStyleWidthType b = new Rdl.BorderColorStyleWidthType();
            b.Items = new object[]
                 {
                     s,
                 };
            b.ItemsElementName = new Rdl.ItemsChoiceType3[]
                 {
                     Rdl.ItemsChoiceType3.Default,
                 };
            return b;
        }

        private Rdl.GroupingType CreateGrouping(string fieldName)
        {
            Rdl.GroupingType grouping = new Rdl.GroupingType();
            grouping.Name = m_matrixName + "_Group" + (++m_groupingCount);
            grouping.Items = new object[]
                 {
                     CreateGroupExpressions(new string[] { fieldName }),
                 };
            grouping.ItemsElementName = new Rdl.ItemsChoiceType17[]
                 {
                     Rdl.ItemsChoiceType17.GroupExpressions,
                 };
            return grouping;
        }

        private Rdl.GroupExpressionsType CreateGroupExpressions(string[] fieldNames)
        {
            Rdl.GroupExpressionsType groupExpressions = new Rdl.GroupExpressionsType();
            groupExpressions.GroupExpression = new string[fieldNames.Length];
            for (int i = 0; i < fieldNames.Length; i++)
                groupExpressions.GroupExpression[i] = "=Fields!" + fieldNames[i] + ".Value";
            return groupExpressions;
        }

        private Rdl.ReportItemsType CreateReportItems(object[] reportItemArray)
        {
            Rdl.ReportItemsType reportItems = new Rdl.ReportItemsType();
            reportItems.Items = reportItemArray;
            return reportItems;
        }

        private Rdl.TextboxType CreateTextbox(string expression, Rdl.StyleType style)
        {
            Rdl.TextboxType textbox = new Rdl.TextboxType();
            textbox.Name = "Textbox" + (++m_textboxCount);
            textbox.Items = new object[]
                 {
                     expression,
                     true,
                     style,
                 };
            textbox.ItemsElementName = new Rdl.ItemsChoiceType14[]
                 {
                     Rdl.ItemsChoiceType14.Value,
                     Rdl.ItemsChoiceType14.CanGrow,
                     Rdl.ItemsChoiceType14.Style,
                 };
            return textbox;
        }

        private Rdl.RowGroupingsType CreateRowGroupings()
        {
            Rdl.RowGroupingsType rowGroupings = new Rdl.RowGroupingsType();
            rowGroupings.RowGrouping = new Rdl.RowGroupingType[m_rowFields.Count];
            for (int i = 0; i < m_rowFields.Count; i++)
                rowGroupings.RowGrouping[i] = CreateRowGrouping(m_rowFields[i]);
            return rowGroupings;
        }

        private Rdl.RowGroupingType CreateRowGrouping(string fieldName)
        {
            Rdl.RowGroupingType rowGrouping = new Rdl.RowGroupingType();
            rowGrouping.Items = new object[]
                 {
                     "0.75in",
                     CreateDynamicColumnsRows(fieldName),
                 };
            return rowGrouping;
        }

        private Rdl.MatrixRowsType CreateMatrixRows()
        {
            Rdl.MatrixRowsType matrixRows = new Rdl.MatrixRowsType();
            matrixRows.MatrixRow = CreateMatrixRow();
            return matrixRows;
        }

        private Rdl.MatrixRowType[] CreateMatrixRow()
        {
            Rdl.MatrixRowType[] matrixRow = new Rdl.MatrixRowType[1];
            matrixRow[0] = new Rdl.MatrixRowType();
            matrixRow[0].Items = new object[]
                 {
                     m_rowHeight,
                     CreateMatrixCells(),
                 };
            return matrixRow;
        }

        private Rdl.MatrixCellsType CreateMatrixCells()
        {
            Rdl.MatrixCellsType matrixCells = new Rdl.MatrixCellsType();
            matrixCells.MatrixCell = new Rdl.MatrixCellType[m_summarizedFields.Count];
            for (int i = 0; i < matrixCells.MatrixCell.Length; i++)
            {
                matrixCells.MatrixCell[i] = CreateMatrixCell(m_summarizedFields[i]);
            }
            return matrixCells;
        }

        private Rdl.MatrixCellType CreateMatrixCell(string fieldName)
        {
            Rdl.MatrixCellType matrixCell = new Rdl.MatrixCellType();
            string expression = "=Sum(CDbl(Fields!" + fieldName + ".Value))";
            matrixCell.Items = new object[]
                {
                    CreateReportItems(new object[] { CreateTextbox(expression, CreateCellStyle()) }),
                };
            return matrixCell;
        }

        private Rdl.StyleType CreateCellStyle()
        {
            Rdl.StyleType style = new Rdl.StyleType();
            style.Items = new object[]
                 {
                     CreateBorderColorStyleWidth("#74A4D4"),
                     CreateBorderColorStyleWidth("Solid"),
                     "Tahoma",
                     "8pt",
                     "Middle",
                     m_cellFormat,
                     CreateBorderColorStyleWidth("0.5pt"),
                 };
            style.ItemsElementName = new Rdl.ItemsChoiceType5[]
                 {
                     Rdl.ItemsChoiceType5.BorderColor,
                     Rdl.ItemsChoiceType5.BorderStyle,
                     Rdl.ItemsChoiceType5.FontFamily,
                     Rdl.ItemsChoiceType5.FontSize,
                     Rdl.ItemsChoiceType5.VerticalAlign,
                     Rdl.ItemsChoiceType5.Format,
                     Rdl.ItemsChoiceType5.BorderWidth,
                 };
            return style;
        }

        private Rdl.MatrixColumnsType CreateMatrixColumns()
        {
            Rdl.MatrixColumnsType matrixColumns = new Rdl.MatrixColumnsType();
            matrixColumns.MatrixColumn = CreateMatrixColumn();
            return matrixColumns;
        }

        private Rdl.MatrixColumnType[] CreateMatrixColumn()
        {
            Rdl.MatrixColumnType[] matrixColumn = new Rdl.MatrixColumnType[m_summarizedFields.Count];
            for (int i = 0; i < matrixColumn.Length; i++)
            {
                matrixColumn[i] = new Rdl.MatrixColumnType();
                matrixColumn[i].Items = new object[]
                    {
                        m_columnWidth,
                    };
            }
            return matrixColumn;
        }
    }
}
