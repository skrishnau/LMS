using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Academic.DbHelper;
using Academic.ViewModel;
using One.Values;

namespace One.Views.All_Resusable_Codes.FileTasks
{
    public partial class FilePickerDialog : System.Web.UI.UserControl
    {
        #region Events Declaration

        public event EventHandler<FileResourceEventArgs> ItemClick;
        public event EventHandler<FileResourceEventArgs> UploadClicked;
        public event EventHandler<EventArgs> DialogCloseClicked;

        public event EventHandler<FileResourceEventArgs> SaveClick;
        public event EventHandler<FileResourceEventArgs> OkClick;
        public event EventHandler<EventArgs> CancelClick;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
            FilePicker1.UploadClicked += FilePicker1_UploadClicked;
        }

        public void FilePicker1_UploadClicked(object sender, FileResourceEventArgs e)
        {
            if (UploadClicked != null)
            {
                UploadClicked(sender, e);
            }
        }

        //public string FileType = "All";
        public string FileType
        {
            set { FilePicker1.FileType = value; }
        }
        /// <summary>
        /// preceeded by '.'
        /// </summary>
        //public string FileExtension = "All";

        public string FileExtension
        {
            set { FilePicker1.FileExtension = value; }
        }

        public string FileSaveDirectory
        {
            get { return hidFileSaveDirectory.Value; }
            set
            {
                FilePicker1.FileSaveDirectory = value;
                hidFileSaveDirectory.Value = value;
            }
        }
        public Enums.FileAcquireMode FileAcquireMode
        {
            get { return Enums.ParseEnum<Enums.FileAcquireMode>(hidFileAcquireMode.Value); }
            set
            {
                FilePicker1.FileAcquireMode = value;
                hidFileAcquireMode.Value = value.ToString();
            }
        }

        public string PageKey
        {
            get { return hidPageKey.Value; }
            set
            {
                hidPageKey.Value = value;
                FilePicker1.PageKey = value;
            }
        }

        #region Dimensions

        public int Height_Y
        {
            set { dialogdiv.Style.Add("height", value.ToString() + "px"); }
            get
            {
                var height = dialogdiv.Style["height"].Replace("px", "");
                var he = 0;
                var success = Int32.TryParse(height, out he);
                return he;
            }
        }
        public int Width_X
        {
            set { dialogdiv.Style.Add("width", value.ToString() + "px"); }
            get
            {
                var width = dialogdiv.Style["width"].Replace("px", "");
                var we = 0;
                var success = Int32.TryParse(width, out we);
                return we;
            }
        }

        #endregion

        #region Public Functions

        public void AddControl(UserControl control)
        {
            pnlItemsControl.Controls.Add(control);
        }

        public void SetValues(string title, string itemClickMode, params string[] buttons)
        {
            lblHeading.Text = title;
            hidItemClickMode.Value = itemClickMode;

            //dataList.DataSource = items;
            //dataList.DataBind();

            //if (buttons != null)
            //    if (buttons.Any())
            //    {
            //        foreach (var b in buttons)
            //        {
            //            switch (b.ToLower())
            //            {
            //                case "save":
            //                    btnDialogSave.Visible = true;
            //                    break;
            //                case "ok":
            //                    btnDialogOk.Visible = true;
            //                    break;
            //                case "cancel":
            //                    btnDialogCancel.Visible = true;
            //                    break;
            //            }

            //        }
            //    }
            //    else buttonsDiv.Visible = false;
            //else buttonsDiv.Visible = false;
        }

        public void OpenDialog()
        {
            Session["LatestFile" + PageKey] = null;
            dialogdiv.Visible = true;
        }

        public bool IsOpen()
        {
            return dialogdiv.Visible;
        }

        /// <summary>
        /// Session["LatestFile"] is made null when dialog is closed
        /// </summary>
        public void CloseDialog()
        {
            dialogdiv.Visible = false;
            Session["LatestFile" + PageKey] = null;

        }
        public string GetClickMode()
        {
            return hidItemClickMode.Value;
        }
        #endregion

        #region Events Callback

        protected void btnDialogClose_Click(object sender, EventArgs e)
        {
            //deletion of file from server
            //if (DialogCloseClicked != null)
            {
                var latest = Session["LatestFile" + PageKey] as FileResourceEventArgs;
                if (latest != null)
                {
                    System.IO.File.Delete(Server.MapPath(latest.FilePath));
                }
            }

            CloseDialog();
        }

        //protected void dataList_ItemCommand(object source, DataListCommandEventArgs e)
        //{
        //    var arg = e.CommandArgument;
        //    if (arg != null)
        //    {
        //        if (ItemClick != null)
        //        {
        //            var split = arg.ToString().Split(new char[] { ',' });
        //            if (split.Count() == 2)
        //            {
        //                ItemClick(this, new FileResourceEventArgs()
        //                {
        //                    Id = Convert.ToInt32(split[0])
        //                    ,
        //                    Name = split[1]
        //                    ,
        //                    //RefIdString = RestrictionId
        //                });
        //            }

        //        }
        //    }
        //}

        //protected void btnSave_Click(object sender, EventArgs e)
        //{
        //    //var user = Page.User as CustomPrincipal;
        //    //if (user != null)
        //        if (Page.IsValid)
        //        {

        //            var date = DateTime.Now.Date;


        //            using (var helper = new Academic.DbHelper.DbHelper.User())
        //            {
        //                var savedUser = helper.AddOrUpdateUser(createdUser, cmbRole.SelectedValue, FileUpload1.PostedFile);

        //                if (savedUser != null)
        //                {

        //                    //if (FileUpload1.HasFile)
        //                    {
        //                        var imageFile = FileUpload1.PostedFile;


        //                        var image = new Academic.DbEntities.UserFile()
        //                        {
        //                            CreatedBy = user.Id
        //                            ,
        //                            CreatedDate = DateTime.Now
        //                            ,
        //                            DisplayName = Path.GetFileName(imageFile.FileName)
        //                            ,
        //                            FileDirectory = StaticValue.UserImageDirectory
        //                            ,
        //                            FileName = Guid.NewGuid().ToString() + GetExtension(imageFile.FileName, imageFile.ContentType)
        //                            ,
        //                            FileSizeInBytes = imageFile.ContentLength
        //                            ,
        //                            FileType = imageFile.ContentType
        //                            ,
        //                        };
        //                        using (var fhelper = new DbHelper.WorkingWithFiles())
        //                        {
        //                            GetNewGuid(fhelper, image);
        //                            //TrimFirstLetterFromImageFileName(image);
        //                            if (trimLoop > 9 || guidLoop > 9)
        //                            {
        //                                //cancel all save
        //                            }
        //                            else
        //                            {
        //                                var savedFile = fhelper.AddOrUpdateFile(image);

        //                                if (savedFile != null)
        //                                {
        //                                    //save the image with this name
        //                                    //var filename = Path.GetFileName(file.FileName);
        //                                    var path = Path.Combine(Server.MapPath(StaticValue.UserImageDirectory),
        //                                        image.FileName);
        //                                    imageFile.SaveAs(path);

        //                                    //add the image Id to user 
        //                                    helper.UpdateUsersImage(savedUser.Id, savedFile.Id);


        //                                    //    return true;
        //                                }

        //                            }

        //                        }

        //                    }
        //                }

        //                //Label label = (Label)this.Page.FindControl("lblBodyMessage");
        //                //if (label != null)
        //                {
        //                    if (savedUser != null)
        //                    {
        //                        //label.Text = "Save Successful.";
        //                        Page.Response.Redirect("List.aspx");
        //                        //ResetTextAndCombos();
        //                    }
        //                    //else
        //                    //    label.Text = "Error while saving.";
        //                }
        //            }

        //            //lblSaveStatus.Text = ("Save Successful.");
        //            //lblSaveStatus.Visible = true;

        //        }


        //}

        //perfect and tested


        private int count = 0;
        /// <summary>
        /// Gets New File Name. Before calling this initialize "count" to 0;
        /// </summary>
        /// <param name="fhelper">to redeuce initializaiton of dbhelper every time.</param>
        /// <param name="fileName">filename along with extension e.g. "myfile.png"</param>
        /// <returns></returns>
        private string GetNewFileName(Academic.DbHelper.DbHelper.WorkingWithFiles fhelper, string fileName)
        {
            if (count < DbHelper.StaticValues.MaximimNumberOfTimesToCheckForSameFileName)
            {
                count++;
                if (fhelper.DoesFileExists(fileName))
                {
                    var extension = Path.GetExtension(fileName);
                    var s = Guid.NewGuid().ToString() + extension;
                    return GetNewFileName(fhelper, s);
                }
                else
                {

                    return fileName;
                }
            }
            return "";
        }

        //protected void btnDialogSave_Click(object sender, EventArgs e)
        //{
        //    dialogdiv.Visible = false;
        //    if (SaveClick != null)
        //    {
        //        SaveClick(sender, new FileResourceEventArgs());
        //    }
        //}

        //protected void btnDialogOk_Click(object sender, EventArgs e)
        //{
        //    dialogdiv.Visible = false;
        //    if (OkClick != null)
        //    {
        //        OkClick(sender, new FileResourceEventArgs());
        //    }
        //}

        //protected void btnDialogCancel_Click(object sender, EventArgs e)
        //{
        //    dialogdiv.Visible = false;
        //    if (CancelClick != null)
        //    {
        //        CancelClick(sender, e);
        //    }
        //}


        #endregion



        public int LocalId
        {
            set
            {
                FilePicker1.LocalId = value;
            }
        }
    }
}