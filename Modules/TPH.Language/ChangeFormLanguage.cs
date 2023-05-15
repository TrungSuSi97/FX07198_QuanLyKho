using DevExpress.XtraBars.Ribbon;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.BandedGrid;
using DevExpress.XtraGrid.Views.Grid;
using DevExpress.XtraNavBar;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using TPH.Common.Converter;
using TPH.Controls;
using TPH.Language.Models;
using TPH.Language.Services;
using TPH.Language.Services.Impl;

namespace TPH.Language
{
    public class LanguageExtension
    {
        public const string EnglishLanguageKey = "en-US";
        public const string VietnameseLanguageKey = "vi-VN";
        public const string DefaultLanguageKey = "vi-VN";
        //public static string AppLanguage = "vi-VN";
        public static bool LocalizedLanguage = true;
        private static List<HETHONG_NGONNGU> lstCauHinhNgonNgu;

        public static string AppLanguage
        {
            get
            {
                var languageKey = StringConverter.ToString(ConfigurationSettings.AppSettings["AppConfig:AppLanguage"]);
                return string.IsNullOrWhiteSpace(languageKey) ? DefaultLanguageKey : languageKey;
            }
        }
        private static string ChuyenTvKhongDau(string strVietNamese)
        {
            //string findText =
            //    "áàảãạâấầẩẫậăắằẳẵặđèéẻẽẹêếềểễệíìỉĩịóòỏõọôốồổỗộơớờởỡợúùủũụưứừửữựýỳỷỹỵÁÀẢÃẠÂẤẦẨẪẬĂẮẰẲẴẶĐÉÈÉẺẼẸÊẾỀỂỄỆÍÌỈĨỊÓÒỎÕỌÔỐỒỔỖỘƠỚỜỞỠỢÚÙỦŨỤƯỨỪỬỮỰÝỲỶỸỴ";
            //string replText =
            //    "aaaaaaaaaaaaaaaaadeeeeeeeeeeeiiiiiooooooooooooooooouuuuuuuuuuuyyyyyAAAAAAAAAAAAAAAAADEEEEEEEEEEEEIIIIIOOOOOOOOOOOOOOOOOUUUUUUUUUUUYYYYY";
            //int index = -1, index2;
            //while ((index = strVietNamese.IndexOfAny(findText.ToCharArray())) != -1)
            //{
            //    index2 = findText.IndexOf(strVietNamese[index]);
            //    strVietNamese = strVietNamese.Replace(strVietNamese[index], replText[index2]);
            //}
            //return strVietNamese;
            if (string.IsNullOrEmpty(strVietNamese)) return strVietNamese;

            Regex regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string temp = strVietNamese.Normalize(NormalizationForm.FormD);
            return regex.Replace(temp, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }
        public static string GetID(string intext)
        {
            if (!string.IsNullOrEmpty(intext))
            {
                var keyName = ChuyenTvKhongDau(intext).Replace("\\r\\n", "").Replace("\\r", "").Replace(Environment.NewLine, "").Replace("\\n", "").Replace(" ", "")
                                    .Replace("\"", "")
                                    .Replace("\\", "DauXiecNgang")
                                    .Replace("-", "TRU")
                                    .Replace("+", "CONG")
                                    .Replace(".", "CHAM")
                                    .Replace(",", "PHAY")
                                    .Replace("*", "NHAN")
                                    .Replace("|", "HOAC")
                                    .Replace(":", "LA")
                                    .Replace(";", "CHAMPHAY")
                                    .Replace("!", "CHAMCAM")
                                    .Replace("?", "HOI")
                                    .Replace("/", "TREN")
                                    .Replace("&", "VA")
                                    .Replace("@", "AT")
                                    .Replace("©", "CopyRight")
                                    .Replace("$", "DOLA")
                                    .Replace("%", "PHANTRAM")
                                    .Replace("^", "MUNHON")
                                    .Replace("#", "THANG")
                                    .Replace("{", "MONGOACNHON")
                                    .Replace("}", "DONGNGOACNHON")
                                    .Replace("(", "MONGOACDON")
                                    .Replace(")", "DONGNGOACDON")
                                    .Replace("0", "KHONG")
                                    .Replace("1", "MOT")
                                    .Replace("2", "HAI")
                                    .Replace("3", "BA")
                                    .Replace("4", "BON")
                                    .Replace("5", "NAM")
                                    .Replace("6", "SAU")
                                    .Replace("7", "BAY")
                                    .Replace("8", "TAM")
                                    .Replace("9", "CHIN")
                                    .Replace(">", "LONHON")
                                    .Replace("<", "NHOHON")
                                    .Replace("[x]", "MONGOACVUONGnhanDONGNGOACVUONG")
                                    .Replace("[", "MONGOACVUONG")
                                    .Replace("]", "DONGNGOACVUONG")
                                    .Replace("'", "NHAYDON")
                                    .Trim();
                keyName = (keyName.ToUpper().Equals(keyName) ? keyName + "_Upper" : keyName);
                return keyName;
            }
            else
                return string.Empty;
        }
        public static void CheckGetConfig(bool force = false)
        {
            
            //Nếu cấu hình null thì get cấu hình
            if (lstCauHinhNgonNgu == null || force)
            {
                IAppLanguage ilanguage = new AppLanguage();
                var data = ilanguage.Data_HeThong_NgonNgu(null, string.Empty);
                if (data != null)
                {
                    if (data.Rows.Count > 0)
                    {
                        lstCauHinhNgonNgu = new List<HETHONG_NGONNGU>();
                        foreach (DataRow dr in data.Rows)
                        {
                            lstCauHinhNgonNgu.Add(ilanguage.Get_Info_HeThong_NgonNgu(dr));
                        }
                    }
                }
            }
        }

        public static string GetResxNameByValue(string value)
        {
            if (string.IsNullOrEmpty(value)) return string.Empty;

            CheckGetConfig();
            //Xử lý tìm key trả về biên dịch
            if (lstCauHinhNgonNgu == null) return string.Empty;
            var fLang = lstCauHinhNgonNgu.Where(x =>
                Common.Converter.StringConverter.ToString(x.Defaultlang).Equals(value));
            if (fLang.Any())
            {
                return fLang.FirstOrDefault().Idtungu;

            }

            fLang = lstCauHinhNgonNgu.Where(x =>
                Common.Converter.StringConverter.ToString(x.Defaultlang).Equals(value.Trim()));
            if (fLang.Any())
            {
                return fLang.FirstOrDefault().Idtungu;
            }

            fLang = lstCauHinhNgonNgu.Where(x =>
                Common.Converter.StringConverter.ToString(x.Defaultlang)
                    .Equals(value.Trim(), StringComparison.OrdinalIgnoreCase));
            return fLang.Any() ? fLang.FirstOrDefault().Idtungu : string.Empty;

        }

        public static string GetString(string key, string language)
        {
            language = string.IsNullOrEmpty(language) ? string.IsNullOrEmpty(AppLanguage)? DefaultLanguageKey: AppLanguage : language;
            CheckGetConfig();
            //Xử lý tìm key trả về biên dịch
            if (lstCauHinhNgonNgu != null)
            {
                var fLang = lstCauHinhNgonNgu.Where(x => x.Idtungu.Equals(key, StringComparison.OrdinalIgnoreCase));
                if (fLang.Any())
                {
                    var obj = fLang.FirstOrDefault();
                    if (language.Equals(EnglishLanguageKey))
                        return (string.IsNullOrEmpty(obj.Eng) ? obj.Defaultlang : obj.Eng);
                    if (language.Equals(VietnameseLanguageKey))
                        return (string.IsNullOrEmpty(obj.Vn) ? obj.Defaultlang : obj.Vn);
                    return obj.Defaultlang;
                }
                return string.Empty;
            }
            return string.Empty;
        }
        private static void SetLanguageForTreeNode(TreeNode ctr, string language)
        {
            if (ctr.Nodes.Count >0)
            {
                foreach (TreeNode itm in ctr.Nodes)
                {
                    if (!string.IsNullOrEmpty(itm.Text))
                    {
                        var key = GetResxNameByValue(itm.Text);
                        if (!string.IsNullOrEmpty(key))
                            itm.Text = GetString(key, language);
                    }
                    SetLanguageForTreeNode(itm, language);
                }
            }
        }
        private static void SetLanguageForContextMenu(Control ctr, string language)
        {
            if (ctr.ContextMenuStrip != null)
            {
                var obj = ctr.ContextMenuStrip;
                foreach (ToolStripItem itm in obj.Items)
                {
                    if (!string.IsNullOrEmpty(itm.Text))
                    {
                        var key = GetResxNameByValue(itm.Text);
                        if (!string.IsNullOrEmpty(key))
                            itm.Text = GetString(key, language);
                    }
                    SetLanguageForSubItemContextMenu(itm, language);
                }
            }
        }
        private static void SetLanguageForSubItemContextMenu(ToolStripItem ctr, string language)
        {
            if (ctr is ToolStripMenuItem)
            {
                foreach (ToolStripItem itm in ((ToolStripMenuItem)ctr).DropDownItems)
                {
                    if (!string.IsNullOrEmpty(itm.Text))
                    {
                        var key = GetResxNameByValue(itm.Text);
                        if (!string.IsNullOrEmpty(key))
                            itm.Text = GetString(key, language);
                    }
                    SetLanguageForSubItemContextMenu(itm, language);
                }
            }
            else if (ctr is ToolStripSplitButton)
            {
                foreach (ToolStripItem itm in ((ToolStripSplitButton)ctr).DropDownItems)
                {
                    if (!string.IsNullOrEmpty(itm.Text))
                    {
                        var key = GetResxNameByValue(itm.Text);
                        if (!string.IsNullOrEmpty(key))
                            itm.Text = GetString(key, language);
                    }
                    SetLanguageForSubItemContextMenu(itm, language);
                }
            }
            else if (ctr is ToolStripDropDownButton)
            {
                foreach (ToolStripItem itm in ((ToolStripDropDownButton)ctr).DropDownItems)
                {
                    if (!string.IsNullOrEmpty(itm.Text))
                    {
                        var key = GetResxNameByValue(itm.Text);
                        if (!string.IsNullOrEmpty(key))
                            itm.Text = GetString(key, language);
                    }
                    SetLanguageForSubItemContextMenu(itm, language);
                }
            }

        }
        public static string GetResourceValueFromKey(string key, string language)
        {
            return GetString(key, (string.IsNullOrWhiteSpace(language) ? DefaultLanguageKey : language));
        }
        public static string GetResourceValueFromValue(string value, string language)
        {
            var key = GetResxNameByValue(value);
            if (!string.IsNullOrEmpty(key))
                return GetString(key, language);
            return value;
        }
        public static void LocalizeSpecialControl(Control ctr, string language)
        {
            if (!LocalizedLanguage)
                return;
            if (ctr is RibbonControl)
            {
                foreach (var item in ((RibbonControl)ctr).Items)
                {
                    if (item is DevExpress.XtraBars.BarButtonItem)
                    {
                        var i = (DevExpress.XtraBars.BarButtonItem)item;
                        var keya = GetResxNameByValue(i.Caption);
                        if (!string.IsNullOrEmpty(keya))
                            i.Caption = GetString(keya, language);
                    }
                }
                foreach (var item in ((RibbonControl)ctr).Pages)
                {
                    if (item is RibbonPage)
                    {
                        var i = (RibbonPage)item;
                        var keya = GetResxNameByValue(i.Text);
                        if (!string.IsNullOrEmpty(keya))
                            i.Text = GetString(keya, language);
                    }
                    else if (item is RibbonPageGroup)
                    {
                        var i = (RibbonPageGroup)item;
                        var keya = GetResxNameByValue(i.Text);
                        if (!string.IsNullOrEmpty(keya))
                            i.Text = GetString(keya, language);
                    }
                }
            }
            else if (ctr is NavBarControl)
            {
                foreach (var item in ((NavBarControl)ctr).Items)
                {
                    if (item is NavBarItem)
                    {
                        var i = (NavBarItem)item;
                        var keya = GetResxNameByValue(i.Caption);
                        if (!string.IsNullOrEmpty(keya))
                            i.Caption = GetString(keya, language);
                    }
                }
            }
            else if (ctr is DataGridView)
            {
                var col = (DataGridView)ctr;
                foreach (DataGridViewColumn dtc in col.Columns)
                {
                    if (!string.IsNullOrEmpty(dtc.HeaderText))
                    {
                        var key = GetResxNameByValue(dtc.HeaderText);
                        if (!string.IsNullOrEmpty(key))
                            dtc.HeaderText = GetString(key, language);
                    }
                }
            }
            else if (ctr is BindingNavigator)
            {
                var col = (BindingNavigator)ctr;
                foreach (ToolStripItem dtc in col.Items)
                {
                    if (!string.IsNullOrEmpty(dtc.Text))
                    {
                        var key = GetResxNameByValue(dtc.Text);
                        if (!string.IsNullOrEmpty(key))
                            dtc.Text = GetString(key, language);
                    }
                }
            }
            else if (ctr is TreeView)
            {
                var col = (TreeView)ctr;
                foreach (TreeNode node in col.Nodes)
                {
                    if (!string.IsNullOrEmpty(node.Text))
                    {
                        var key = GetResxNameByValue(node.Text);
                        if (!string.IsNullOrEmpty(key))
                            node.Text = GetString(key, language);
                    }
                    SetLanguageForTreeNode(node, language);
                }

            }
            else if (ctr is GridControl)
            {
                var gc = (GridControl)ctr;
                var lstControl = gc.Views;
                foreach (var item in lstControl)
                {
                    var view = (GridView)item;
                    foreach (GridColumn col in view.Columns)
                    {
                        var key = GetResxNameByValue(col.Caption);
                        if (!string.IsNullOrEmpty(key))
                            col.Caption = GetString(key, language);

                    }

                    foreach (GridGroupSummaryItem gr in view.GroupSummary)
                    {
                        var key = GetResxNameByValue(gr.DisplayFormat);
                        if (!string.IsNullOrEmpty(key))
                            gr.DisplayFormat = GetString(key, language);
                    }

                    if (item is BandedGridView)
                    {
                        var band = (BandedGridView)item;
                        foreach (GridBand ban in band.Bands)
                        {
                            var key = GetResxNameByValue(ban.Caption);
                            if (!string.IsNullOrEmpty(key))
                                ban.Caption = GetString(key, language);
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(view.OptionsFind.FindNullPrompt))
                    {
                        var key = GetResxNameByValue(view.OptionsFind.FindNullPrompt);

                        if (!string.IsNullOrEmpty(key))
                            view.OptionsFind.FindNullPrompt = GetString(key, language);
                    }
                }

                if (gc.EmbeddedNavigator != null && !string.IsNullOrWhiteSpace(gc.EmbeddedNavigator.TextStringFormat))
                {
                    var key = GetResxNameByValue(gc.EmbeddedNavigator.TextStringFormat);

                    if (!string.IsNullOrEmpty(key))
                        gc.EmbeddedNavigator.TextStringFormat = GetString(key, language);
                }
            }
            else if (ctr is SearchLookUpEdit)
            {
                var sear = (SearchLookUpEdit)ctr;
                var view = sear.Properties.View;
                foreach (GridColumn col in view.Columns)
                {
                    if (!string.IsNullOrWhiteSpace(col.Caption))
                    {
                        var key = GetResxNameByValue(col.Caption);
                        if (!string.IsNullOrEmpty(key))
                            col.Caption = GetString(key, language);
                    }
                }
            }
            else if (ctr is ContextMenuStrip)
            {
                var sear = (ContextMenuStrip)ctr;

                foreach (ToolStripItem col in sear.Items)
                {
                    if (!string.IsNullOrWhiteSpace(col.Text))
                    {
                        var key = GetResxNameByValue(col.Text);
                        if (!string.IsNullOrEmpty(key))
                            col.Text = GetString(key, language);
                    }
                }
            }
            else
            {
               
                var key = GetResxNameByValue(ctr.Text);
                if (!string.IsNullOrEmpty(key))
                {
                    if (ctr is ButtonBase)
                    {
                        var oldText = ctr.Text;
                        var newtext = GetString(key, language);
                        if (newtext.Length < oldText.Length && !(ctr is Label))
                        {
                            //Xử lý khoảng trắng trước chữ.
                            var numberOfOver = oldText.Length - newtext.Length;
                            var numberSplit = numberOfOver / 2;
                            var newEmptyString = string.Empty;
                         
                            if (oldText.IndexOf(" ", StringComparison.Ordinal) == 0)
                            {
                                for (var i = 0; i < numberOfOver; i++)
                                {
                                    newtext = " " + newtext;
                                }
                            }
                             //   newtext = newEmptyString + newtext;
                            //else
                            //{
                            //    for (var i = 0; i < numberSplit; i++)
                            //    {
                            //        newtext = " " + newtext + " ";
                            //    }
                            //}
                           // newtext += newEmptyString;
                            ctr.Text = newtext;
                        }
                        else
                        {
                            if (oldText.IndexOf(" ", StringComparison.Ordinal) == 0)
                                ctr.Text = oldText.Replace(oldText.Trim(), newtext.Trim());
                            ctr.Text =  newtext.Trim();
                        }
                    }
                    else
                        ctr.Text = GetString(key, language);
                }
                foreach (Control ctrChild in ctr.Controls)
                {
                    LocalizeSpecialControl(ctrChild, language);
                }
            }
            SetLanguageForContextMenu(ctr, language);
        }
        public static void LocalizeForm(Form frm, string language)
        {
            if (!LocalizedLanguage)
                return;
            foreach (Control ctr in frm.Controls)
            {
                LocalizeSpecialControl(ctr, language);
            }
            var key = GetResxNameByValue(frm.Text);
            if (!string.IsNullOrEmpty(key))
                frm.Text = GetString(key, language).ToUpper();
            else
            {
                key = GetResxNameByValue(frm.Text.ToUpper());
                if (!string.IsNullOrEmpty(key))
                {
                    var templateTiltle = GetString(key, language);
                    frm.Text = templateTiltle.First().ToString().ToUpper() + templateTiltle.Remove(0, 1).ToLower();
                }
            }
        }
        public static void LocalizeForm(UserControl frm, string language)
        {
            if (!LocalizedLanguage)
                return;
            foreach (Control ctr in frm.Controls)
            {
                LocalizeSpecialControl(ctr, language);
            }
            var key = GetResxNameByValue(frm.Text);
            if (!string.IsNullOrEmpty(key))
                frm.Text = GetString(key, language).ToUpper();
            else
            {
                key = GetResxNameByValue(frm.Text.ToUpper());
                if (!string.IsNullOrEmpty(key))
                {
                    var templateTiltle = GetString(key, language);
                    frm.Text = templateTiltle.First().ToString().ToUpper() + templateTiltle.Remove(0, 1).ToLower();
                }
            }
        }
        public static DataTable LocalizeDatatable(DataTable dt, List<string> columnsList, string language)
        {
            if (!LocalizedLanguage)
                return dt;
            foreach (DataRow dtr in dt.Rows)
            {
                foreach (var item in columnsList)
                {
                    var value = dtr[item].ToString();
                    var key = GetResxNameByValue(value);
                    if (!string.IsNullOrEmpty(key))
                        dtr[item] = GetString(key, language);
                }
            }
            dt.AcceptChanges();
            return dt;
        }
        public static void LocalizeControl(Control lstControl, string language)
        {
            if (!LocalizedLanguage)
                return;
            foreach (Control ctr in lstControl.Controls)
            {
                if (ctr is DataGridView)
                {
                    var col = (DataGridView)ctr;
                    foreach (DataGridViewColumn dtc in col.Columns)
                    {
                        if (!string.IsNullOrEmpty(dtc.HeaderText))
                        {
                            var key = GetResxNameByValue(dtc.HeaderText);
                            if (!string.IsNullOrEmpty(key))
                                dtc.HeaderText = GetString(key, language);
                        }
                    }
                }
                else
                {
                    var key = GetResxNameByValue(ctr.Text);
                    if (!string.IsNullOrEmpty(key))
                        ctr.Text = GetString(key, language);
                }
                LocalizeControl(ctr, language);
            }
        }
    }
}
