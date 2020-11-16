using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Aspose.Words;

namespace AsposePractice
{
    class Program
    {
        static void Main(string[] args)
        {
           // Console.WriteLine("檔案路徑:");
            //string path = Console.ReadLine();

            Document doc = new Document(@"C:\Users\User\Desktop\測試資源\20201109測試\新增資料夾\INPUT.doc");
            DocumentBuilder builder = new DocumentBuilder(doc);

            // We call this method to start building the table.
            //builder.StartTable();
            //builder.InsertCell();
            builder.DeleteRow(1,3);
            // Build the second cell
            //builder.InsertCell();
            // Call the following method to end the row and start a new row.
            //builder.EndRow();

            // Build the first cell of the second row.
            //builder.InsertCell();
            //builder.Write("Row 2, Cell 1 Content");

            // Build the second cell.
           //builder.InsertCell();
            //builder.Write("Row 2, Cell 2 Content.");
            //builder.EndRow();

            // Signal that we have finished building the table.
            //builder.EndTable();
            doc.Save(@"C:\Users\User\Desktop\測試資源\20201109測試\新增資料夾\AsposePractice.doc");
        }
    }
}
