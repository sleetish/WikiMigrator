using Microsoft.SharePoint;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Xml;
using System.Text.RegularExpressions;

namespace WikiMigrator
{
    public partial class MainWindow : Form
    {
        public MainWindow()
        {
            InitializeComponent();
        }

// Server 1
        private void btn_EnumWikis_Click(object sender, EventArgs e)
        {
            Trace.AutoFlush = true;
            lst_Wikis.Items.Clear();
            Trace.WriteLine("Cleared Server 1 WikiList");
            txt_Status.Text += "Cleared Server 1 WikiList\r\n";
            txt_Status.Select(txt_Status.Text.Length, 0);
            txt_Status.ScrollToCaret();
            if (lst_Wikis.Items.Count == 0)
            {
                Server1WS.Lists s1L = new WikiMigrator.Server1WS.Lists();
                s1L.Url = txt_SiteName.Text.Trim().TrimEnd("/".ToCharArray()) +"/_vti_bin/lists.asmx";
                s1L.Credentials = System.Net.CredentialCache.DefaultCredentials;
                try
                {
                    XmlNode ndLists = s1L.GetListCollection();
                    foreach (XmlNode list in ndLists.ChildNodes)
                    {
                        if (list.Attributes["ServerTemplate"].Value == "119")
                        {
                            Trace.WriteLine("Found Source: " + list.Attributes["Title"].Value);
                            txt_Status.Text += "Found Source: " + list.Attributes["Title"].Value + "\r\n";
                            txt_Status.Select(txt_Status.Text.Length, 0);
                            txt_Status.ScrollToCaret();
                            lst_Wikis.Items.Add(list.Attributes["Title"].Value);
                        }
                    }
                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    Trace.WriteLine(ex.Message);
                    txt_Status.Text += ex.Message;
                    txt_Status.Select(txt_Status.Text.Length, 0);
                    txt_Status.ScrollToCaret();
                }
            }
        }
        private void lst_Wikis_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trace.AutoFlush = true;
            if (lst_Wikis.SelectedItem != null)
            {
                txt_SelectedWiki.Text = lst_Wikis.SelectedItem.ToString().TrimStart("/".ToCharArray());
                Trace.WriteLine("Wiki 1 set to: " + txt_SelectedWiki.Text);
                txt_Status.Text += "Wiki 1 set to: " + txt_SelectedWiki.Text + "\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
            }
        }

// Server 2
        private void btn_EnumWikis2_Click(object sender, EventArgs e)
        {
            Trace.AutoFlush = true;
            lst_Wikis2.Items.Clear();
            Trace.WriteLine("Cleared Server 2 WikiList");
            txt_Status.Text += "Cleared Server 2 WikiList\r\n";
            txt_Status.Select(txt_Status.Text.Length, 0);
            txt_Status.ScrollToCaret();
            if (lst_Wikis2.Items.Count == 0)
            {
                Server2WS.Lists s2L = new WikiMigrator.Server2WS.Lists();
                s2L.Url = txt_SiteName2.Text.Trim().TrimEnd("/".ToCharArray()) + "/_vti_bin/lists.asmx";
                s2L.Credentials = System.Net.CredentialCache.DefaultCredentials;
                try
                {
                    XmlNode ndLists2 = s2L.GetListCollection();
                    foreach (XmlNode list in ndLists2.ChildNodes)
                    {
                        if (list.Attributes["ServerTemplate"].Value == "119")
                        {
                            Trace.WriteLine("Found Destination: " + list.Attributes["Title"].Value);
                            txt_Status.Text += "Found Destination: " + list.Attributes["Title"].Value + "\r\n";
                            txt_Status.Select(txt_Status.Text.Length, 0);
                            txt_Status.ScrollToCaret();
                            lst_Wikis2.Items.Add(list.Attributes["Title"].Value);
                        }
                    }
                }
                catch (System.Web.Services.Protocols.SoapException ex)
                {
                    Trace.WriteLine(ex.Message);
                    txt_Status.Text += ex.Message;
                    txt_Status.Select(txt_Status.Text.Length, 0);
                    txt_Status.ScrollToCaret();
                }
            }
        }

        private void lst_Wikis2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Trace.AutoFlush = true;
            if (lst_Wikis2.SelectedItem != null)
            {
                txt_SelectedWiki2.Text = lst_Wikis2.SelectedItem.ToString().TrimStart("/".ToCharArray());
                Trace.WriteLine("Wiki 2 set to: " + txt_SelectedWiki2.Text);
                txt_Status.Text += "Wiki 2 set to: " + txt_SelectedWiki2.Text + "\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
            }
        }

// Operations
        private void btn_CopyWiki_Click(object sender, EventArgs e)
        {
            System.Collections.Hashtable imageLibraries = new System.Collections.Hashtable();
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting Copy of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".");
            txt_Status.Text += "Starting Copy of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".\r\n";
            txt_Status.Select(txt_Status.Text.Length, 0);
            txt_Status.ScrollToCaret();
            bool copySuccess = false;
            if ((txt_SelectedWiki.Text.Length > 0) && (txt_SelectedWiki2.Text.Length > 0))
            {
                Server1WS.Lists s1L = new WikiMigrator.Server1WS.Lists();
                s1L.Url = txt_SiteName.Text.Trim().TrimEnd("/".ToCharArray()) + "/_vti_bin/lists.asmx";
                s1L.Credentials = System.Net.CredentialCache.DefaultCredentials;

                Server2WS.Lists s2L = new WikiMigrator.Server2WS.Lists();
                s2L.Url = txt_SiteName2.Text.Trim().TrimEnd("/".ToCharArray()) + "/_vti_bin/lists.asmx";
                s2L.Credentials = System.Net.CredentialCache.DefaultCredentials;
                try
                {
                    // Need to provide a large number or we will restrict at the default 100 items if null
                    XmlNode ndListItems = s1L.GetListItems(txt_SelectedWiki.Text, null, null, null, txtNumberRows.Text, null, null);
                    XmlNode ndListItemDetail = ndListItems.ChildNodes[1];
                    foreach (XmlNode item in ndListItemDetail.ChildNodes)
                    {
                        try
                        {
                            if (item.Attributes != null)
                            {
                                string itemName = item.Attributes["ows_LinkFilename"].Value;
                                Trace.WriteLine("Copying: " + itemName);
                                if (!string.IsNullOrEmpty(itemName))
                                {
                                    Server1CopyWS.Copy myCopyService = new WikiMigrator.Server1CopyWS.Copy();
                                    myCopyService.Url = txt_SiteName.Text.Trim().TrimEnd("/".ToCharArray()) + "/_vti_bin/copy.asmx";
                                    myCopyService.Credentials = System.Net.CredentialCache.DefaultCredentials;

                                    Server2CopyWS.Copy myCopyService2 = new WikiMigrator.Server2CopyWS.Copy();
                                    myCopyService2.Url = txt_SiteName2.Text.Trim().TrimEnd("/".ToCharArray()) + "/_vti_bin/copy.asmx";
                                    myCopyService2.Credentials = System.Net.CredentialCache.DefaultCredentials;

                                    string copySource = txt_SiteName.Text + "/" + txt_SelectedWiki.Text + "/" + itemName;
                                    string[] copyDest = { txt_SiteName2.Text + "/" + txt_SelectedWiki2.Text + "/" + itemName };

                                    WikiMigrator.Server1CopyWS.FieldInformation myFieldInfo = new WikiMigrator.Server1CopyWS.FieldInformation();
                                    WikiMigrator.Server1CopyWS.FieldInformation[] myFieldInfoArray = { myFieldInfo };
                                    byte[] myByteArray;

                                    uint myGetUint = myCopyService.GetItem(copySource, out myFieldInfoArray, out myByteArray);
                                    WikiMigrator.Server2CopyWS.FieldInformation[] myFieldInfoArray2 = new WikiMigrator.Server2CopyWS.FieldInformation[myFieldInfoArray.Length];
                                    string sourceWikiField = string.Empty;

                                    for (int x = 0; x < myFieldInfoArray.Length; x++)
                                    {
                                        if (myFieldInfoArray[x].InternalName == "WikiField")
                                        {
                                            sourceWikiField = myFieldInfoArray[x].Value;
                                        }
                                        if (chkDebugFull.Checked)
                                        {
                                            Trace.WriteLine("SourceProp: " + myFieldInfoArray[x].InternalName + " = " + myFieldInfoArray[x].Value);
                                        }
                                        WikiMigrator.Server2CopyWS.FieldInformation myFieldInfo2 = new WikiMigrator.Server2CopyWS.FieldInformation();
                                        myFieldInfo2.DisplayName = myFieldInfoArray[x].DisplayName;
                                        myFieldInfo2.Id = myFieldInfoArray[x].Id;
                                        myFieldInfo2.InternalName = myFieldInfoArray[x].InternalName;
                                        myFieldInfo2.Type = (Server2CopyWS.FieldType)myFieldInfoArray[x].Type;
                                        myFieldInfo2.Value = myFieldInfoArray[x].Value;
                                        myFieldInfoArray2[x] = myFieldInfo2;
                                    }
                                    // This wont work, and you can't cast the FieldInfo[] object between webservices--hence the above loop
                                    //myFieldInfoArray.CopyTo(myFieldInfoArray2, 0);

                                    // Try to find image tags and note their lists
                                    MatchCollection imageMatches = Regex.Matches(sourceWikiField, "<img.*src=\"(.*)\">", RegexOptions.IgnoreCase);
                                    foreach (Match imageMatch in imageMatches)
                                    {
                                        MatchCollection srcMatches = Regex.Matches(sourceWikiField, "src=\"(.*)\"", RegexOptions.IgnoreCase);
                                        foreach (Match srcMatch in srcMatches)
                                        {
                                            string imageUrl = srcMatch.Value.TrimStart("src=".ToCharArray()).TrimStart("\"".ToCharArray()).TrimEnd("\"".ToCharArray());
                                            int lastSlash = imageUrl.LastIndexOf("/");
                                            string imageParentUrl = string.Empty;
                                            if (lastSlash > 0)
                                            {
                                                imageParentUrl = imageUrl.Substring(0, lastSlash - 1);
                                            }
                                            Trace.WriteLine("Found image: " + imageUrl);
                                            if (!string.IsNullOrEmpty(imageParentUrl))
                                            {
                                                if (!imageLibraries.Contains(imageParentUrl))
                                                {
                                                    imageLibraries.Add(imageParentUrl, string.Empty);
                                                    Trace.WriteLine("Added Library: " + imageParentUrl);
                                                }
                                            }
                                        }
                                    }

                                    // Are we local OM or remote WS?
                                    if (!chk_DestLocal.Checked)
                                    {
                                        WikiMigrator.Server2CopyWS.CopyResult myCopyResult1 = new WikiMigrator.Server2CopyWS.CopyResult();
                                        WikiMigrator.Server2CopyWS.CopyResult myCopyResult2 = new WikiMigrator.Server2CopyWS.CopyResult();
                                        WikiMigrator.Server2CopyWS.CopyResult[] myCopyResultArray = { myCopyResult1, myCopyResult2 };

                                        try
                                        {
                                            //uint myCopyUint = myCopyService2.CopyIntoItems(copyDest[0], copyDest, myFieldInfoArray2, myByteArray, out myCopyResultArray);
                                            uint myCopyUint = myCopyService2.CopyIntoItems(copySource, copyDest, myFieldInfoArray2, myByteArray, out myCopyResultArray);
                                            if (myCopyUint == 0)
                                            {
                                                int idx = 0;
                                                foreach (WikiMigrator.Server2CopyWS.CopyResult myCopyResult in myCopyResultArray)
                                                {
                                                    string opString = (idx + 1).ToString();
                                                    if (myCopyResultArray[idx].ErrorMessage == null)
                                                    {
                                                        Trace.WriteLine("Copied to: " + myCopyResultArray[idx].DestinationUrl);
                                                        txt_Status.Text += "Copied to: " + myCopyResultArray[idx].DestinationUrl + "\r\n";
                                                        txt_Status.Select(txt_Status.Text.Length, 0);
                                                        txt_Status.ScrollToCaret();
                                                        copySuccess = true;
                                                    }
                                                    else
                                                    {
                                                        Trace.WriteLine("COPY SERVICE FAILURE--TRY LOCAL DEST INSTEAD");
                                                        Trace.WriteLine("ERROR: " + myCopyResultArray[idx].ErrorMessage);
                                                        txt_Status.Text += "Copy Operation Failure.  Try Local Dest instead.  Exception: " + myCopyResultArray[idx].ErrorMessage + "\r\n";
                                                        txt_Status.Select(txt_Status.Text.Length, 0);
                                                        txt_Status.ScrollToCaret();
                                                    }
                                                    idx++;
                                                }
                                            }
                                        }
                                        catch (Exception exc)
                                        {
                                            int idx = 0;
                                            foreach (WikiMigrator.Server2CopyWS.CopyResult myCopyResult in myCopyResultArray)
                                            {
                                                idx++;
                                                if (myCopyResult.DestinationUrl == null)
                                                {
                                                    string idxString = idx.ToString();
                                                    Trace.WriteLine("Copy Operation Failure.  Exception: " + exc.Message);
                                                    txt_Status.Text += "Copy Operation Failure.  Exception: " + exc.Message + "\r\n";
                                                    txt_Status.Select(txt_Status.Text.Length, 0);
                                                    txt_Status.ScrollToCaret();
                                                }
                                            }
                                        }
                                    }
                                    else
                                    { // Local dest
                                        copySuccess = manualLocalCopy(sourceWikiField, itemName, myFieldInfoArray2, myByteArray, copyDest, copySuccess);
                                    }
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            try
                            {
                                Trace.WriteLine("Item " + item.Name + " Exception: " + exc.Message);
                                txt_Status.Text += "Item " + item.Name + " Exception: " + exc.Message + "\r\n";
                            }
                            catch
                            {
                                Trace.WriteLine("Item ? Exception: " + exc.Message);
                                txt_Status.Text += "Item ? Exception: " + exc.Message + "\r\n";
                            }
                            txt_Status.Select(txt_Status.Text.Length, 0);
                            txt_Status.ScrollToCaret();
                        }
                    }
                }
                catch (Exception exc)
                {
                    Trace.WriteLine("GetListItem Exception: " + exc.Message);
                    txt_Status.Text += "GetListItem Exception: " + exc.Message + "\r\n";
                    txt_Status.Select(txt_Status.Text.Length, 0);
                    txt_Status.ScrollToCaret();
                }
            }
            if (imageLibraries.Count > 0)
            {
                Trace.WriteLine("===============================================");
                Trace.WriteLine("The following location(s) contain images used by the coppied wikis.  They should be coppied manually to new locations matching the structure from:");
                Trace.WriteLine("");
                txt_Status.Text += "===============================================\r\nThe following location(s) contain wiki images to be coppied:\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
                foreach (System.Collections.DictionaryEntry imageLibrary in imageLibraries)
                {
                    Trace.WriteLine(imageLibrary.Key);
                    txt_Status.Text += imageLibrary.Key + "\r\n";
                    txt_Status.Select(txt_Status.Text.Length, 0);
                    txt_Status.ScrollToCaret();
                }
                Trace.WriteLine("");
                txt_Status.Text += "\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
            }
            if (copySuccess)
            {
                Trace.WriteLine("Completed copy of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text);
                txt_Status.Text += "Completed copy of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
            }
            else
            {
                Trace.WriteLine("Copy routine completed, but without success.");
                txt_Status.Text += "Copy routine completed, but without success.\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
            }

        }

        private bool manualLocalCopy(string sourceWikiField, string itemName, WikiMigrator.Server2CopyWS.FieldInformation[] myFieldInfoArray2, byte[] myByteArray, string[] copyDest, bool copySuccess)
        {
            bool manualSuccess = false;
            if (!string.IsNullOrEmpty(sourceWikiField))
            {
                try
                {
                    string modifiedData = sourceWikiField.Replace(@"\r\n", "");
                    modifiedData = modifiedData.Replace(@"\\", @"\");

                    try
                    {
                        // open site, web, list, and file collection
                        SPSite site = new SPSite(txt_SiteName2.Text);
                        SPWeb web = site.OpenWeb();
                        SPList list = web.Lists[txt_SelectedWiki2.Text];
                        SPFileCollection files = list.RootFolder.Files;
                        SPFile newFile = null;
                        try
                        {
                            // add new wiki page
                            newFile = files.Add(txt_SelectedWiki2.Text.TrimEnd("/".ToCharArray()) + "/" + itemName, SPTemplateFileType.WikiPage);
                        }
                        catch (Exception exc)
                        {
                            newFile = files[itemName];
                        }
                        // get the list item corresponding to the wiki page and update its content
                        SPListItem item = newFile.Item;
                        item["WikiField"] = sourceWikiField;
                        item.Update();
                        manualSuccess = true;
                        copySuccess = true;
                    }
                    catch (Exception exc)
                    {
                        if (exc.Message.Contains("-2147024816"))
                        {
                            Trace.WriteLine("File exists in target");
                        }
                        else
                        {
                            Trace.WriteLine("manualLocalCopy Exception: " + exc.Message);
                        }
                        // You need a try-catch block because new SPSite(), OpenWeb(), and GetList()
                        // all throw on failure.
                    }
 
                    //string strBatch = "<Method ID='1' Cmd='New'>" +
                    //    "<Field Name='ID'>New</Field>" +
                    //    "<Field Name='WikiField'><![CDATA[" + modifiedData + "]]></Field>" +
                    //    //"<Field Name='_CopySource'></Field> +
                    //    "</Method>";
                    //if (chkDebugFull.Checked)
                    //{
                    //    Trace.WriteLine("***** " + itemName + " ***** MANUAL COPY *****");
                    //    Trace.WriteLine(strBatch);
                    //}
                    //XmlDocument xmlDoc = new System.Xml.XmlDocument();
                    //System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");
                    //elBatch.SetAttribute("OnError", "Continue");
                    ////elBatch.SetAttribute("ListVersion", "1");
                    //elBatch.InnerXml = strBatch;
                    //XmlNode ndReturn = s2L.UpdateListItems(txt_SelectedWiki2.Text, elBatch);
                    //if (ndReturn != null)
                    //{
                    //    if (ndReturn.InnerText != "0x00000000")
                    //    {
                    //        Trace.WriteLine("ErrorCode - " + ndReturn.InnerText);
                    //        //Trace.WriteLine(ndReturn.ChildNodes[0].ChildNodes[0].Name + " - " + ndReturn.ChildNodes[0].ChildNodes[0].InnerXml);
                    //    }
                    //    else
                    //    {
                    //        string newID = ndReturn.FirstChild.LastChild.Attributes["ows_ID"].Value;
                    //        string newSource = ndReturn.FirstChild.LastChild.Attributes["ows_EncodedAbsUrl"].Value;





                    //        uint myGetUintMan = myCopyService2.GetItem(newSource, out myFieldInfoArray2, out myByteArray);
                    //        //myFieldInfoArray2 = new WikiMigrator.Server2CopyWS.FieldInformation[myFieldInfoArray.Length];
                    //        //for (int x = 0; x < myFieldInfoArray.Length; x++)
                    //        //{
                    //        //    //if (myFieldInfoArray[x].InternalName == "WikiField")
                    //        //    //{
                    //        //    //    sourceWikiField = myFieldInfoArray[x].Value;
                    //        //    //}
                    //        //    Trace.WriteLine(myFieldInfoArray[x].InternalName + " = " + myFieldInfoArray[x].Value);
                    //        //    WikiMigrator.Server2CopyWS.FieldInformation myFieldInfo2 = new WikiMigrator.Server2CopyWS.FieldInformation();
                    //        //    myFieldInfo2.DisplayName = myFieldInfoArray[x].DisplayName;
                    //        //    myFieldInfo2.Id = myFieldInfoArray[x].Id;
                    //        //    myFieldInfo2.InternalName = myFieldInfoArray[x].InternalName;
                    //        //    myFieldInfo2.Type = (Server2CopyWS.FieldType)myFieldInfoArray[x].Type;
                    //        //    myFieldInfo2.Value = myFieldInfoArray[x].Value;
                    //        //    myFieldInfoArray2[x] = myFieldInfo2;
                    //        //}





                    //        uint myCopyUintMan = myCopyService2.CopyIntoItems(string.Empty, copyDest, new Server2CopyWS.FieldInformation[0], myByteArray, out myCopyResultArray);
                    //        strBatch = "<Method ID='1' Cmd='Update'>" +
                    //            "<Field Name='ID'>" + newID + "</Field>" +
                    //            "<Field Name='Title'>" + itemName.Split(".".ToCharArray())[0] + "</Field>" +
                    //            "<Field Name='BaseName'>" + itemName.Split(".".ToCharArray())[0] + "</Field>" +
                    //            "<Field Name='SelectTitle'>" + itemName.Split(".".ToCharArray())[0] + "</Field>" +
                    //            "<Field Name='SelectFilename'>" + itemName.Split(".".ToCharArray())[0] + "</Field>" +
                    //            "<Field Name='LinkFilename'>" + itemName + "</Field>" +
                    //            "<Field Name='LinkFilenameNoMenu'>" + itemName + "</Field>" +
                    //            "</Method>";
                    //        xmlDoc = new System.Xml.XmlDocument();
                    //        elBatch = xmlDoc.CreateElement("Batch");
                    //        elBatch.SetAttribute("OnError", "Continue");
                    //        //elBatch.SetAttribute("ListVersion", "1");
                    //        elBatch.InnerXml = strBatch;
                    //        ndReturn = s2L.UpdateListItems(txt_SelectedWiki2.Text, elBatch);
                    //        if (ndReturn != null)
                    //        {
                    //            if (ndReturn.InnerText != "0x00000000")
                    //            {
                    //                Trace.WriteLine("ErrorCode - " + ndReturn.InnerText);
                    //                //Trace.WriteLine(ndReturn.ChildNodes[0].ChildNodes[0].Name + " - " + ndReturn.ChildNodes[0].ChildNodes[0].InnerXml);
                    //            }
                    //            else
                    //            {
                    //                manualSuccess = true;
                    //                Trace.WriteLine("Copied to: " + myCopyResultArray[idx].DestinationUrl);
                    //                txt_Status.Text += "Copied to: " + myCopyResultArray[idx].DestinationUrl + "\r\n";
                    //                txt_Status.Select(txt_Status.Text.Length, 0);
                    //                txt_Status.ScrollToCaret();
                    //                copySuccess = true;
                    //            }
                    //        }
                    //    }
                    //}
                }
                catch (Exception exc)
                {
                    Trace.WriteLine("***ERROR*** Manual copy failed " + exc.Message);
                }
            }
            if (!manualSuccess)
            {
                Trace.WriteLine("Manual copy of " + itemName + " failed.");
                txt_Status.Text += "Manual copy of " + itemName + " failed.\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
            }
            else
            {
                Trace.WriteLine("Coppied to " + txt_SiteName2.Text.TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki2.Text.TrimEnd("/".ToCharArray()) + "/" + itemName);
                txt_Status.Text += "Coppied to " + txt_SiteName2.Text.TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki2.Text.TrimEnd("/".ToCharArray()) + "/" + itemName + "\r\n";
                txt_Status.Select(txt_Status.Text.Length, 0);
                txt_Status.ScrollToCaret();
                copySuccess = true;
            }
            return copySuccess;
        }

        private void btnFixWiki2Links_Click(object sender, EventArgs e)
        {
            Trace.AutoFlush = true;
            Trace.WriteLine("Starting Edit of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".");
            txt_Status.Text += "Starting Edit of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".\r\n";
            txt_Status.Select(txt_Status.Text.Length, 0);
            txt_Status.ScrollToCaret();
            bool editSuccess = false;
            if (txt_SelectedWiki2.Text.Length > 0)
            {
                Server2WS.Lists s2L = new WikiMigrator.Server2WS.Lists();
                s2L.Url = txt_SiteName2.Text.Trim().TrimEnd("/".ToCharArray()) + "/_vti_bin/lists.asmx";
                s2L.Credentials = System.Net.CredentialCache.DefaultCredentials;
                try
                {
                    XmlDocument xmlDocLI = new System.Xml.XmlDocument();
                    XmlNode ndQueryLI = xmlDocLI.CreateNode(XmlNodeType.Element,"Query","");
                    XmlNode ndViewFieldsLI = xmlDocLI.CreateNode(XmlNodeType.Element,"ViewFields","");
                    XmlNode ndQueryOptionsLI = xmlDocLI.CreateNode(XmlNodeType.Element,"QueryOptions","");

                    ndQueryOptionsLI.InnerXml = "<IncludeMandatoryColumns>FALSE</IncludeMandatoryColumns>" +
                        "<DateInUtc>TRUE</DateInUtc>";
                    ndViewFieldsLI.InnerXml = "<FieldRef Name='FileRef' />" +
                        "<FieldRef Name='WikiField' />" + 
                        "<FieldRef Name='LinkFilename' />";
                    ndQueryLI.InnerXml = "<Where><Eq><FieldRef Name='FileRef' />" +
                        "<Value Type='Text'>[server-relative URL of wiki page]</Value></Eq></Where>";
                    //
                    // Need to provide a large number or we will restrict at the default 100 items if null
                    XmlNode ndListItems = s2L.GetListItems(txt_SelectedWiki2.Text, null, null, ndViewFieldsLI, txtNumberRows.Text, null, null);
                    XmlNode ndListItemDetail = ndListItems.ChildNodes[1];
                    foreach (XmlNode item in ndListItemDetail.ChildNodes)
                    {
                        try
                        {
                            if (item.Attributes != null)
                            {
                                string itemName = item.Attributes["ows_LinkFilename"].Value;
                                Trace.WriteLine("Fixing: " + itemName);
                                if (!string.IsNullOrEmpty(itemName))
                                {
                                    string copySource = txt_SiteName.Text.Trim().TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki.Text.Trim().TrimEnd("/".ToCharArray()).TrimStart("/".ToCharArray()) + "/" + itemName;
                                    string copyDest = txt_SiteName2.Text.Trim().TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki2.Text.Trim().TrimEnd("/".ToCharArray()).TrimStart("/".ToCharArray()) + "/" + itemName;

                                    string wikiData = item.Attributes["ows_WikiField"].Value;
                                    string actualWikiData = string.Empty;
                                    if (string.IsNullOrEmpty(wikiData))
                                    {
                                        Trace.WriteLine("...using ows_MetaInfo instead of ows_WikiField");
                                        string itemData = item.Attributes["ows_MetaInfo"].Value;
                                        Regex metaProp = new Regex(@"( \w*:\w{2}\|)");
                                        string[] regexData = metaProp.Split(itemData);
                                        bool prepnextMatch = false;
                                        foreach (string data in regexData)
                                        {
                                            try
                                            {
                                                if (data != string.Empty)
                                                {
                                                    if (!prepnextMatch)
                                                    {
                                                        if (data == " WikiField:SW|")
                                                        {
                                                            prepnextMatch = true;
                                                        }
                                                    }
                                                    else if (prepnextMatch && actualWikiData == string.Empty)
                                                    {
                                                        actualWikiData = data;
                                                        break;
                                                    }
                                                    else
                                                    {
                                                        throw new System.Exception("E_FAIL");
                                                    }
                                                }
                                            }
                                            catch (Exception exc)
                                            {
                                                Trace.WriteLine("Datafield Exception: " + exc.Message);
                                                txt_Status.Text += "Datafield Exception: " + exc.Message + "\r\n";
                                                txt_Status.Select(txt_Status.Text.Length, 0);
                                                txt_Status.ScrollToCaret();
                                            }
                                        }
                                    }
                                    else
                                    {
                                        actualWikiData = wikiData;
                                    }
                                    // Locals for replacement operations
                                    string sitename = txt_SiteName.Text.TrimEnd("/".ToCharArray());
                                    string destsite = txt_SiteName2.Text.TrimEnd("/".ToCharArray());
                                    string wiki1 = txt_SelectedWiki.Text.TrimStart("/".ToCharArray());
                                    string wiki2 = txt_SelectedWiki2.Text.TrimStart("/".ToCharArray());
                                    Uri sourceSiteUri = new Uri(sitename);
                                    Uri destSiteUri = new Uri(destsite);
                                    string sourceAbsolute = sourceSiteUri.AbsolutePath.TrimEnd("/".ToCharArray());
                                    string destAbsolute = destSiteUri.AbsolutePath.TrimEnd("/".ToCharArray());
                                    
                                    //  http://server1/site/library  to  http://server2/newsite/newlibrary
                                             //string modifiedData = actualWikiData.Replace(txt_SiteName.Text.TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki.Text, txt_SiteName2.Text.TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki2.Text.TrimStart("/".ToCharArray()));
                                    string modifiedData = Regex.Replace(actualWikiData, Regex.Escape(sitename + "/" + wiki1), Regex.Escape(destsite + "/" + wiki2), RegexOptions.IgnoreCase);
                                    //  http://server1   to  http://server2
                                             //modifiedData = modifiedData.Replace(txt_SiteName.Text, txt_SiteName2.Text);
                                    modifiedData = Regex.Replace(modifiedData, Regex.Escape(sitename), Regex.Escape(destsite), RegexOptions.IgnoreCase);
                                    //   /site/library   to  /newsite/newlibrary   (+ Encoded)
                                             //modifiedData = modifiedData.Replace(sourceSite.AbsolutePath.TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki.Text.TrimStart("/".ToCharArray()), destSite.AbsolutePath.TrimEnd("/".ToCharArray()) + "/" + txt_SelectedWiki2.Text.TrimStart("/".ToCharArray()));
                                    modifiedData = Regex.Replace(modifiedData, Regex.Escape(sourceAbsolute + "/" + wiki1), Regex.Escape(destAbsolute + "/" + wiki2), RegexOptions.IgnoreCase);
                                             //modifiedData = modifiedData.Replace(sourceSite.AbsolutePath.TrimEnd("/".ToCharArray()) + "/" + Uri.EscapeDataString(txt_SelectedWiki.Text.TrimStart("/".ToCharArray())), destSite.AbsolutePath.TrimEnd("/".ToCharArray()) + "/" + Uri.EscapeDataString(txt_SelectedWiki2.Text.TrimStart("/".ToCharArray())));
                                    modifiedData = Regex.Replace(modifiedData, Regex.Escape(sourceAbsolute + "/" + Uri.EscapeDataString(wiki1)), Regex.Escape(destAbsolute + "/" + Uri.EscapeDataString(wiki2)), RegexOptions.IgnoreCase);
                                    //   /site  to  /newsite 
                                    //   This is very dangerous... since source could be '/' and if it actually is, we would replace every / in the doc
                                    //if (sourceSiteUri.AbsolutePath != "/")
                                    //{
                                    //    modifiedData = modifiedData.Replace(sourceSiteUri.AbsolutePath, destSiteUri.AbsolutePath);
                                    //    modifiedData = Regex.Replace(modifiedData, Regex.Escape(), Regex.Escape(), RegexOptions.IgnoreCase);
                                    //}
                                    // Kill the linefeeds and \\ because they will be literal since we have to use CDATA.
                                    modifiedData = modifiedData.Replace(@"\r\n", "");
                                    modifiedData = modifiedData.Replace(@"\\", @"\");
                                    if (chk_AdvRepl.Checked)
                                    {
                                        modifiedData = modifiedData.Replace(txt_Repl1.Text, txt_Repl2.Text);
                                    }

                                    string strBatch = "<Method ID='1' Cmd='Update'>" +
                                        "<Field Name='ID'>" + item.Attributes["ows_ID"].Value + "</Field>" +
                                        "<Field Name='WikiField'><![CDATA[" + modifiedData + "]]></Field>" +
                                        "<Field Name='_CopySource'></Field></Method>";

                                    if (chkDebugFull.Checked)
                                    {
                                        Trace.WriteLine("***** " + itemName + " *****");
                                        Trace.WriteLine(strBatch);
                                    }
                                    XmlDocument xmlDoc = new System.Xml.XmlDocument();
                                    System.Xml.XmlElement elBatch = xmlDoc.CreateElement("Batch");
                                    elBatch.SetAttribute("OnError", "Continue");
                                    elBatch.SetAttribute("ListVersion", "1");
                                    elBatch.InnerXml = strBatch;

                                    s2L.UpdateListItems(txt_SelectedWiki2.Text, elBatch);

                                    Trace.WriteLine("Updated: " + itemName);
                                    txt_Status.Text += "Updated: " + itemName + "\r\n";
                                    txt_Status.Select(txt_Status.Text.Length, 0);
                                    txt_Status.ScrollToCaret();
                                    editSuccess = true;
                                }
                            }
                        }
                        catch (Exception exc)
                        {
                            try
                            {
                                Trace.WriteLine("Item " + item.Name + " Exception: " + exc.Message);
                                txt_Status.Text += "Item " + item.Name + " Exception: " + exc.Message + "\r\n";
                            }
                            catch
                            {
                                Trace.WriteLine("Item ? Exception: " + exc.Message);
                                txt_Status.Text += "Item ? Exception: " + exc.Message + "\r\n";
                            }
                            txt_Status.Select(txt_Status.Text.Length, 0);
                            txt_Status.ScrollToCaret();
                        }
                    }
                }
                catch (Exception exc)
                {
                    Trace.WriteLine("GetListItems Exception: " + exc.Message);
                    txt_Status.Text += "GetListItems Exception: " + exc.Message + "\r\n";
                    txt_Status.Select(txt_Status.Text.Length, 0);
                    txt_Status.ScrollToCaret();
                }
                if (editSuccess)
                {
                    Trace.WriteLine("Completed update of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".");
                    txt_Status.Text += "Completed update of \"" + txt_SelectedWiki.Text + "\" to \"" + txt_SelectedWiki2.Text + "\".\r\n";
                    txt_Status.Select(txt_Status.Text.Length, 0);
                    txt_Status.ScrollToCaret();
                }
            }
        }

        private void chk_AdvRepl_CheckedChanged(object sender, EventArgs e)
        {
            if (chk_AdvRepl.Checked)
            {
                txt_Repl1.Enabled = true;
                txt_Repl2.Enabled = true;
            }
            else
            {
                txt_Repl1.Enabled = false;
                txt_Repl2.Enabled = false;
            }
        }
    }
}