﻿using System;
using System.Collections.Generic;
using Microsoft.Office.Interop.Word;

namespace HaoLib
{
    public class Report2
    {
        private Application wordApp = null;
        private Document wordDoc = null;

        // 通过模板创建新文档
        public void CreateNewDocument(string filePath)
        {
            try
            {
                killWinWordProcess();
                wordApp = new ApplicationClass();
                wordApp.DisplayAlerts = WdAlertLevel.wdAlertsNone;
                wordApp.Visible = false;
                object missing = System.Reflection.Missing.Value;
                object templateName = filePath;
                wordDoc = wordApp.Documents.Open(ref templateName, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing, ref missing,
                    ref missing, ref missing, ref missing, ref missing);
            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message);
            }
        }

        // 保存新文件
        public void SaveDocument(string filePath)
        {
            object fileName = filePath;
            object format = WdSaveFormat.wdFormatDocument;//保存格式
            object miss = System.Reflection.Missing.Value;

            try
            {
                wordDoc.SaveAs(ref fileName, ref format, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss, ref miss, ref miss, ref miss,
                    ref miss);
            }
            catch (Exception ex)
            {
                // 处理保存文档时发生的错误
                Console.WriteLine("保存文档时发生错误: " + ex.Message);
                // 根据需要记录日志或显示错误消息
            }

            // 关闭wordDoc，wordApp对象
            object SaveChanges = WdSaveOptions.wdSaveChanges;
            object OriginalFormat = WdOriginalFormat.wdOriginalDocumentFormat;
            object RouteDocument = false;
            wordDoc.Close(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
            wordApp.Quit(ref SaveChanges, ref OriginalFormat, ref RouteDocument);
        }


        // 在书签处插入值
        public bool InsertValue(string bookmark, string value)
        {
            object bkObj = bookmark;
            if (wordApp.ActiveDocument.Bookmarks.Exists(bookmark))
            {
                wordApp.ActiveDocument.Bookmarks.get_Item(ref bkObj).Select();
                wordApp.Selection.TypeText(value);
                return true;
            }
            return false;
        }

        // 插入表格,bookmark书签
        public Table InsertTable(string bookmark, int rows, int columns, float width)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            Range range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//表格插入位置
            Table newTable = wordDoc.Tables.Add(range, rows, columns, ref miss, ref miss);
            //设置表的格式
            newTable.Borders.Enable = 1;  //允许有边框，默认没有边框(为0时报错，1为实线边框，2、3为虚线边框，以后的数字没试过)
            newTable.Borders.OutsideLineWidth = WdLineWidth.wdLineWidth050pt;//边框宽度
            if (width != 0)
            {
                newTable.PreferredWidth = width;//表格宽度
            }
            newTable.AllowPageBreaks = false;
            return newTable;
        }



        // 合并单元格 表id,开始行号,开始列号,结束行号,结束列号
        public void MergeCell(int n, int row1, int column1, int row2, int column2)
        {
            wordDoc.Content.Tables[n].Cell(row1, column1).Merge(wordDoc.Content.Tables[n].Cell(row2, column2));
        }

        // 合并单元格 表名,开始行号,开始列号,结束行号,结束列号
        public void MergeCell(string tableName, int row1, int column1, int row2, int column2)
        {
            Table table = wordDoc.Content.Tables[1]; // 假设你想要操作第一个表格
            // 这里需要一个方法来获取表格的索引，或者你需要在其他地方记录表格的索引

            // 获取实际的行和列号
            int actualRow1 = row1 - 1; // 由于表格索引从1开始，所以需要减1
            int actualColumn1 = column1 - 1; // 同样，列索引也需要减1
            int actualRow2 = row2 - 1;
            int actualColumn2 = column2 - 1;

            // 合并单元格
            table.Cell(actualRow1, actualColumn1).Merge(table.Cell(actualRow2, actualColumn2));
        }


        // 设置表格内容对齐方式 Align水平方向，Vertical垂直方向(左对齐，居中对齐，右对齐分别对应Align和Vertical的值为-1,0,1)
        public void SetParagraph_Table(int n, int Align, int Vertical)
        {
            switch (Align)
            {
                case -1: wordDoc.Content.Tables[n].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft; break;//左对齐
                case 0: wordDoc.Content.Tables[n].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter; break;//水平居中
                case 1: wordDoc.Content.Tables[n].Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; break;//右对齐
            }
            switch (Vertical)
            {
                case -1: wordDoc.Content.Tables[n].Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop; break;//顶端对齐
                case 0: wordDoc.Content.Tables[n].Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; break;//垂直居中
                case 1: wordDoc.Content.Tables[n].Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom; break;//底端对齐
            }
        }

        // 设置单元格内容对齐方式
        public void SetParagraph_Table(int n, int row, int column, int Align, int Vertical)
        {
            switch (Align)
            {
                case -1: wordDoc.Content.Tables[n].Cell(row, column).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphLeft; break;//左对齐
                case 0: wordDoc.Content.Tables[n].Cell(row, column).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphCenter; break;//水平居中
                case 1: wordDoc.Content.Tables[n].Cell(row, column).Range.ParagraphFormat.Alignment = WdParagraphAlignment.wdAlignParagraphRight; break;//右对齐
            }
            switch (Vertical)
            {
                case -1: wordDoc.Content.Tables[n].Cell(row, column).Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalTop; break;//顶端对齐
                case 0: wordDoc.Content.Tables[n].Cell(row, column).Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalCenter; break;//垂直居中
                case 1: wordDoc.Content.Tables[n].Cell(row, column).Range.Cells.VerticalAlignment = WdCellVerticalAlignment.wdCellAlignVerticalBottom; break;//底端对齐
            }
        }

        // 设置表格字体
        public void SetFont_Table(int tableIndex, string fontName, double size)
        {
            Table table = wordDoc.Content.Tables[tableIndex];
            if (size != 0)
            {
                table.Range.Font.Size = Convert.ToSingle(size);
            }
            if (fontName != "")
            {
                table.Range.Font.Name = fontName;
            }
        }



        // 设置单元格字体
        public void SetFont_Cell(int n, int row, int column, string fontName, double size, int bold)
        {
            Table table = wordDoc.Content.Tables[n];
            if (size != 0)
            {
                table.Cell(row, column).Range.Font.Size = Convert.ToSingle(size);
            }
            if (fontName != "")
            {
                table.Cell(row, column).Range.Font.Name = fontName;
            }
            if (bold != 0)
            {
                table.Cell(row, column).Range.Font.Bold = bold;// 0 表示不是粗体，其他值都是
            }
        }

        // 是否使用边框,n表格的序号,use是或否
        // 该处边框参数可以用int代替bool可以让方法更全面
        // 具体值方法中介绍
        public void UseBorder(int n, bool use)
        {
            if (use)
            {
                wordDoc.Content.Tables[n].Borders.Enable = 1;
                //允许有边框，默认没有边框(为0时无边框，1为实线边框，2、3为虚线边框，以后的数字没试过)
            }
            else
            {
                wordDoc.Content.Tables[n].Borders.Enable = 0;
            }
        }

        // 给表格插入一行,n表格的序号从1开始记
        public void AddRow(int n)
        {
            object miss = System.Reflection.Missing.Value;
            wordDoc.Content.Tables[n].Rows.Add(ref miss);
        }

        // 给第一个表格添加一行
        public void AddRowToFirstTable()
        {
            object miss = System.Reflection.Missing.Value;
            wordDoc.Content.Tables[1].Rows.Add(ref miss); // 假设你想要操作第一个表格
        }




        // 给表格插入rows行,n为表格的序号
        public void AddRow(int n, int rows)
        {
            object miss = System.Reflection.Missing.Value;
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < rows; i++)
            {
                table.Rows.Add(ref miss);
            }
        }

        // 删除表格第rows行,n为表格的序号
        public void DeleteRow(int n, int row)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            table.Rows[row].Delete();
        }

        // 给表格中单元格插入元素，table所在表格，row行号，column列号，value插入的元素
        public void InsertCell(int tableIndex, int row, int column, string value)
        {
            Table table = wordDoc.Content.Tables[tableIndex];
            table.Cell(row, column).Range.Text = value;
        }



        // 给表格插入一行数据，n为表格的序号，row行号，columns列数，values插入的值
        public void InsertCell(int n, int row, int columns, string[] values)
        {
            Microsoft.Office.Interop.Word.Table table = wordDoc.Content.Tables[n];
            for (int i = 0; i < columns; i++)
            {
                table.Cell(row, i + 1).Range.Text = values[i];
            }
        }

        // 插入图片
        public void InsertPicture(string bookmark, string picturePath, float width, float height)
        {
            object miss = System.Reflection.Missing.Value;
            object oStart = bookmark;
            object linkToFile = false;       //图片是否为外部链接
            object saveWithDocument = true;  //图片是否随文档一起保存 
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;//图片插入位置
            wordDoc.InlineShapes.AddPicture(picturePath, ref linkToFile, ref saveWithDocument, ref range);
            //wordDoc.Application.ActiveDocument.InlineShapes[1].Width = width;   //设置图片宽度
            //wordDoc.Application.ActiveDocument.InlineShapes[1].Height = height;  //设置图片高度
        }

        // 插入一段文字,text为文字内容
        public void InsertText(string bookmark, string text)
        {
            object oStart = bookmark;
            object range = wordDoc.Bookmarks.get_Item(ref oStart).Range;
            Paragraph wp = wordDoc.Content.Paragraphs.Add(ref range);
            wp.Format.SpaceBefore = 6;
            wp.Range.Text = text;
            wp.Format.SpaceAfter = 24;
            wp.Range.InsertParagraphAfter();
            wordDoc.Paragraphs.Last.Range.Text = "\n";
        }

        // 杀掉winword.exe进程
        public void killWinWordProcess()
        {
            System.Diagnostics.Process[] processes = System.Diagnostics.Process.GetProcessesByName("WINWORD");
            foreach (System.Diagnostics.Process process in processes)
            {
                bool b = process.MainWindowTitle == "";
                if (process.MainWindowTitle == "")
                {
                    process.Kill();
                }
            }
            System.Diagnostics.Process[] processes1 = System.Diagnostics.Process.GetProcessesByName("wps");
            foreach (System.Diagnostics.Process process1 in processes1)
            {
                bool b = process1.MainWindowTitle == "";
                if (process1.MainWindowTitle == "")
                {
                    process1.Kill();
                }
            }
        }

    }
}
