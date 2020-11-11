using Aspose.Cells;
using Aspose.Pdf;
using Aspose.Words;
using GSS.FBU.CMAspose.DomainObject.DomainEnum;
using GSS.FBU.CMAspose.DomainObject.DomainObject;
using GSS.FBU.CMAspose.Excel;
using GSS.FBU.CMAspose.Imaging;
using GSS.FBU.CMAspose.Pdf;
using GSS.FBU.CMAspose.Word;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WaterMarkTool
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void PrintWM_Click(object sender, EventArgs e)
        {
            if (!Directory.Exists(FileTo.Text.Trim()))
            {
                Directory.CreateDirectory(FileTo.Text.Trim());
            }

            if (!File.Exists(FileFrom.Text.Trim()))
            {
                MessageBox.Show("檔案不存在");
            }
            else
            {
               // InitialLicense(FileFrom.Text.Trim());

                FileStream fsWord = new FileStream(FileFrom.Text.Trim(), FileMode.Open, FileAccess.Read, FileShare.ReadWrite); ;
                MemoryStream tempFile = new MemoryStream();
                Dictionary<CMCustomStyleEnum, string> styles = new Dictionary<CMCustomStyleEnum, string>();
                string exportFile = string.Empty;
                if (!string.IsNullOrEmpty(PageSize.Text.Trim()))
                {
                    styles.Add(CMCustomStyleEnum.PageSize, PageSize.Text.Trim().ToString());//A3,A4,A5,B4,B5
                }
                if (!string.IsNullOrEmpty(Scaling.Text.Trim()))
                {
                    styles.Add(CMCustomStyleEnum.PageZoom, Scaling.Text.Trim().ToString());
                }
                if (!string.IsNullOrEmpty(Direction.Text.Trim()))
                {
                    styles.Add(CMCustomStyleEnum.PageOrientation, Direction.Text.Trim().ToString()); //Landscape,Portrait
                }

                //匯出報表路徑
                bool hasExtension = Path.HasExtension(FileTo.Text.Trim());
                //保留原始路徑要被Aspose轉檔
                if (hasExtension)
                {
                    exportFile = FileTo.Text.Trim();
                }
                else
                {
                    //預設檔名
                    exportFile = FileTo.Text.Trim() + "\\Result.pdf";
                }
                if (!string.IsNullOrEmpty(Path.GetExtension(exportFile)))
                {
                    if (Path.GetExtension(exportFile).Trim().ToLower() !=".pdf")
                    {
                        MessageBox.Show("匯出的檔名錯誤!");
                    }
                    else
                    {
                        string OrignNonPDFfile = FileFrom.Text.Trim();

                        CovertToPdf(exportFile, OrignNonPDFfile, styles);

                        fsWord = new FileStream(exportFile, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);

                        fsWord.CopyTo(tempFile);
                        MemoryStream result = addWatermark(exportFile, tempFile, styles);
                        byte[] bytes = new byte[result.Length];

                        //Byte寫入有問題
                        FileStream fsWordNew = new FileStream(exportFile, FileMode.Create);
                        result.Read(bytes, 0, (int)result.Length);
                        fsWordNew.Write(bytes, 0, (int)result.Length);
                        fsWordNew.Close();
                        fsWord.Close();

                        //訊息確定後打開檔案
                        MessageBox.Show("浮水印套印成功!");
                        System.Diagnostics.Process.Start(exportFile);
                    }
                }
            }
        }


        /// <summary>
        /// 加浮水印
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        private MemoryStream addWatermark(string filePath,MemoryStream fileIn, Dictionary<CMCustomStyleEnum, string> styles)
        {
            #region 讀取設定檔

            string texts = (!String.IsNullOrEmpty(this.MarkText.Text))? "#"+this.MarkText.Text:"#123456";
            string width = "300";
            string heigth = "100";
            string color = "#7B7B7B";
            string font = "Microsoft JhengHei";
            string fontSize = "30";
            string rotate = "-30";
            string opacity = "0.2";
            string horizontalSpace = "0";
            string verticalSpace = "0";

            #endregion
            StringBuilder watermark = new StringBuilder();
            MemoryStream fileStream = fileIn;
            var fileAry = filePath.Split('\\');
            var fileName = fileAry[fileAry.Length - 1];
            int i = 0;

            Dictionary<string, string> param = new Dictionary<string, string>();

            foreach (var text in texts.Split(','))
            {
                if (i != 0)
                    watermark.Append(Environment.NewLine);
                foreach (var item in text.Split('|'))
                {
                    var first = item.Substring(0, 1);
                    var value = item.Substring(1);
                    switch (first)
                    {
                        case "$":
                            if (param.ContainsKey(value))
                                watermark.Append(param[value]);
                            break;
                        case "#":
                            watermark.Append(value);
                            break;
                        default:
                            break;
                    }
                }
                i++;
            }
            string[] fileNames = fileName.Split('.');
            string extension = fileNames[fileNames.Length - 1].ToLower();

            WatermarkObj watermarkObj = new WatermarkObj();
            watermarkObj.Color = color;
            watermarkObj.FontFamily = font;
            watermarkObj.RotateAngle = double.Parse(rotate);
            watermarkObj.WMStyle = GSS.FBU.CMAspose.DomainObject.DomainEnum.WatermarkStyleEnum.RepeatRotateAngle;
            watermarkObj.WatermarkHeight = double.Parse(heigth);
            watermarkObj.WatermarkWidth = double.Parse(width);
            watermarkObj.WatermarkHorizontalSpace = double.Parse(horizontalSpace);
            watermarkObj.WatermarkVerticalSpace = double.Parse(verticalSpace);
            watermarkObj.FontSize = int.Parse(fontSize);
            watermarkObj.Watermark = watermark.ToString();
            watermarkObj.Opacity = double.Parse(opacity);
            //底層呼叫套印浮水印
            switch (extension)
            {
                case "xls":
                case "xlsx":
                    WatermarkObj.Excel excelArg = JsonConvert.DeserializeObject<WatermarkObj.Excel>(JsonConvert.SerializeObject(watermarkObj));
                    excelArg.SaveFormat = extension.Equals("xlsx") ? Aspose.Cells.SaveFormat.Xlsx : Aspose.Cells.SaveFormat.Excel97To2003;
                    fileStream = new ExcelProcessing().AddWatermark(fileStream, excelArg, styles);
                    break;
                case "doc":
                case "docx":
                    WatermarkObj.Word wordArg = JsonConvert.DeserializeObject<WatermarkObj.Word>(JsonConvert.SerializeObject(watermarkObj));
                    wordArg.SaveFormat = extension.Equals("docx") ? Aspose.Words.SaveFormat.Docx : Aspose.Words.SaveFormat.Doc;
                    fileStream = new WordProcessing().AddWatermark(fileStream, wordArg, styles);
                    break;
                case "pdf":
                    WatermarkObj.Pdf pdfArg = JsonConvert.DeserializeObject<WatermarkObj.Pdf>(JsonConvert.SerializeObject(watermarkObj));
                    fileStream = new PdfProcessing().AddWatermark(fileStream, pdfArg, styles);
                    break;
                case "tiff":
                case "tif":
                case "png":
                case "gif":
                case "jpeg":
                case "jpg":
                case "xpm":
                    WatermarkObj.Image imageArg = JsonConvert.DeserializeObject<WatermarkObj.Image>(JsonConvert.SerializeObject(watermarkObj));
                    imageArg.WMStyle = GSS.FBU.CMAspose.DomainObject.DomainEnum.WatermarkStyleEnum.FitPage;
                    fileStream = new ImageProcessing().AddWatermark(fileStream, imageArg);
                    break;
                default:
                    break;
            }
            return fileStream;
        }

        private void CovertToPdf(string Destpath ,string Sourcepath, Dictionary<GSS.FBU.CMAspose.DomainObject.DomainEnum.CMCustomStyleEnum, string> styles)
        {
            string fileName = FileFrom.Text.Trim().Split('\\').Last().Split('.')[1];
            string extension = string.Empty;
            extension = fileName.Split('.').Last().ToLower();

            switch (extension)
            {
                case "xls":
                case "xlsx":
                    FileStream fsExcel = new FileStream(Sourcepath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    ExcelProcessing pdfStream = new ExcelProcessing(fsExcel);
                    //底層設定客製化樣式
                    pdfStream.SetCustomStyleProperty(styles);
                    pdfStream.Convert2Pdf(Destpath);
                   /* Workbook excelDocument = new Workbook(Sourcepath);
                    excelDocument.Save(Destpath , Aspose.Cells.SaveFormat.Pdf);*/
                    break;
                case "doc":
                case "docx":
                    Aspose.Words.Document lDocDocument = new Aspose.Words.Document(Sourcepath);
                    lDocDocument.Save(Destpath, Aspose.Words.SaveFormat.Pdf);
                    break;
                case "tiff":
                case "tif":
                case "png":
                case "gif":
                case "jpeg":
                case "jpg":
                case "xpm":
                    // Initialize new PDF document
                    Aspose.Pdf.Document doc = new Aspose.Pdf.Document();
                    // Add empty page in empty document
                    Page page = doc.Pages.Add();
                    Aspose.Pdf.Image image = new Aspose.Pdf.Image();
                    image.File = (Sourcepath);
                    // Add image on a page
                    page.Paragraphs.Add(image);
                    // Save output PDF file
                    doc.Save(Destpath);
                    break;
                default:
                    break;
            }
        }

        private void InitialLicense(string path)
        {
            //設定License
            string fileName = path.Split('\\').Last().Split('.')[1];
            string extension = string.Empty;
            extension = fileName.Split('.').Last().ToLower();

            switch (extension)
            {
                case "xls":
                case "xlsx":
                    Aspose.Cells.License Excellic = new Aspose.Cells.License();
                    Excellic.SetLicense("Aspose.Total.lic");
                    break;
                case "doc":
                case "docx":
                    // Apply Aspose.Words API License
                    Aspose.Words.License Wordlic = new Aspose.Words.License();
                    // Place license file in Bin/Debug/Folder
                    Wordlic.SetLicense("Aspose.Total.lic");
                    break;
                case "tiff":
                case "tif":
                case "png":
                case "gif":
                case "jpeg":
                case "jpg":
                case "xpm":
                    Aspose.Imaging.License Imglic = new Aspose.Imaging.License();
                    Imglic.SetLicense("Aspose.Total.lic");
                    break;
                default:
                    break;
            }
        }

        private void SelFrom_Click(object sender, EventArgs e)
        {
            OpenFileDialog file = new OpenFileDialog();
            file.ShowDialog();
            this.FileFrom.Text = file.FileName;
        }

        private void SelTo_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog path = new FolderBrowserDialog();
            path.ShowDialog();
            this.FileTo.Text = path.SelectedPath;
        }
    }
}
