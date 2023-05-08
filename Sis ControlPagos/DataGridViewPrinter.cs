using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PdfSharp.Drawing;

public class DataGridViewPrinter
{
    private DataGridView dataGridView;
    private XGraphics graphics;
    private XRect pageBounds;
    private XFont font;
    private XBrush brush;
    private bool centerOnPage;
    private bool drawHeader;
    private int currentPageIndex;
    private int pageCount;
    private int rowHeight;
    private int rowsPerPage;

    public DataGridViewPrinter(DataGridView dataGridView, XGraphics graphics, XRect pageBounds, bool centerOnPage, XFont font, XBrush brush, bool drawHeader)
    {
        this.dataGridView = dataGridView;
        this.graphics = graphics;
        this.pageBounds = pageBounds;
        this.centerOnPage = centerOnPage;
        this.font = font;
        this.brush = brush;
        this.drawHeader = drawHeader;
        currentPageIndex = 0;
        pageCount = 0;
        rowHeight = (int)Math.Ceiling(font.GetHeight());
        rowsPerPage = (int)Math.Floor((pageBounds.Height - (drawHeader ? 2 * rowHeight : 0)) / rowHeight);
    }

    public void DrawDataGridView(Point point)
    {
        double x = pageBounds.Left;
        double y = pageBounds.Top;

        if (centerOnPage)
        {
            x += (pageBounds.Width - DataGridViewWidth()) / 2;
        }

        if (drawHeader)
        {
            DrawHeader(x, y);
            y += 2 * rowHeight;
        }

        DrawRows(x, y);

        pageCount = (int)Math.Ceiling((double)dataGridView.Rows.Count / rowsPerPage);
    }

    private void DrawHeader(double x, double y)
    {
        for (int i = 0; i < dataGridView.Columns.Count; i++)
        {
            string text = dataGridView.Columns[i].HeaderText;
            double width = dataGridView.Columns[i].Width;
            graphics.DrawString(text, font, brush, new XRect(x, y, width, rowHeight), XStringFormats.Center);
            x += width;
        }
    }

    private void DrawRows(double x, double y)
    {
        int rowIndex = currentPageIndex * rowsPerPage;

        while (rowIndex < dataGridView.Rows.Count && y + rowHeight <= pageBounds.Bottom)
        {
            DataGridViewRow row = dataGridView.Rows[rowIndex];
            x = pageBounds.Left;

            for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
                string text = row.Cells[i].FormattedValue.ToString();
                double width = dataGridView.Columns[i].Width;
                graphics.DrawString(text, font, brush, new XRect(x, y, width, rowHeight), XStringFormats.CenterLeft);
                x += width;
            }

            y += rowHeight;
            rowIndex++;
        }
    }

    public bool HasMorePages()
    {
        currentPageIndex++;
        return currentPageIndex < pageCount;
    }

    private double DataGridViewWidth()
    {
        double width = 0;

        for (int i = 0; i < dataGridView.Columns.Count; i++)
            {
            width += dataGridView.Columns[i].Width;
        }

        return width;
    }
}