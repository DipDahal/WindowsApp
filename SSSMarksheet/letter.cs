using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using SSSMarksheet.Properties;
using System.Drawing.Printing;

namespace SSSMarksheet
{
    public partial class letter : Form
    {
        public letter()
        {
            InitializeComponent();
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            Image image = Resources.letterhead;
            e.PageSettings.Margins = new Margins(0, 0, 0, 0);
            e.Graphics.DrawImage(image, 0, 0);

            string body = richMainContent.Text.ToString();
            using (Font font1 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Point))
            {
                RectangleF rectF1 = new RectangleF(60, 450, 730, 500);
                

                StringFormat stringFormat = new StringFormat();
                stringFormat.Alignment = StringAlignment.Near;
                stringFormat.LineAlignment = StringAlignment.Near;

                // Draw the text and the surrounding rectangle.
                e.Graphics.DrawString(body, font1, Brushes.Black, rectF1, stringFormat);
                e.Graphics.DrawRectangle(Pens.Black, Rectangle.Round(rectF1));



            }
        }

        /*
       
        // Draw justified text on the Graphics
        // object in the indicated Rectangle.
        private RectangleF DrawParagraphs(Graphics gr, RectangleF rect,
            Font font, Brush brush, string text,
            TextJustification justification, float line_spacing,
            float indent, float paragraph_spacing)
        {

            // Split the text into paragraphs.
            string[] paragraphs = text.Split('\n');

            // Draw each paragraph.
            foreach (string paragraph in paragraphs)
            {
                // Draw the paragraph keeping track of remaining space.
                rect = DrawParagraph(gr, rect, font, brush,
                    paragraph, justification, line_spacing,
                    indent, paragraph_spacing);

                // See if there's any room left.
                if (rect.Height < font.Size) break;
            }

            return rect;
        }

        // Draw a paragraph by lines inside the Rectangle.
        // Return a RectangleF representing any unused
        // space in the original RectangleF.
        private RectangleF DrawParagraph(Graphics gr, RectangleF rect,
            Font font, Brush brush, string text,TextJustification justification, float line_spacing,float indent, float extra_paragraph_spacing)
        {
            // Get the coordinates for the first line.
            float y = rect.Top;

            // Break the text into words.
            string[] words = text.Split(' ');
            int start_word = 0;

            // Repeat until we run out of text or room.
            for (; ; )
            {
                // See how many words will fit.
                // Start with just the next word.
                string line = words[start_word];

                // Add more words until the line won't fit.
                int end_word = start_word + 1;
                while (end_word < words.Length)
                {
                    // See if the next word fits.
                    string test_line = line + " " + words[end_word];
                    SizeF line_size = gr.MeasureString(test_line, font);
                    if (line_size.Width > rect.Width)
                    {
                        // The line is too wide. Don't use the last word.
                        end_word--;
                        break;
                    }
                    else
                    {
                        // The word fits. Save the test line.
                        line = test_line;
                    }

                    // Try the next word.
                    end_word++;
                }

                // See if this is the last line in the paragraph.
                if ((end_word == words.Length) &&
                    (justification == TextJustification.Full))
                {
                    // This is the last line. Don't justify it.
                    DrawLine(gr, line, font, brush,
                        rect.Left + indent,
                        y,
                        rect.Width - indent,
                        TextJustification.Left);
                }
                else
                {
                    // This is not the last line. Justify it.
                    DrawLine(gr, line, font, brush,
                        rect.Left + indent,
                        y,
                        rect.Width - indent,
                        justification);
                }

                // Move down to draw the next line.
                y += font.Height * line_spacing;

                // Make sure there's room for another line.
                if (font.Size > rect.Height) break;

                // Start the next line at the next word.
                start_word = end_word + 1;
                if (start_word >= words.Length) break;

                // Don't indent subsequent lines in this paragraph.
                indent = 0;
            }

            // Add a gap after the paragraph.
            y += font.Height * extra_paragraph_spacing;

            // Return a RectangleF representing any unused
            // space in the original RectangleF.
            float height = rect.Bottom - y;
            if (height < 0) height = 0;
            return new RectangleF(rect.X, y, rect.Width, height);
        }

        // Draw a line of text.
        private void DrawLine(Graphics gr, string line, Font font,Brush brush, float x, float y, float width,TextJustification justification)
        {
            // Make a rectangle to hold the text.
            RectangleF rect = new RectangleF(x, y, width, font.Height);

            // See if we should use full justification.
            if (justification == TextJustification.Full)
            {
                // Justify the text.
                DrawJustifiedLine(gr, rect, font, brush, line);
            }
            else
            {
                // Make a StringFormat to align the text.
                using (StringFormat sf = new StringFormat())
                {
                    // Use the appropriate alignment.
                    switch (justification)
                    {
                        case TextJustification.Left:
                            sf.Alignment = StringAlignment.Near;
                            break;
                        case TextJustification.Right:
                            sf.Alignment = StringAlignment.Far;
                            break;
                        case TextJustification.Center:
                            sf.Alignment = StringAlignment.Center;
                            break;
                    }

                    gr.DrawString(line, font, brush, rect, sf);
                }
            }
        }
        */
        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SLCOLD_Click(object sender, EventArgs e)
        {
             printPreviewDialog1.Document = printDocument1;
            printPreviewDialog1.ShowDialog();
            /*
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.Print();
            }
             */
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {

        }
    }
}
