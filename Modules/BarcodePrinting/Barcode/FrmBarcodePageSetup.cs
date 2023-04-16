using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Windows.Forms;

namespace TPH.LIS.BarcodePrinting
{
    public partial class FrmBarcodePageSetup : Form
    {
        public FrmBarcodePageSetup()
        {
            InitializeComponent();
            cboFont.DrawItem += cboFont_DrawItem;
            cboFont.DataSource = FontFamily.Families.Select(f => f.Name).ToList();
        }
        private void cboFont_DrawItem(object sender, DrawItemEventArgs e)
        {
            var comboBox = (ComboBox)sender;
            var fontFamily = (FontFamily)comboBox.Items[e.Index];
            var font = new Font(fontFamily, comboBox.Font.SizeInPoints);

            e.DrawBackground();
            e.Graphics.DrawString(font.Name, font, Brushes.Black, e.Bounds.X, e.Bounds.Y);
        }
        private Bitmap ShowBitmapBarcodePreview()
        {
            if (!_isLoading)
            {
                if (!string.IsNullOrEmpty(this.txtBarCodeDescription.Text) || !string.IsNullOrEmpty(this.txtBarCode.Text))
                {
                    pctPicture.Image = null;
                    pctPicture.Dock = DockStyle.None;
                    pctPicture.SizeMode = PictureBoxSizeMode.AutoSize;

                    Bitmap singlePage = StandardBarcodeService.GetInstance().GenerateBitmapBarCode(
                            GetBarcodePageSetting(),
                            txtBarCode.Text
                            , txtTopLine.Text
                            , txtSecondLine.Text
                            , txtLine5.Text
                            , txtSideText1.Text
                            , txtSideText2.Text
                            , txtSideText3.Text
                            , txtSideText4.Text
                            , txtSideText5.Text
                            , txtSideText6.Text
                            , txtLeftSideText1.Text
                            , txtLeftSideText2.Text
                            , txtLeftSideText3.Text
                            , txtLeftSideText4.Text
                            , txtLeftSideText5.Text
                            , txtLeftSideText6.Text
                            , chkShowBorder.Checked,
                            this.txtBarCodeDescription.Text);

                    this.pctPicture.Image = singlePage;
                    this.pctPicture.Refresh();

                    if (pctPicture.Height < pnDesign.Height && pctPicture.Width < pnDesign.Width)
                    {

                        pctPicture.Dock = DockStyle.Fill;
                        pctPicture.SizeMode = PictureBoxSizeMode.CenterImage;
                    }

                    else
                    {
                        pctPicture.Dock = DockStyle.None;
                        pctPicture.SizeMode = PictureBoxSizeMode.AutoSize;

                    }
                    return singlePage;
                }
            }
            return null;
        }

        private void btnPrintPreview_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap singlePage = ShowBitmapBarcodePreview();

                singlePage = StandardBarcodeService.GetInstance().GenerateBitmapBarCode(
                    GetBarcodePageSetting(),
                    this.txtBarCode.Text, this.txtTopLine.Text, this.txtSecondLine.Text
                    , txtLine5.Text
                    , txtSideText1.Text
                    , txtSideText2.Text
                    , txtSideText3.Text
                    , txtSideText4.Text 
                    , txtSideText5.Text
                    , txtSideText6.Text
                    , txtLeftSideText1.Text 
                    , txtLeftSideText2.Text 
                    , txtLeftSideText3.Text 
                    , txtLeftSideText4.Text
                    , txtLeftSideText5.Text
                    , txtLeftSideText6.Text
                    );

                List<Bitmap> bitmapPages = new List<Bitmap>();
                bitmapPages.Add(singlePage);

                for (int i = 1; i < Convert.ToInt32(txtNumberPage.Text); i++)
                {
                    Bitmap extraPage = StandardBarcodeService.GetInstance().GenerateBitmapBarCode(
                        GetBarcodePageSetting(),
                        this.txtBarCode.Text,
                        this.txtTopLine.Text + "-" + i,
                        this.txtSecondLine.Text + "-" + i,
                         txtLine5.Text + "-" + i,
                        this.txtSideText1.Text + "-" + i
                        , txtSideText2.Text + "-" + i
                        , txtSideText3.Text + "-" + i
                        , txtSideText4.Text + "-" + i
                        , txtSideText5.Text + "-" + i
                        , txtSideText6.Text + "-" + i
                        , txtLeftSideText1.Text + "-" + i
                        , txtLeftSideText2.Text + "-" + i
                        , txtLeftSideText3.Text + "-" + i
                        , txtLeftSideText4.Text + "-" + i
                        , txtLeftSideText5.Text + "-" + i
                        , txtLeftSideText6.Text + "-" + i);

                    bitmapPages.Add(extraPage);
                }

                PrintService printService = new PrintService(
                    (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex]);
                printService.SetPages(bitmapPages);
                printService.PrintPreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                Bitmap singlePage = StandardBarcodeService.GetInstance().GenerateBitmapBarCode(
                GetBarcodePageSetting(),
                this.txtBarCode.Text, this.txtTopLine.Text, this.txtSecondLine.Text, txtLine5.Text
                , txtSideText1.Text
                , txtSideText2.Text
                , txtSideText3.Text
                , txtSideText4.Text
                , txtSideText5.Text
                , txtSideText6.Text
                , txtLeftSideText1.Text
                , txtLeftSideText2.Text
                , txtLeftSideText3.Text
                , txtLeftSideText4.Text
                , txtLeftSideText5.Text
                , txtLeftSideText6.Text);

                this.pctPicture.Image = singlePage;

                List<Bitmap> bitmapPages = new List<Bitmap>();
                bitmapPages.Add(singlePage);

                for (int i = 1; i < Convert.ToInt32(txtNumberPage.Text); i++)
                {
                    Bitmap extraPage = StandardBarcodeService.GetInstance().GenerateBitmapBarCode(
                        GetBarcodePageSetting(),
                        this.txtBarCode.Text,
                        this.txtTopLine.Text + "-" + i,
                        this.txtSecondLine.Text + "-" + i,
                        txtLine5.Text + "-" + i,
                        this.txtSideText1.Text + "-" + i
                        , txtSideText2.Text + "-" + i
                        , txtSideText3.Text + "-" + i
                        , txtSideText4.Text + "-" + i
                        , txtSideText5.Text + "-" + i
                        , txtSideText6.Text + "-" + i
                        , txtLeftSideText1.Text + "-" + i
                        , txtLeftSideText2.Text + "-" + i
                        , txtLeftSideText3.Text + "-" + i
                        , txtLeftSideText4.Text + "-" + i
                        , txtLeftSideText5.Text + "-" + i
                        , txtLeftSideText6.Text + "-" + i);

                    bitmapPages.Add(extraPage);
                }

                PrintService printService = new PrintService(
                    (string)this.cboPrinter.Items[this.cboPrinter.SelectedIndex]);
                printService.SetPages(bitmapPages);
                printService.Print();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ThumbnailCallback()
        {
            return true;
        }

        private void LoadHorizontalAlignment()
        {
            foreach (var item in Enum.GetValues(typeof(StringAlignment)))
            {
                this.cboAlignment.Items.Add(item);
                this.cboBarcodeAlign.Items.Add(item);
            }

            this.cboAlignment.SelectedIndex = 0;
            this.cboBarcodeAlign.SelectedIndex = 0;
        }
        private void LoadBarcodeType()
        {
            foreach (var item in Enum.GetValues(typeof(BarcodeLib.TYPE)))
            {
                this.cboBarcodeType.Items.Add(item);
            }

            this.cboBarcodeType.SelectedItem = BarcodeLib.TYPE.CODE128;
        }
        private void LoadPrinter()
        {
            foreach (var printerName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printerName);
            }

            if (cboPrinter.Items.Count > 0)
            {
                cboPrinter.SelectedIndex = 0;
            }
        }
        bool _isLoading = false;
        private void FrmMain_Load(object sender, EventArgs e)
        {
            _isLoading = true;
            try
            {

                LoadPrinter();
                LoadHorizontalAlignment();
                LoadBarcodeType();
                //check no settings, create a new then save it
                BarcodePageSetting settings = StandardBarcodeService.GetInstance().LoadSettings(StandardBarcodeService.DefaultSettingsFileName);
                if (settings != null)
                {
                    ApplyPageSettings(settings);
                }
                else
                {
                    StandardBarcodeService.GetInstance().SaveSettings(settings, StandardBarcodeService.DefaultSettingsFileName);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            _isLoading = false; 
            this.ShowBitmapBarcodePreview();
            
        }

        private void ApplyPageSettings(BarcodePageSetting pageSettings)
        {
            if (pageSettings != null)
            {
                this.ucFontFormatFirstLine.ValueChanged -= UcFontFormat_ValueChanged;

                this.ucFontFormatSecondLine.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatDescriptionLine.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatFifthLine.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatSideText1.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatSideText2.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatSideText3.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatSideText4.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatSideText5.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatSideText6.ValueChanged -= UcFontFormat_ValueChanged;

                this.ucFontFormatLeftSideText1.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText2.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText3.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText4.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText5.ValueChanged -= UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText6.ValueChanged -= UcFontFormat_ValueChanged;

                this.cboFont.Text = pageSettings.FontName;
                this.nudPaperSizeW.Value = Convert.ToDecimal(pageSettings.PaperSizeW);
                this.nudPaperSizeH.Value = Convert.ToDecimal(pageSettings.PaperSizeH);
                this.nudDPI.Value = Convert.ToDecimal(pageSettings.DPI);
                this.nudNumberStamp.Value = Convert.ToDecimal(pageSettings.StampsPerPage);
                this.nudBarCodeHeight.Value = Convert.ToDecimal(pageSettings.BarCodeHeight);
                this.nudMarginLeft.Value = Convert.ToDecimal(pageSettings.MarginLeft);
                this.nudMarginRight.Value = Convert.ToDecimal(pageSettings.MarginRight);
                this.nudMarginTop.Value = Convert.ToDecimal(pageSettings.MarginTop);
                this.nudMarginBottom.Value = Convert.ToDecimal(pageSettings.MarginBottom);
                this.nudGeneralFontSize.Value = Convert.ToDecimal(pageSettings.FontSize);
                this.nudMMPerChar.Value = Convert.ToDecimal(pageSettings.MMPerChar);
                numLeftWidth.Value = Convert.ToDecimal(pageSettings.LeftWidth);
                numRightWidth.Value = Convert.ToDecimal(pageSettings.RightWidth);
                this.cboAlignment.SelectedItem = pageSettings.HorizontalAlign;
                this.cboBarcodeAlign.SelectedItem = pageSettings.BarcodeAlign;
                this.cboPrinter.Text = pageSettings.BarcodePrinterName;
                this.txtTopLine.Text = pageSettings.TextTopLine1Value;
                this.txtSecondLine.Text = pageSettings.TextTopLine2Value;
                this.txtLine5.Text = pageSettings.TextLineValue5;

                this.txtSideText1.Text = pageSettings.TextRightLineValue1;
                this.txtSideText2.Text = pageSettings.TextRightLineValue2;
                this.txtSideText3.Text = pageSettings.TextRightLineValue3;
                this.txtSideText4.Text = pageSettings.TextRightLineValue4;
                this.txtSideText5.Text = pageSettings.TextRightLineValue5;
                this.txtSideText6.Text = pageSettings.TextRightLineValue6;

                this.txtLeftSideText1.Text = pageSettings.TextLeftLineValue1;
                this.txtLeftSideText2.Text = pageSettings.TextLeftLineValue2;
                this.txtLeftSideText3.Text = pageSettings.TextLeftLineValue3;
                this.txtLeftSideText4.Text = pageSettings.TextLeftLineValue4;
                this.txtLeftSideText5.Text = pageSettings.TextLeftLineValue5;
                this.txtLeftSideText6.Text = pageSettings.TextLeftLineValue6;

                this.txtBarCodeDescription.Text = pageSettings.TextBottomLine1Value;
                this.txtBarCode.Text = pageSettings.BarcodeText;
                cboBarcodeType.SelectedItem = (pageSettings.BarcodeType == null ? BarcodeLib.TYPE.UNSPECIFIED : pageSettings.BarcodeType);

                this.ucFontFormatFirstLine.UpdateSettings(pageSettings.FirstLineFontSetting);
                this.ucFontFormatSecondLine.UpdateSettings(pageSettings.SecondLineFontSetting);
                this.ucFontFormatDescriptionLine.UpdateSettings(pageSettings.DescriptionFontSetting);
                this.ucFontFormatFifthLine.UpdateSettings(pageSettings.FifthFontSetting);

                this.ucFontFormatSideText1.UpdateSettings(pageSettings.RightSideFontSetting1);
                this.ucFontFormatSideText2.UpdateSettings(pageSettings.RightSideFontSetting2);
                this.ucFontFormatSideText3.UpdateSettings(pageSettings.RightSideFontSetting3);
                this.ucFontFormatSideText4.UpdateSettings(pageSettings.RightSideFontSetting4);
                this.ucFontFormatSideText5.UpdateSettings(pageSettings.RightSideFontSetting5);
                this.ucFontFormatSideText6.UpdateSettings(pageSettings.RightSideFontSetting6);

                this.ucFontFormatLeftSideText1.UpdateSettings(pageSettings.LeftSideFontSetting1);
                this.ucFontFormatLeftSideText2.UpdateSettings(pageSettings.LeftSideFontSetting2);
                this.ucFontFormatLeftSideText3.UpdateSettings(pageSettings.LeftSideFontSetting3);
                this.ucFontFormatLeftSideText4.UpdateSettings(pageSettings.LeftSideFontSetting4);
                this.ucFontFormatLeftSideText5.UpdateSettings(pageSettings.LeftSideFontSetting5);
                this.ucFontFormatLeftSideText6.UpdateSettings(pageSettings.LeftSideFontSetting6);


                this.ucFontFormatSecondLine.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatDescriptionLine.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatFifthLine.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatSideText1.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatSideText2.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatSideText3.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatSideText4.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatSideText5.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatSideText6.ValueChanged += UcFontFormat_ValueChanged;

                this.ucFontFormatLeftSideText1.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText2.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText3.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText4.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText5.ValueChanged += UcFontFormat_ValueChanged;
                this.ucFontFormatLeftSideText6.ValueChanged += UcFontFormat_ValueChanged;
            }
        }

        private void UcFontFormat_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private BarcodePageSetting GetBarcodePageSetting()
        {
            BarcodePageSetting settings = new BarcodePageSetting()
            {
                FontName = cboFont.Text,
                PaperSizeW = Convert.ToDouble(this.nudPaperSizeW.Value),
                PaperSizeH = Convert.ToDouble(this.nudPaperSizeH.Value),
                DPI = Convert.ToDouble(this.nudDPI.Value),
                StampsPerPage = Convert.ToInt32(this.nudNumberStamp.Value),

                MarginLeft = Convert.ToDouble(this.nudMarginLeft.Value),
                MarginRight = Convert.ToDouble(this.nudMarginRight.Value),
                MarginTop = Convert.ToDouble(this.nudMarginTop.Value),
                MarginBottom = Convert.ToDouble(this.nudMarginBottom.Value),
                FontSize = Convert.ToDouble(this.nudGeneralFontSize.Value),
                MMPerChar = Convert.ToDouble(this.nudMMPerChar.Value),
                BarCodeHeight = Convert.ToDouble(nudBarCodeHeight.Value),
                LeftWidth = Convert.ToDouble(numLeftWidth.Value),
                RightWidth = Convert.ToDouble(numRightWidth.Value),

                HorizontalAlign = (StringAlignment)this.cboAlignment.Items[this.cboAlignment.SelectedIndex],
                BarcodeAlign = (StringAlignment)this.cboAlignment.Items[this.cboBarcodeAlign.SelectedIndex],
                TextTopLine1Value = txtTopLine.Text,
                TextTopLine2Value = txtSecondLine.Text,
                TextBottomLine1Value = txtBarCodeDescription.Text,
                TextLineValue5 = txtLine5.Text,
                BarcodeText = txtBarCode.Text,
                TextRightLineValue1 = txtSideText1.Text,
                TextRightLineValue2 = txtSideText2.Text,
                TextRightLineValue3 = txtSideText3.Text,
                TextRightLineValue4 = txtSideText4.Text,
                TextRightLineValue5 = txtSideText5.Text,
                TextRightLineValue6 = txtSideText6.Text,
                TextLeftLineValue1 = txtLeftSideText1.Text,
                TextLeftLineValue2 = txtLeftSideText2.Text,
                TextLeftLineValue3 = txtLeftSideText3.Text,
                TextLeftLineValue4 = txtLeftSideText4.Text,
                TextLeftLineValue5 = txtLeftSideText5.Text,
                TextLeftLineValue6 = txtLeftSideText6.Text,
                BarcodePrinterName = (cboPrinter.SelectedIndex > -1 ? cboPrinter.Text : string.Empty),
                FirstLineFontSetting = this.ucFontFormatFirstLine.GetSetting(),
                SecondLineFontSetting = this.ucFontFormatSecondLine.GetSetting(),
                DescriptionFontSetting = this.ucFontFormatDescriptionLine.GetSetting(),
                FifthFontSetting = ucFontFormatFifthLine.GetSetting(),
                RightSideFontSetting1 = this.ucFontFormatSideText1.GetSetting(),
                RightSideFontSetting2 = this.ucFontFormatSideText2.GetSetting(),
                RightSideFontSetting3 = this.ucFontFormatSideText3.GetSetting(),
                RightSideFontSetting4 = this.ucFontFormatSideText4.GetSetting(),
                RightSideFontSetting5 = this.ucFontFormatSideText5.GetSetting(),
                RightSideFontSetting6 = this.ucFontFormatSideText6.GetSetting(),
                LeftSideFontSetting1 = this.ucFontFormatLeftSideText1.GetSetting(),
                LeftSideFontSetting2 = this.ucFontFormatLeftSideText2.GetSetting(),
                LeftSideFontSetting3 = this.ucFontFormatLeftSideText3.GetSetting(),
                LeftSideFontSetting4 = this.ucFontFormatLeftSideText4.GetSetting(),
                LeftSideFontSetting5 = this.ucFontFormatLeftSideText5.GetSetting(),
                LeftSideFontSetting6 = this.ucFontFormatLeftSideText6.GetSetting(),
                BarcodeType = (BarcodeLib.TYPE)(cboBarcodeType.SelectedIndex > -1 ? this.cboBarcodeType.SelectedItem : BarcodeLib.TYPE.UNSPECIFIED),
            };

            return settings;
        }

        private void SaveSettings()
        {
            BarcodePageSetting settings = GetBarcodePageSetting();
            StandardBarcodeService.GetInstance().SaveSettings(settings, StandardBarcodeService.DefaultSettingsFileName);
        }

        private void LoadSettings()
        {
            BarcodePageSetting settings = StandardBarcodeService.GetInstance().LoadSettings(StandardBarcodeService.DefaultSettingsFileName);
            ApplyPageSettings(settings);
        }

        private void btnSavePageSetting_Click(object sender, EventArgs e)
        {
            try
            {
                SaveSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLoadPageSetting_Click(object sender, EventArgs e)
        {
            try
            {
                LoadSettings();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void nudGeneralFontSize_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                this.ucFontFormatFirstLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSecondLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatDescriptionLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatFifthLine.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);

                this.ucFontFormatSideText1.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSideText2.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSideText3.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSideText4.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSideText5.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatSideText6.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);

                this.ucFontFormatLeftSideText1.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatLeftSideText2.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatLeftSideText3.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatLeftSideText4.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatLeftSideText5.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);
                this.ucFontFormatLeftSideText6.Settings.FontSize = Convert.ToInt32(nudGeneralFontSize.Value);


                this.ucFontFormatFirstLine.ReloadConfig();
                this.ucFontFormatSecondLine.ReloadConfig();
                this.ucFontFormatDescriptionLine.ReloadConfig();
                this.ucFontFormatSideText1.ReloadConfig();
                ucFontFormatFifthLine.ReloadConfig();

                this.ucFontFormatSideText1.ReloadConfig();
                this.ucFontFormatSideText2.ReloadConfig();
                this.ucFontFormatSideText3.ReloadConfig();
                this.ucFontFormatSideText4.ReloadConfig();
                this.ucFontFormatSideText5.ReloadConfig();
                this.ucFontFormatSideText6.ReloadConfig();

                this.ucFontFormatLeftSideText1.ReloadConfig();
                this.ucFontFormatLeftSideText2.ReloadConfig();
                this.ucFontFormatLeftSideText3.ReloadConfig();
                this.ucFontFormatLeftSideText4.ReloadConfig();
                this.ucFontFormatLeftSideText5.ReloadConfig();
                this.ucFontFormatLeftSideText6.ReloadConfig();

                this.ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cboAlignment_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                StringAlignment alignment = (StringAlignment)this.cboAlignment.Items[this.cboAlignment.SelectedIndex];

                this.ucFontFormatFirstLine.Settings.Align = alignment;
                this.ucFontFormatSecondLine.Settings.Align = alignment;
                this.ucFontFormatDescriptionLine.Settings.Align = alignment;
                this.ucFontFormatFifthLine.Settings.Align = alignment;
                this.ucFontFormatSideText1.Settings.Align = alignment;

                this.ucFontFormatSideText1.Settings.Align = alignment;
                this.ucFontFormatSideText2.Settings.Align = alignment;
                this.ucFontFormatSideText3.Settings.Align = alignment;
                this.ucFontFormatSideText4.Settings.Align = alignment;
                this.ucFontFormatSideText5.Settings.Align = alignment;
                this.ucFontFormatSideText6.Settings.Align = alignment;

                this.ucFontFormatLeftSideText1.Settings.Align = alignment;
                this.ucFontFormatLeftSideText2.Settings.Align = alignment;
                this.ucFontFormatLeftSideText3.Settings.Align = alignment;
                this.ucFontFormatLeftSideText4.Settings.Align = alignment;
                this.ucFontFormatLeftSideText5.Settings.Align = alignment;
                this.ucFontFormatLeftSideText6.Settings.Align = alignment;

                this.ucFontFormatFirstLine.ReloadConfig();
                this.ucFontFormatSecondLine.ReloadConfig();
                this.ucFontFormatDescriptionLine.ReloadConfig();
                this.ucFontFormatFifthLine.ReloadConfig();

                this.ucFontFormatSideText1.ReloadConfig();
                this.ucFontFormatSideText2.ReloadConfig();
                this.ucFontFormatSideText3.ReloadConfig();
                this.ucFontFormatSideText4.ReloadConfig();
                this.ucFontFormatSideText5.ReloadConfig();
                this.ucFontFormatSideText6.ReloadConfig();

                this.ucFontFormatLeftSideText1.ReloadConfig();
                this.ucFontFormatLeftSideText2.ReloadConfig();
                this.ucFontFormatLeftSideText3.ReloadConfig();
                this.ucFontFormatLeftSideText4.ReloadConfig();
                this.ucFontFormatLeftSideText5.ReloadConfig();
                this.ucFontFormatLeftSideText6.ReloadConfig();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPreviewImage_Click(object sender, EventArgs e)
        {
            try
            {
                this.pctPicture.Image = null;
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Preview_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numLeftWidth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void numRightWidth_ValueChanged(object sender, EventArgs e)
        {
            try
            {
                ShowBitmapBarcodePreview();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error !!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
